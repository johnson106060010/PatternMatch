using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Timers;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;



namespace PatternMatchUI
{
    public partial class Form1 : Form
    {
        
        Point mousePos;
        int targetImgWidth = 0;
        int targetImgHeight = 0;
        bool mutexOpen = false;
        MemoryMappedFile mSharedMemoryHeader = null;
        MemoryMappedFile mSharedMemorySample = null;
        MemoryMappedFile mSharedMemoryTarget = null;
        MemoryMappedFile mSharedMemoryResult = null;
        Image<Bgr, byte> mResultImg = null;
        Image<Bgr, byte> mSampleImg = null;
        Image<Bgr, byte> mTargetImg = null;
        string mImageDirectory = @"C:\Users\johnson\Desktop\pattern matching\";
        Process mBackGroundProcess = null;
        string mROIValue = "0,0,0,0";
        string mRotationValue = "0";
        string mResizeValue = "100";
        string mThresholdValue = "0.5";
        int mOffsetX = 0;
        int mOffsetY = 0;
        bool mIsResultSharedMemoryEmpty = true;
        int mContinueModify = 0;//0 for not continue modify 1 for continuing modify
        //if background update the result img, timer start to read it.
        System.Timers.Timer mReadResultImgTimer = null;
        public Form1()
        {
            InitializeComponent();
            TargetImage.MouseMove += new MouseEventHandler(TargetImage_MouseMove);
            TargetImage.Paint += new PaintEventHandler(TargetImage_Paint);
            this.FormClosing += new FormClosingEventHandler(Form1_Closed);

            InitBackgroundProcess();
        }
        //only occur when close by the cross above
        //it will not occur when close by compiler
        public void Form1_Closed(object sender, FormClosingEventArgs e)
        {
            try
            {
                mBackGroundProcess.Kill();
            }
            catch(Exception e1)
            {

            }
        }
        private void TargetImage_Click(object sender, EventArgs e)
        {

        }

        private void TargetImage_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = new Point(e.X, e.Y);
            if (TargetImage.Capture && mousePos.X <= targetImgWidth 
                && mousePos.X >= 0 && mousePos.Y <= targetImgHeight 
                && mousePos.Y >= 0)
            { 
                string tmp = "X: " + e.X.ToString() + "\nY:" + e.Y.ToString();
                MousePos.Text = tmp;
                TargetImage.Invalidate();
            }
        }

