namespace GombVadaszat
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
            this.components = new System.ComponentModel.Container();
            this.mainBtn = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainBtn
            // 
            this.mainBtn.Location = new System.Drawing.Point(444, 177);
            this.mainBtn.Name = "mainBtn";
            this.mainBtn.Size = new System.Drawing.Size(106, 41);
            this.mainBtn.TabIndex = 0;
            this.mainBtn.Text = "button1";
            this.mainBtn.UseVisualStyleBackColor = true;
            this.mainBtn.Click += new System.EventHandler(this.mainBtn_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 10000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.mainBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button mainBtn;
        private System.Windows.Forms.Timer mainTimer;
    }
}