namespace QLHSVP
{
    partial class QLHieuSach
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnQLy = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnNV);
            this.panel1.Controls.Add(this.btnTK);
            this.panel1.Controls.Add(this.btnQLy);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 667);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Location = new System.Drawing.Point(232, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 106);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox1.Image = global::QLHSVP.Properties.Resources.logo_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnNV
            // 
            this.btnNV.FlatAppearance.BorderSize = 0;
            this.btnNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNV.Image = global::QLHSVP.Properties.Resources.icons8_employee_50;
            this.btnNV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNV.Location = new System.Drawing.Point(4, 437);
            this.btnNV.Name = "btnNV";
            this.btnNV.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.btnNV.Size = new System.Drawing.Size(238, 106);
            this.btnNV.TabIndex = 4;
            this.btnNV.Text = "Nhân viên";
            this.btnNV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnTK
            // 
            this.btnTK.FlatAppearance.BorderSize = 0;
            this.btnTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTK.Image = global::QLHSVP.Properties.Resources.icons8_statistics_50;
            this.btnTK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTK.Location = new System.Drawing.Point(4, 325);
            this.btnTK.Name = "btnTK";
            this.btnTK.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.btnTK.Size = new System.Drawing.Size(238, 106);
            this.btnTK.TabIndex = 3;
            this.btnTK.Text = "Thống kê";
            this.btnTK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // btnQLy
            // 
            this.btnQLy.FlatAppearance.BorderSize = 0;
            this.btnQLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLy.ForeColor = System.Drawing.Color.Black;
            this.btnQLy.Image = global::QLHSVP.Properties.Resources.icons8_book_50;
            this.btnQLy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQLy.Location = new System.Drawing.Point(4, 216);
            this.btnQLy.Name = "btnQLy";
            this.btnQLy.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.btnQLy.Size = new System.Drawing.Size(238, 106);
            this.btnQLy.TabIndex = 2;
            this.btnQLy.Text = "Quản lý";
            this.btnQLy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLy.UseVisualStyleBackColor = true;
            this.btnQLy.Click += new System.EventHandler(this.btnQLy_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.Coral;
            this.textBox1.Location = new System.Drawing.Point(246, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(804, 46);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "QUẢN LÝ HIỆU SÁCH";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.WordWrap = false;
            // 
            // PanelContent
            // 
            this.PanelContent.Location = new System.Drawing.Point(246, 64);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(797, 591);
            this.PanelContent.TabIndex = 2;
            // 
            // QLHieuSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1055, 667);
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLHieuSach";
            this.Text = "QLHieuSach";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnNV;
        private Button btnTK;
        private Button btnQLy;
        private Panel panel2;
        private TextBox textBox1;
        private Panel PanelContent;
    }
}