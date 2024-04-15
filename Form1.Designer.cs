
namespace Movies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Image = Properties.Resources.tp_do;
            button1.Location = new Point(331, 344);
            button1.Name = "button1";
            button1.Size = new Size(138, 47);
            button1.TabIndex = 0;
            button1.Text = "Insert Data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnInsertData_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Image = Properties.Resources.tp_do;
            button2.Location = new Point(331, 51);
            button2.Name = "button2";
            button2.Size = new Size(138, 44);
            button2.TabIndex = 1;
            button2.Text = "Select Files";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSelectFiles_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(353, 212);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 3;
            label2.Text = "Selected Files";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private EventHandler txtMoviesFile_TextChanged;
        private Button button2;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
    }
}
