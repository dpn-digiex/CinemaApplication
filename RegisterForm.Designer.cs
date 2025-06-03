namespace CinemaApplication
{
    partial class RegisterForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxUsername = new TextBox();
            label8 = new Label();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            label9 = new Label();
            textBoxSdt = new TextBox();
            textBoxFullname = new TextBox();
            textBoxEmail = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnRegister = new Button();
            btnComeback = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 21);
            label1.Name = "label1";
            label1.Size = new Size(160, 31);
            label1.TabIndex = 0;
            label1.Text = "Tạo tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 74);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập (*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 114);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu (*):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 157);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 3;
            label4.Text = "Xác nhận mật khẩu (*):";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(186, 71);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(291, 27);
            textBoxUsername.TabIndex = 7;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(27, 202);
            label8.Name = "label8";
            label8.Size = new Size(450, 2);
            label8.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(186, 111);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(291, 27);
            textBoxPassword.TabIndex = 9;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(186, 154);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(291, 27);
            textBoxConfirmPassword.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 226);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 11;
            label9.Text = "Thông tin cá nhân";
            // 
            // textBoxSdt
            // 
            textBoxSdt.Location = new Point(186, 347);
            textBoxSdt.Name = "textBoxSdt";
            textBoxSdt.Size = new Size(291, 27);
            textBoxSdt.TabIndex = 17;
            // 
            // textBoxFullname
            // 
            textBoxFullname.Location = new Point(186, 304);
            textBoxFullname.Name = "textBoxFullname";
            textBoxFullname.Size = new Size(291, 27);
            textBoxFullname.TabIndex = 16;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(186, 264);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(291, 27);
            textBoxEmail.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 350);
            label10.Name = "label10";
            label10.Size = new Size(120, 20);
            label10.TabIndex = 14;
            label10.Text = "Số điện thoại (*):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 307);
            label11.Name = "label11";
            label11.Size = new Size(96, 20);
            label11.TabIndex = 13;
            label11.Text = "Họ và tên (*):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 267);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 12;
            label12.Text = "Email (*):";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.Highlight;
            btnRegister.ForeColor = SystemColors.HighlightText;
            btnRegister.Location = new Point(383, 419);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 18;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnComeback
            // 
            btnComeback.Location = new Point(268, 419);
            btnComeback.Name = "btnComeback";
            btnComeback.Size = new Size(94, 29);
            btnComeback.TabIndex = 19;
            btnComeback.Text = "Quay lại";
            btnComeback.UseVisualStyleBackColor = true;
            btnComeback.Click += btnComeback_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 560);
            Controls.Add(btnComeback);
            Controls.Add(btnRegister);
            Controls.Add(textBoxSdt);
            Controls.Add(textBoxFullname);
            Controls.Add(textBoxEmail);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(label8);
            Controls.Add(textBoxUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký người dùng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxUsername;
        private Label label8;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private Label label9;
        private TextBox textBoxSdt;
        private TextBox textBoxFullname;
        private TextBox textBoxEmail;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btnRegister;
        private Button btnComeback;
    }
}