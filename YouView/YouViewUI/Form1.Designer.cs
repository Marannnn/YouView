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
            reload_button = new Button();
            SuspendLayout();
            // 
            // tags_flowLayoutPanel
            // 
            tags_flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            tags_flowLayoutPanel.Location = new Point(12, 13);
            tags_flowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tags_flowLayoutPanel.Name = "tags_flowLayoutPanel";
            tags_flowLayoutPanel.Size = new Size(87, 665);
            tags_flowLayoutPanel.TabIndex = 0;
            // 
            // videos_flowLayoutPanel
            // 
            videos_flowLayoutPanel.Location = new Point(115, 13);
            videos_flowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            videos_flowLayoutPanel.Name = "videos_flowLayoutPanel";
            videos_flowLayoutPanel.Size = new Size(869, 665);
            videos_flowLayoutPanel.TabIndex = 1;
            // 
            // AddChannel_button
            // 
            AddChannel_button.Location = new Point(1062, 209);
            AddChannel_button.Margin = new Padding(3, 4, 3, 4);
            AddChannel_button.Name = "AddChannel_button";
            AddChannel_button.Size = new Size(86, 31);
            AddChannel_button.TabIndex = 2;
            AddChannel_button.Text = "Add";
            AddChannel_button.UseVisualStyleBackColor = true;
            AddChannel_button.Click += AddChannelButton_Click;
            // 
            // ChannelID_textbox
            // 
            ChannelID_textbox.Location = new Point(1115, 28);
            ChannelID_textbox.Margin = new Padding(3, 4, 3, 4);
            ChannelID_textbox.Name = "ChannelID_textbox";
            ChannelID_textbox.Size = new Size(114, 27);
            ChannelID_textbox.TabIndex = 3;
            ChannelID_textbox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(991, 32);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 4;
            label1.Text = "Channel ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(991, 97);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 5;
            label2.Text = "Channel Name";
            // 
            // ChannelName_textbox
            // 
            ChannelName_textbox.Location = new Point(1115, 97);
            ChannelName_textbox.Margin = new Padding(3, 4, 3, 4);
            ChannelName_textbox.Name = "ChannelName_textbox";
            ChannelName_textbox.Size = new Size(114, 27);
            ChannelName_textbox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(991, 155);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 7;
            label3.Text = "Channel Tag";
            // 
            // ChannelTag_textbox
            // 
            ChannelTag_textbox.Location = new Point(1115, 155);
            ChannelTag_textbox.Margin = new Padding(3, 4, 3, 4);
            ChannelTag_textbox.Name = "ChannelTag_textbox";
            ChannelTag_textbox.Size = new Size(114, 27);
            ChannelTag_textbox.TabIndex = 8;
            // 
            // reload_button
            // 
            reload_button.Location = new Point(1062, 649);
            reload_button.Name = "reload_button";
            reload_button.Size = new Size(86, 29);
            reload_button.TabIndex = 9;
            reload_button.Text = "Reload";
            reload_button.UseVisualStyleBackColor = true;
            reload_button.Click += reload_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 691);
            Controls.Add(reload_button);
            Controls.Add(ChannelTag_textbox);
            Controls.Add(label3);
            Controls.Add(ChannelName_textbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ChannelID_textbox);
            Controls.Add(AddChannel_button);
            Controls.Add(videos_flowLayoutPanel);
            Controls.Add(tags_flowLayoutPanel);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button reload_button;
    }
}
