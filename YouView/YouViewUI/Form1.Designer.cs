namespace YouViewUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tags_flowLayoutPanel = new FlowLayoutPanel();
            videos_flowLayoutPanel = new FlowLayoutPanel();
            AddChannel_button = new Button();
            ChannelID_textbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ChannelName_textbox = new TextBox();
            label3 = new Label();
            ChannelTag_textbox = new TextBox();
            SuspendLayout();
            // 
            // tags_flowLayoutPanel
            // 
            tags_flowLayoutPanel.Location = new Point(0, 0);
            tags_flowLayoutPanel.Name = "tags_flowLayoutPanel";
            tags_flowLayoutPanel.Size = new Size(73, 519);
            tags_flowLayoutPanel.TabIndex = 0;
            // 
            // videos_flowLayoutPanel
            // 
            videos_flowLayoutPanel.Location = new Point(101, 12);
            videos_flowLayoutPanel.Name = "videos_flowLayoutPanel";
            videos_flowLayoutPanel.Size = new Size(760, 493);
            videos_flowLayoutPanel.TabIndex = 1;
            // 
            // AddChannel_button
            // 
            AddChannel_button.Location = new Point(929, 157);
            AddChannel_button.Name = "AddChannel_button";
            AddChannel_button.Size = new Size(75, 23);
            AddChannel_button.TabIndex = 2;
            AddChannel_button.Text = "Add";
            AddChannel_button.UseVisualStyleBackColor = true;
            AddChannel_button.Click += AddChannelButton_Click;
            // 
            // ChannelID_textbox
            // 
            ChannelID_textbox.Location = new Point(976, 21);
            ChannelID_textbox.Name = "ChannelID_textbox";
            ChannelID_textbox.Size = new Size(100, 23);
            ChannelID_textbox.TabIndex = 3;
            ChannelID_textbox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(867, 24);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "Channel ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(867, 73);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 5;
            label2.Text = "Channel Name";
            // 
            // ChannelName_textbox
            // 
            ChannelName_textbox.Location = new Point(976, 73);
            ChannelName_textbox.Name = "ChannelName_textbox";
            ChannelName_textbox.Size = new Size(100, 23);
            ChannelName_textbox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(867, 116);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 7;
            label3.Text = "Channel Tag";
            // 
            // ChannelTag_textbox
            // 
            ChannelTag_textbox.Location = new Point(976, 116);
            ChannelTag_textbox.Name = "ChannelTag_textbox";
            ChannelTag_textbox.Size = new Size(100, 23);
            ChannelTag_textbox.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 518);
            Controls.Add(ChannelTag_textbox);
            Controls.Add(label3);
            Controls.Add(ChannelName_textbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ChannelID_textbox);
            Controls.Add(AddChannel_button);
            Controls.Add(videos_flowLayoutPanel);
            Controls.Add(tags_flowLayoutPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel tags_flowLayoutPanel;
        private FlowLayoutPanel videos_flowLayoutPanel;
        private Button AddChannel_button;
        private TextBox ChannelID_textbox;
        private Label label1;
        private Label label2;
        private TextBox ChannelName_textbox;
        private Label label3;
        private TextBox ChannelTag_textbox;
    }
}