        private void TargetImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, mousePos.X, mousePos.Y, 5, 5);
            
        }
        private void AssignImg_Click(object sender, EventArgs e)
        {
            TargetImage.Image = Image.FromFile(mImageDirectory + TargetImgAddr.Text);
            mTargetImg = new Image<Bgr, byte>(mImageDirectory + TargetImgAddr.Text);
            InitImgInfo();
        }

        private void InitImgInfo()
        {
            
            mSampleImg = new Image<Bgr, byte>(mImageDirectory + SampleImgAddr.Text);
            targetImgWidth = TargetImage.Image.Width;
            targetImgHeight = TargetImage.Image.Height;
            string imgInfo = "";
            imgInfo += "Width: " + targetImgWidth + "\n";
            imgInfo += "Height: " + targetImgHeight + "\n";
            ImgInfo.Text = imgInfo;
            mousePos.X = targetImgWidth / 2;
            mousePos.Y = targetImgHeight / 2;
            ROIValue.Text = "0,0," + mSampleImg.Width + "," + mSampleImg.Height;
            //check if load image is valid
            if (mTargetImg.Bytes.Length != 3 * mTargetImg.Width * mTargetImg.Height)
            {
                //MessageBox.Show("TargetImg Byte Array Length not same as setting size");
                MessageBox.Show("Target image width require to be the multiple of 4");
            }
            if (mSampleImg.Bytes.Length != 3 * mSampleImg.Width * mSampleImg.Height)
            {
                //MessageBox.Show("TargetImg Byte Array Length not same as setting size");
                MessageBox.Show("Sample image width require to be the multiple of 4");
            }
        }
        private void ImgInfo_Click(object sender, EventArgs e)
        {

        }

        private void MousePos_Click(object sender, EventArgs e)
        {

        }

        private void WriteToSharedMemory(string info)
        {
            
            
            Byte[] sampleByte = mSampleImg.Bytes;
            Byte[] targetByte = mTargetImg.Bytes;
            //512 for header
            
            //mSharedMemoryHeader = MemoryMappedFile.CreateNew("smHeader", 512);
            //mSharedMemorySample = MemoryMappedFile.CreateNew("smSample", 3 * mSampleImg.Width * mSampleImg.Height);
            //mSharedMemoryTarget = MemoryMappedFile.CreateNew("smTarget", 3 * mTargetImg.Width * mTargetImg.Height);
            
            //Mutex mut = new Mutex(true, "sharedMemoryMutex", out mutexOpen);
            using (var stream = mSharedMemoryHeader.CreateViewStream())
            {
                
                byte[] msg = Encoding.UTF8.GetBytes(info);
                //byte[] totalData = msg + sampleByte + targetByte;
                using (var br = new BinaryWriter(stream))
                {
                    //MessageBox.Show("msg length" + msg.Length.ToString());
                    br.Write(msg, 0, msg.Length);
                    //br.Write(sampleByte, 0, sampleByte.Length);
                    //br.Write(targetByte, 0, target.Width * target.Height * 3);
                }
            }
            using (var stream = mSharedMemorySample.CreateViewStream())
            {
                stream.Write(sampleByte, 0, sampleByte.Length);
            }
            using (var stream = mSharedMemoryTarget.CreateViewStream())
            {
                byte[] clearTargetSharedMemory = new byte[1440000];
                Array.Clear(clearTargetSharedMemory, 0, 1440000);
                stream.Write(clearTargetSharedMemory, 0, 1440000);
                stream.Position = 0;
                stream.Write(targetByte, 0, targetByte.Length);
            }
            //mut.ReleaseMutex();
        }

        private void ReadFromSharedMemory(object sender, ElapsedEventArgs e)
        {
            byte[] info = null;
            string infoStr= "";
            int resultImgWidth = 0;
            int resultImgHeight = 0;
            string inst = "";//if inst == 1 it means background do update the resultImg
            
            using(var stream = mSharedMemoryHeader.CreateViewStream())
            {
                using(var br = new BinaryReader(stream))
                {
                    info = br.ReadBytes(512);
                    infoStr = Encoding.UTF8.GetString(info);
                    string[] infoStrEle = infoStr.Split(',');
                    inst = infoStrEle[0];
                    if(inst == "1")
                    {
                        resultImgWidth = int.Parse(infoStrEle[1]);
                        resultImgHeight = int.Parse(infoStrEle[2]);
                        mResultImg = new Image<Bgr, byte>(resultImgWidth, resultImgHeight);
                    } 
                }
            }

            if(inst == "1")
            {
                using (var stream = mSharedMemoryResult.CreateViewStream())
                {
                    using (var br = new BinaryReader(stream))
                    {
                        mResultImg.Bytes = br.ReadBytes(resultImgWidth * resultImgHeight * 3);
                    }
                }
                //mResultImg correct!!
                
                CvInvoke.Imshow("Result Image", mResultImg);
                CvInvoke.WaitKey(0);
                mReadResultImgTimer.Stop();

                mBackGroundProcess.Kill();

                InitBackgroundProcess();

                
            }    
        }
        private void CallProcess_Click(object sender, EventArgs e)
        {
            //Directory.SetCurrentDirectory(@"C:\Users\johnson\source\repos\Emgu\Emgu\bin\Debug");
            //CallBackgroundProcess();
            mBackGroundProcess.Start();
        }
        private void InitBackgroundProcess()
        {
            mBackGroundProcess = new Process();
            mBackGroundProcess.StartInfo = new ProcessStartInfo("Emgu.exe");
            mBackGroundProcess.StartInfo.WorkingDirectory = @"C:\Users\johnson\source\repos\Emgu\Emgu\bin\Debug";
            mBackGroundProcess.StartInfo.CreateNoWindow = true;
            mBackGroundProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //mBackGroundProcess.Start();
        }
        private void SetOffset_Click(object sender, EventArgs e)
        {
            OffsetValue.Text = "X: " + mousePos.X + "\nY: " + mousePos.Y;
            mOffsetX = mousePos.X;
            mOffsetY = mousePos.Y;
        }

        private void SharedMemoryButton_Click(object sender, EventArgs e)
        {
            mSampleImg = new Image<Bgr, byte>(@"C:\Users\johnson\Desktop\pattern matching\sample cube.png");
            mTargetImg = new Image<Bgr, byte>(@"C:\Users\johnson\Desktop\pattern matching\target cube.png");
            WriteToSharedMemory("sample matching");
            
            //start timer to read the header, if inst == 1 it means result memory is updated
            //and can be read 
            mSharedMemoryResult = MemoryMappedFile.CreateNew(
                "smResult",
                mSampleImg.Width * mSampleImg.Height * 3);
            mReadResultImgTimer = new System.Timers.Timer(2000);
            mReadResultImgTimer.Elapsed += new ElapsedEventHandler(ReadFromSharedMemory);
            mReadResultImgTimer.Start();
            
        }

        private void ViewSampleImg_Click(object sender, EventArgs e)
        {
            try
            {
                mSampleImg = new Image<Bgr, byte>(mImageDirectory + SampleImgAddr.Text);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            ROIValue.Text = "0,0," + mSampleImg.Width + "," + mSampleImg.Height;
            CvInvoke.Imshow("Sample Image", mSampleImg);
            CvInvoke.WaitKey(0);
        }

        private void AssignImg2_Click(object sender, EventArgs e)
        {
            try
            {
                TargetImage.Image = Image.FromFile(mImageDirectory + TargetImgAddr2.Text);
                mTargetImg = new Image<Bgr, byte>(mImageDirectory + TargetImgAddr2.Text);
                InitImgInfo();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void AssignImg3_Click(object sender, EventArgs e)
        {
            try
            {
                TargetImage.Image = Image.FromFile(mImageDirectory + TargetImgAddr3.Text);
                mTargetImg = new Image<Bgr, byte>(mImageDirectory + TargetImgAddr3.Text);
                InitImgInfo();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void AssignImg4_Click(object sender, EventArgs e)
        {
            try
            {
                TargetImage.Image = Image.FromFile(mImageDirectory + TargetImgAddr4.Text);
                mTargetImg = new Image<Bgr, byte>(mImageDirectory + TargetImgAddr4.Text);
                InitImgInfo();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void AssignImg5_Click(object sender, EventArgs e)
        {
            try
            {
                TargetImage.Image = Image.FromFile(mImageDirectory+TargetImgAddr5.Text);
                mTargetImg = new Image<Bgr, byte>(mImageDirectory+TargetImgAddr5.Text);
                InitImgInfo();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void ROIValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartMatching_Click(object sender, EventArgs e)
        {
            
            InitSharedMemory();
            //update result image shared memeory empty flag
            UpdateContinueFlag();
            
            if (mBackGroundProcess.StartInfo.FileName == "Emgu.exe")
            {
                mBackGroundProcess.Start();
                // CallBackgroundProcess();
            }
            string b = mBackGroundProcess.GetType().ToString();
            string info = "match," + mSampleImg.Width + "," + mSampleImg.Height + "," +
                mTargetImg.Width + "," + mTargetImg.Height + "," + mROIValue + "," +
                mRotationValue + "," + mResizeValue + "," + mThresholdValue + "," +
                mOffsetX.ToString() + "," + mOffsetY.ToString() + "," + mContinueModify.ToString() +",";

            WriteToSharedMemory(info);
            InitReadResultTimer();
        }

        private void UpdateContinueFlag()
        {
            if (mIsResultSharedMemoryEmpty == true)
            {
                mContinueModify = 0;
                mIsResultSharedMemoryEmpty = false;
            }
            else
            {
                if (ContinueModify.Checked)
                {
                    if(mContinueModify < 5)
                    {
                        mContinueModify++;
                    }
                    else
                    {
                        mContinueModify = 0;
                    }
                }
                else
                {
                    mContinueModify = 0;
                }
            }
        }
        private void InitSharedMemory()
        {
            if (mSharedMemoryHeader == null)
            {
               mSharedMemoryHeader = MemoryMappedFile.CreateOrOpen("smHeader", 512);
            }
            else
            {
                byte[] clearByte = new byte[512];
                Array.Clear(clearByte, 0, 512);
                using (var stream = mSharedMemoryHeader.CreateViewStream())
                {
                    stream.Position = 0;
                    using (var bw = new BinaryWriter(stream))
                    {
                        bw.Write(clearByte, 0, 512);
                    }
                }
            }
            if (mSharedMemorySample == null)
            {
                try
                {
                    mSharedMemorySample = MemoryMappedFile.CreateNew(
                        "smSample",
                        3 * mSampleImg.Width * mSampleImg.Height
                        );
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            if (mSharedMemoryTarget == null)
            {
                try
                {
                    //maximum sample 800*600
                    mSharedMemoryTarget = MemoryMappedFile.CreateOrOpen(
                        "smTarget",
                        1440000
                        );
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                byte[] clearByte = new byte[750000];
                Array.Clear(clearByte,0,750000);
                using(var stream = mSharedMemoryTarget.CreateViewStream())
                {
                    stream.Position = 0;
                    using(var bw = new BinaryWriter(stream))
                    {
                        bw.Write(clearByte, 0, 750000);
                    }
                }
            }
            if (mSharedMemoryResult == null)
            {
                mSharedMemoryResult = MemoryMappedFile.CreateOrOpen(
                "smResult",
                mSampleImg.Width * mSampleImg.Height * 3);
            }
        }

        private void SetRotation_Click(object sender, EventArgs e)
        {
            
            if(int.Parse(RotationValue.Text) < 0 || int.Parse(RotationValue.Text) > 360)
            {
                MessageBox.Show("Set rotation invalid");
            }
            else
            {
                mRotationValue = RotationValue.Text;
            }
            
        }

        private void Resize_Click(object sender, EventArgs e)
        {
            if (int.Parse(ResizeValue.Text) < 80 || int.Parse(ResizeValue.Text) > 120)
            {
                MessageBox.Show("Resize invalid");
            }
            else
            {
                mResizeValue = ResizeValue.Text;
            }
           
        }

        private void InitReadResultTimer()
        {
            //if timer not create, create it
            //else if already create, start it
            if (mReadResultImgTimer == null)
            {
                mReadResultImgTimer = new System.Timers.Timer(2000);
                mReadResultImgTimer.Elapsed += new ElapsedEventHandler(ReadFromSharedMemory);
                mReadResultImgTimer.Start();
            }
            else
            {
                mReadResultImgTimer.Start();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InitSharedMemory();

            //if (mBackGroundProcess == null)
            //{
            //    CallBackgroundProcess();
            //}
            UpdateContinueFlag();
            string info = "match," + mSampleImg.Width + "," + mSampleImg.Height + "," +
                mTargetImg.Width + "," + mTargetImg.Height + "," + mROIValue + "," +
                mRotationValue + "," + mResizeValue + "," + mThresholdValue + "," +
                mOffsetX.ToString() + "," + mOffsetY.ToString() + "," + mContinueModify.ToString() + ",";

            WriteToSharedMemory(info);
            InitReadResultTimer();
        }

        private void SetThreshold_Click(object sender, EventArgs e)
        {
            if (double.Parse(ThresholdValue.Text) < 0 || double.Parse(ThresholdValue.Text) > 1)
            {
                MessageBox.Show("Threshold invalid");
            }
            else
            {
                mThresholdValue = ThresholdValue.Text;
            }
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SampleImgAddr_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetROI_Click(object sender, EventArgs e)
        {
            mROIValue = ROIValue.Text;
        }

        private void ContinueModify_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void SetImageDirectory_Click(object sender, EventArgs e)
        {
            mImageDirectory = ImageDirectory.Text;
        }
    }
}
