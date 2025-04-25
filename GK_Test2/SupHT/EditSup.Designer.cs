namespace GK_Test2.SupHT
{
    partial class EditSup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(244, 52);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(174, 22);
            this.tbID.TabIndex = 0;
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(244, 112);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(174, 22);
            this.tbTen.TabIndex = 1;
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(244, 175);
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(174, 22);
            this.tbDiaChi.TabIndex = 2;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(576, 247);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(128, 59);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "button1";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // EditSup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbDiaChi);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.tbID);
            this.Name = "EditSup";
            this.Text = "EditSup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.TextBox tbDiaChi;
        private System.Windows.Forms.Button btSave;
    }
}