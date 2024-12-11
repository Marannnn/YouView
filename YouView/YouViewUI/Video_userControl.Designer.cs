namespace YouViewUI
{
    partial class Video_userControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            videoName_label = new Label();
            videoChannel_label = new Label();
            videoTag_label = new Label();
            SuspendLayout();
            // 
            // videoName_label
            // 
            videoName_label.AutoSize = true;
            videoName_label.Location = new Point(32, 34);
            videoName_label.Name = "videoName_label";
            videoName_label.Size = new Size(90, 20);
            videoName_label.TabIndex = 0;
            videoName_label.Text = "video Name";
            // 
            // videoChannel_label
            // 
            videoChannel_label.AutoSize = true;
            videoChannel_label.Location = new Point(32, 111);
            videoChannel_label.Name = "videoChannel_label";
            videoChannel_label.Size = new Size(103, 20);
            videoChannel_label.TabIndex = 1;
            videoChannel_label.Text = "video Channel";
            // 
            // videoTag_label
            // 
            videoTag_label.AutoSize = true;
            videoTag_label.Location = new Point(176, 111);
            videoTag_label.Name = "videoTag_label";
            videoTag_label.Size = new Size(73, 20);
            videoTag_label.TabIndex = 2;
            videoTag_label.Text = "video Tag";
            // 
            // Video_userControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(videoTag_label);
            Controls.Add(videoChannel_label);
            Controls.Add(videoName_label);
            Name = "Video_userControl";
            Size = new Size(267, 150);
            Load += Video_userControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label videoChannel_label;
        private Label videoTag_label;
        private Label videoName_label;
    }
}
