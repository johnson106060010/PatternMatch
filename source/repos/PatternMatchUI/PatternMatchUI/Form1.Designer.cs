namespace PatternMatchUI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TargetImage = new System.Windows.Forms.PictureBox();
            this.SetOffset = new System.Windows.Forms.Button();
            this.SetROI = new System.Windows.Forms.Button();
            this.SetRotation = new System.Windows.Forms.Button();
            this.Resize = new System.Windows.Forms.Button();
            this.AssignImg = new System.Windows.Forms.Button();
            this.TargetImgAddr = new System.Windows.Forms.TextBox();
            this.ImgInfo = new System.Windows.Forms.Label();
            this.MousePos = new System.Windows.Forms.Label();
            this.CallProcess = new System.Windows.Forms.Button();
            this.OffsetValue = new System.Windows.Forms.Label();
            this.SharedMemoryButton = new System.Windows.Forms.Button();
            this.TargetImgAddr2 = new System.Windows.Forms.TextBox();
            this.TargetImgAddr3 = new System.Windows.Forms.TextBox();
            this.TargetImgAddr4 = new System.Windows.Forms.TextBox();
            this.TargetImgAddr5 = new System.Windows.Forms.TextBox();
            this.AssignImg2 = new System.Windows.Forms.Button();
            this.AssignImg3 = new System.Windows.Forms.Button();
            this.AssignImg4 = new System.Windows.Forms.Button();
            this.AssignImg5 = new System.Windows.Forms.Button();
            this.SampleImgAddr = new System.Windows.Forms.TextBox();
            this.ViewSampleImg = new System.Windows.Forms.Button();
            this.ROIValue = new System.Windows.Forms.TextBox();
            this.RotationValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResizeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StartMatching = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SetThreshold = new System.Windows.Forms.Button();
            this.ThresholdValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ContinueModify = new System.Windows.Forms.CheckBox();
            this.ImageDirectory = new System.Windows.Forms.TextBox();
            this.SetImageDirectory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TargetImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetImage
            // 
            this.TargetImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetImage.Location = new System.Drawing.Point(86, 61);
            this.TargetImage.Name = "TargetImage";
            this.TargetImage.Size = new System.Drawing.Size(143, 121);
            this.TargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TargetImage.TabIndex = 0;
            this.TargetImage.TabStop = false;
            this.TargetImage.Click += new System.EventHandler(this.TargetImage_Click);
            // 
            // SetOffset
            // 
            this.SetOffset.Location = new System.Drawing.Point(421, 38);
            this.SetOffset.Name = "SetOffset";
            this.SetOffset.Size = new System.Drawing.Size(75, 23);
            this.SetOffset.TabIndex = 1;
            this.SetOffset.Text = "Set Offset";
            this.SetOffset.UseVisualStyleBackColor = true;
            this.SetOffset.Click += new System.EventHandler(this.SetOffset_Click);
            // 
            // SetROI
            // 
            this.SetROI.Location = new System.Drawing.Point(421, 85);
            this.SetROI.Name = "SetROI";
            this.SetROI.Size = new System.Drawing.Size(75, 23);
            this.SetROI.TabIndex = 2;
            this.SetROI.Text = "Set ROI";
            this.SetROI.UseVisualStyleBackColor = true;
            this.SetROI.Click += new System.EventHandler(this.SetROI_Click);
            // 
            // SetRotation
            // 
            this.SetRotation.Location = new System.Drawing.Point(421, 133);
            this.SetRotation.Name = "SetRotation";
            this.SetRotation.Size = new System.Drawing.Size(75, 23);
            this.SetRotation.TabIndex = 3;
            this.SetRotation.Text = "Set Rotation";
            this.SetRotation.UseVisualStyleBackColor = true;
            this.SetRotation.Click += new System.EventHandler(this.SetRotation_Click);
            // 
            // Resize
            // 
            this.Resize.Location = new System.Drawing.Point(421, 178);
            this.Resize.Name = "Resize";
            this.Resize.Size = new System.Drawing.Size(75, 23);
            this.Resize.TabIndex = 4;
            this.Resize.Text = "Resize";
            this.Resize.UseVisualStyleBackColor = true;
            this.Resize.Click += new System.EventHandler(this.Resize_Click);
            // 
            // AssignImg
            // 
            this.AssignImg.Location = new System.Drawing.Point(289, 259);
            this.AssignImg.Name = "AssignImg";
            this.AssignImg.Size = new System.Drawing.Size(115, 23);
            this.AssignImg.TabIndex = 5;
            this.AssignImg.Text = "Load";
            this.AssignImg.UseVisualStyleBackColor = true;
            this.AssignImg.Click += new System.EventHandler(this.AssignImg_Click);
            // 
            // TargetImgAddr
            // 
            this.TargetImgAddr.Font = new System.Drawing.Font("新細明體", 12F);
            this.TargetImgAddr.Location = new System.Drawing.Point(3, 262);
            this.TargetImgAddr.Name = "TargetImgAddr";
            this.TargetImgAddr.Size = new System.Drawing.Size(280, 27);
            this.TargetImgAddr.TabIndex = 6;
            this.TargetImgAddr.Text = "target cube.png";
            this.TargetImgAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ImgInfo
            // 
            this.ImgInfo.AutoSize = true;
            this.ImgInfo.Font = new System.Drawing.Font("新細明體", 12F);
            this.ImgInfo.Location = new System.Drawing.Point(423, 292);
            this.ImgInfo.Name = "ImgInfo";
            this.ImgInfo.Size = new System.Drawing.Size(0, 16);
            this.ImgInfo.TabIndex = 7;
            this.ImgInfo.Click += new System.EventHandler(this.ImgInfo_Click);
            // 
            // MousePos
            // 
            this.MousePos.AutoSize = true;
            this.MousePos.Font = new System.Drawing.Font("新細明體", 12F);
            this.MousePos.Location = new System.Drawing.Point(423, 334);
            this.MousePos.Name = "MousePos";
            this.MousePos.Size = new System.Drawing.Size(73, 32);
            this.MousePos.TabIndex = 8;
            this.MousePos.Text = "MouseX:0\r\nMouseY:0";
            this.MousePos.Click += new System.EventHandler(this.MousePos_Click);
            // 
            // CallProcess
            // 
            this.CallProcess.Location = new System.Drawing.Point(664, 372);
            this.CallProcess.Name = "CallProcess";
            this.CallProcess.Size = new System.Drawing.Size(183, 23);
            this.CallProcess.TabIndex = 9;
            this.CallProcess.Text = "Call Background Process";
            this.CallProcess.UseVisualStyleBackColor = true;
            this.CallProcess.Click += new System.EventHandler(this.CallProcess_Click);
            // 
            // OffsetValue
            // 
            this.OffsetValue.AutoSize = true;
            this.OffsetValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.OffsetValue.Location = new System.Drawing.Point(525, 29);
            this.OffsetValue.Name = "OffsetValue";
            this.OffsetValue.Size = new System.Drawing.Size(73, 32);
            this.OffsetValue.TabIndex = 10;
            this.OffsetValue.Text = "OffsetX: 0\r\nOffsetY: 0";
            // 
            // SharedMemoryButton
            // 
            this.SharedMemoryButton.Location = new System.Drawing.Point(724, 317);
            this.SharedMemoryButton.Name = "SharedMemoryButton";
            this.SharedMemoryButton.Size = new System.Drawing.Size(123, 23);
            this.SharedMemoryButton.TabIndex = 11;
            this.SharedMemoryButton.Text = "Test SharedMemory";
            this.SharedMemoryButton.UseVisualStyleBackColor = true;
            this.SharedMemoryButton.Visible = false;
            this.SharedMemoryButton.Click += new System.EventHandler(this.SharedMemoryButton_Click);
            // 
            // TargetImgAddr2
            // 
            this.TargetImgAddr2.Font = new System.Drawing.Font("新細明體", 12F);
            this.TargetImgAddr2.Location = new System.Drawing.Point(3, 290);
            this.TargetImgAddr2.Name = "TargetImgAddr2";
            this.TargetImgAddr2.Size = new System.Drawing.Size(280, 27);
            this.TargetImgAddr2.TabIndex = 12;
            this.TargetImgAddr2.Text = "maple target3.jpg";
            this.TargetImgAddr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TargetImgAddr3
            // 
            this.TargetImgAddr3.Font = new System.Drawing.Font("新細明體", 12F);
            this.TargetImgAddr3.Location = new System.Drawing.Point(3, 318);
            this.TargetImgAddr3.Name = "TargetImgAddr3";
            this.TargetImgAddr3.Size = new System.Drawing.Size(280, 27);
            this.TargetImgAddr3.TabIndex = 13;
            this.TargetImgAddr3.Text = "maple target.jpg";
            this.TargetImgAddr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TargetImgAddr4
            // 
            this.TargetImgAddr4.Font = new System.Drawing.Font("新細明體", 12F);
            this.TargetImgAddr4.Location = new System.Drawing.Point(3, 346);
            this.TargetImgAddr4.Name = "TargetImgAddr4";
            this.TargetImgAddr4.Size = new System.Drawing.Size(280, 27);
            this.TargetImgAddr4.TabIndex = 14;
            this.TargetImgAddr4.Text = "rotate target.jpg";
            this.TargetImgAddr4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TargetImgAddr5
            // 
            this.TargetImgAddr5.Font = new System.Drawing.Font("新細明體", 12F);
            this.TargetImgAddr5.Location = new System.Drawing.Point(3, 374);
            this.TargetImgAddr5.Name = "TargetImgAddr5";
            this.TargetImgAddr5.Size = new System.Drawing.Size(280, 27);
            this.TargetImgAddr5.TabIndex = 15;
            this.TargetImgAddr5.Text = "maple target2.jpg";
            this.TargetImgAddr5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AssignImg2
            // 
            this.AssignImg2.Location = new System.Drawing.Point(289, 288);
            this.AssignImg2.Name = "AssignImg2";
            this.AssignImg2.Size = new System.Drawing.Size(115, 23);
            this.AssignImg2.TabIndex = 16;
            this.AssignImg2.Text = "Load";
            this.AssignImg2.UseVisualStyleBackColor = true;
            this.AssignImg2.Click += new System.EventHandler(this.AssignImg2_Click);
            // 
            // AssignImg3
            // 
            this.AssignImg3.Location = new System.Drawing.Point(289, 317);
            this.AssignImg3.Name = "AssignImg3";
            this.AssignImg3.Size = new System.Drawing.Size(115, 23);
            this.AssignImg3.TabIndex = 17;
            this.AssignImg3.Text = "Load";
            this.AssignImg3.UseVisualStyleBackColor = true;
            this.AssignImg3.Click += new System.EventHandler(this.AssignImg3_Click);
            // 
            // AssignImg4
            // 
            this.AssignImg4.Location = new System.Drawing.Point(289, 346);
            this.AssignImg4.Name = "AssignImg4";
            this.AssignImg4.Size = new System.Drawing.Size(115, 23);
            this.AssignImg4.TabIndex = 18;
            this.AssignImg4.Text = "Load";
            this.AssignImg4.UseVisualStyleBackColor = true;
            this.AssignImg4.Click += new System.EventHandler(this.AssignImg4_Click);
            // 
            // AssignImg5
            // 
            this.AssignImg5.Location = new System.Drawing.Point(289, 375);
            this.AssignImg5.Name = "AssignImg5";
            this.AssignImg5.Size = new System.Drawing.Size(115, 23);
            this.AssignImg5.TabIndex = 19;
            this.AssignImg5.Text = "Load";
            this.AssignImg5.UseVisualStyleBackColor = true;
            this.AssignImg5.Click += new System.EventHandler(this.AssignImg5_Click);
            // 
            // SampleImgAddr
            // 
            this.SampleImgAddr.Font = new System.Drawing.Font("新細明體", 12F);
            this.SampleImgAddr.Location = new System.Drawing.Point(421, 249);
            this.SampleImgAddr.Name = "SampleImgAddr";
            this.SampleImgAddr.Size = new System.Drawing.Size(290, 27);
            this.SampleImgAddr.TabIndex = 20;
            this.SampleImgAddr.Text = "maple sample.jpg";
            this.SampleImgAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SampleImgAddr.TextChanged += new System.EventHandler(this.SampleImgAddr_TextChanged);
            // 
            // ViewSampleImg
            // 
            this.ViewSampleImg.Location = new System.Drawing.Point(717, 247);
            this.ViewSampleImg.Name = "ViewSampleImg";
            this.ViewSampleImg.Size = new System.Drawing.Size(115, 23);
            this.ViewSampleImg.TabIndex = 21;
            this.ViewSampleImg.Text = "View Sample";
            this.ViewSampleImg.UseVisualStyleBackColor = true;
            this.ViewSampleImg.Click += new System.EventHandler(this.ViewSampleImg_Click);
            // 
            // ROIValue
            // 
            this.ROIValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.ROIValue.Location = new System.Drawing.Point(528, 85);
            this.ROIValue.Name = "ROIValue";
            this.ROIValue.Size = new System.Drawing.Size(100, 27);
            this.ROIValue.TabIndex = 22;
            this.ROIValue.Text = "0,0,0,0";
            this.ROIValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ROIValue.TextChanged += new System.EventHandler(this.ROIValue_TextChanged);
            // 
            // RotationValue
            // 
            this.RotationValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.RotationValue.Location = new System.Drawing.Point(528, 133);
            this.RotationValue.Name = "RotationValue";
            this.RotationValue.Size = new System.Drawing.Size(38, 27);
            this.RotationValue.TabIndex = 23;
            this.RotationValue.Text = "0";
            this.RotationValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(572, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Degree (0~360)";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ResizeValue
            // 
            this.ResizeValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.ResizeValue.Location = new System.Drawing.Point(528, 178);
            this.ResizeValue.Name = "ResizeValue";
            this.ResizeValue.Size = new System.Drawing.Size(38, 27);
            this.ResizeValue.TabIndex = 25;
            this.ResizeValue.Text = "100";
            this.ResizeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(572, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "% (80%~120%)";
            // 
            // StartMatching
            // 
            this.StartMatching.Font = new System.Drawing.Font("新細明體", 20F);
            this.StartMatching.Location = new System.Drawing.Point(664, 37);
            this.StartMatching.Name = "StartMatching";
            this.StartMatching.Size = new System.Drawing.Size(149, 71);
            this.StartMatching.TabIndex = 27;
            this.StartMatching.Text = "START";
            this.StartMatching.UseVisualStyleBackColor = true;
            this.StartMatching.Click += new System.EventHandler(this.StartMatching_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(668, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Start program without background";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SetThreshold
            // 
            this.SetThreshold.Location = new System.Drawing.Point(421, 217);
            this.SetThreshold.Name = "SetThreshold";
            this.SetThreshold.Size = new System.Drawing.Size(81, 23);
            this.SetThreshold.TabIndex = 29;
            this.SetThreshold.Text = "Set Threshold";
            this.SetThreshold.UseVisualStyleBackColor = true;
            this.SetThreshold.Click += new System.EventHandler(this.SetThreshold_Click);
            // 
            // ThresholdValue
            // 
            this.ThresholdValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.ThresholdValue.Location = new System.Drawing.Point(528, 217);
            this.ThresholdValue.Name = "ThresholdValue";
            this.ThresholdValue.Size = new System.Drawing.Size(38, 27);
            this.ThresholdValue.TabIndex = 30;
            this.ThresholdValue.Text = "0.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(573, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "(0~1)";
            // 
            // ContinueModify
            // 
            this.ContinueModify.AutoSize = true;
            this.ContinueModify.Location = new System.Drawing.Point(707, 133);
            this.ContinueModify.Name = "ContinueModify";
            this.ContinueModify.Size = new System.Drawing.Size(105, 16);
            this.ContinueModify.TabIndex = 32;
            this.ContinueModify.Text = "Continue Modify";
            this.ContinueModify.UseVisualStyleBackColor = true;
            this.ContinueModify.CheckedChanged += new System.EventHandler(this.ContinueModify_CheckedChanged);
            // 
            // ImageDirectory
            // 
            this.ImageDirectory.Location = new System.Drawing.Point(498, 283);
            this.ImageDirectory.Name = "ImageDirectory";
            this.ImageDirectory.Size = new System.Drawing.Size(213, 22);
            this.ImageDirectory.TabIndex = 33;
            this.ImageDirectory.Text = "C:\\Users\\johnson\\Desktop\\pattern matching\\";
            // 
            // SetImageDirectory
            // 
            this.SetImageDirectory.Location = new System.Drawing.Point(724, 283);
            this.SetImageDirectory.Name = "SetImageDirectory";
            this.SetImageDirectory.Size = new System.Drawing.Size(108, 23);
            this.SetImageDirectory.TabIndex = 34;
            this.SetImageDirectory.Text = "Set Image Directory";
            this.SetImageDirectory.UseVisualStyleBackColor = true;
            this.SetImageDirectory.Click += new System.EventHandler(this.SetImageDirectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 489);
            this.Controls.Add(this.SetImageDirectory);
            this.Controls.Add(this.ImageDirectory);
            this.Controls.Add(this.ContinueModify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ThresholdValue);
            this.Controls.Add(this.SetThreshold);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartMatching);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResizeValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RotationValue);
            this.Controls.Add(this.ROIValue);
            this.Controls.Add(this.ViewSampleImg);
            this.Controls.Add(this.SampleImgAddr);
            this.Controls.Add(this.AssignImg5);
            this.Controls.Add(this.AssignImg4);
            this.Controls.Add(this.AssignImg3);
            this.Controls.Add(this.AssignImg2);
            this.Controls.Add(this.TargetImgAddr5);
            this.Controls.Add(this.TargetImgAddr4);
            this.Controls.Add(this.TargetImgAddr3);
            this.Controls.Add(this.TargetImgAddr2);
            this.Controls.Add(this.SharedMemoryButton);
            this.Controls.Add(this.OffsetValue);
            this.Controls.Add(this.CallProcess);
            this.Controls.Add(this.MousePos);
            this.Controls.Add(this.ImgInfo);
            this.Controls.Add(this.TargetImgAddr);
            this.Controls.Add(this.AssignImg);
            this.Controls.Add(this.Resize);
            this.Controls.Add(this.SetRotation);
            this.Controls.Add(this.SetROI);
            this.Controls.Add(this.SetOffset);
            this.Controls.Add(this.TargetImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TargetImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TargetImage;
        private System.Windows.Forms.Button SetOffset;
        private System.Windows.Forms.Button SetROI;
        private System.Windows.Forms.Button SetRotation;
        private System.Windows.Forms.Button Resize;
        private System.Windows.Forms.Button AssignImg;
        private System.Windows.Forms.TextBox TargetImgAddr;
        private System.Windows.Forms.Label ImgInfo;
        private System.Windows.Forms.Label MousePos;
        private System.Windows.Forms.Button CallProcess;
        private System.Windows.Forms.Label OffsetValue;
        private System.Windows.Forms.Button SharedMemoryButton;
        private System.Windows.Forms.TextBox TargetImgAddr2;
        private System.Windows.Forms.TextBox TargetImgAddr3;
        private System.Windows.Forms.TextBox TargetImgAddr4;
        private System.Windows.Forms.TextBox TargetImgAddr5;
        private System.Windows.Forms.Button AssignImg2;
        private System.Windows.Forms.Button AssignImg3;
        private System.Windows.Forms.Button AssignImg4;
        private System.Windows.Forms.Button AssignImg5;
        private System.Windows.Forms.TextBox SampleImgAddr;
        private System.Windows.Forms.Button ViewSampleImg;
        private System.Windows.Forms.TextBox ROIValue;
        private System.Windows.Forms.TextBox RotationValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ResizeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartMatching;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SetThreshold;
        private System.Windows.Forms.TextBox ThresholdValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ContinueModify;
        private System.Windows.Forms.TextBox ImageDirectory;
        private System.Windows.Forms.Button SetImageDirectory;
    }
}

