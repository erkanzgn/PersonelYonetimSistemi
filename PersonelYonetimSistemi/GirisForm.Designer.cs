namespace PersonelYonetimSistemi
{
    partial class GirisForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            btnKayıtOl = new Button();
            pictureBox1 = new PictureBox();
            lblKullanıcıSifre = new Label();
            lblKullanıcıAd = new Label();
            labelGirisYap = new Label();
            chcBoxSifreGoster = new CheckBox();
            GirisYapBtn = new Button();
            GirisPanel = new Panel();
            label1 = new Label();
            elipseToolGirisForm = new FormUI.ElipseTool();
            elipseToolpanel = new FormUI.ElipseTool();
            elipseToolkayıt = new FormUI.ElipseTool();
            elipseToolGirisyap = new FormUI.ElipseTool();
            ExitPicBox = new PictureBox();
            EpostaTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            SifreTxtBox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GirisPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExitPicBox).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(75, 333);
            label2.Name = "label2";
            label2.Size = new Size(122, 16);
            label2.TabIndex = 3;
            label2.Text = "Kişisel bilgilerini gir ";
            // 
            // btnKayıtOl
            // 
            btnKayıtOl.BackColor = Color.FromArgb(175, 185, 255);
            btnKayıtOl.Cursor = Cursors.Hand;
            btnKayıtOl.FlatAppearance.BorderColor = Color.SlateBlue;
            btnKayıtOl.FlatAppearance.BorderSize = 0;
            btnKayıtOl.FlatAppearance.MouseDownBackColor = Color.SlateBlue;
            btnKayıtOl.FlatAppearance.MouseOverBackColor = Color.SlateBlue;
            btnKayıtOl.FlatStyle = FlatStyle.Flat;
            btnKayıtOl.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnKayıtOl.Location = new Point(31, 352);
            btnKayıtOl.Name = "btnKayıtOl";
            btnKayıtOl.Size = new Size(201, 39);
            btnKayıtOl.TabIndex = 2;
            btnKayıtOl.Text = "Kayıt Ol";
            btnKayıtOl.UseVisualStyleBackColor = false;
            btnKayıtOl.Click += btnKayıtOl_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblKullanıcıSifre
            // 
            lblKullanıcıSifre.AutoSize = true;
            lblKullanıcıSifre.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKullanıcıSifre.Location = new Point(327, 199);
            lblKullanıcıSifre.Name = "lblKullanıcıSifre";
            lblKullanıcıSifre.Size = new Size(41, 16);
            lblKullanıcıSifre.TabIndex = 27;
            lblKullanıcıSifre.Text = "Şifre :";
            // 
            // lblKullanıcıAd
            // 
            lblKullanıcıAd.AutoSize = true;
            lblKullanıcıAd.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblKullanıcıAd.Location = new Point(327, 123);
            lblKullanıcıAd.Name = "lblKullanıcıAd";
            lblKullanıcıAd.Size = new Size(49, 13);
            lblKullanıcıAd.TabIndex = 26;
            lblKullanıcıAd.Text = "E-posta :";
            // 
            // labelGirisYap
            // 
            labelGirisYap.AutoSize = true;
            labelGirisYap.BackColor = Color.White;
            labelGirisYap.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGirisYap.ForeColor = SystemColors.ActiveCaptionText;
            labelGirisYap.Location = new Point(327, 56);
            labelGirisYap.Name = "labelGirisYap";
            labelGirisYap.Size = new Size(156, 37);
            labelGirisYap.TabIndex = 23;
            labelGirisYap.Text = "Giriş Yap";
            labelGirisYap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chcBoxSifreGoster
            // 
            chcBoxSifreGoster.AutoSize = true;
            chcBoxSifreGoster.Cursor = Cursors.Hand;
            chcBoxSifreGoster.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chcBoxSifreGoster.Location = new Point(482, 275);
            chcBoxSifreGoster.Name = "chcBoxSifreGoster";
            chcBoxSifreGoster.Size = new Size(99, 19);
            chcBoxSifreGoster.TabIndex = 25;
            chcBoxSifreGoster.Text = "Şifreyi Göster";
            chcBoxSifreGoster.UseVisualStyleBackColor = true;
            chcBoxSifreGoster.CheckedChanged += chcBoxSifreGoster_CheckedChanged;
            // 
            // GirisYapBtn
            // 
            GirisYapBtn.BackColor = Color.FromArgb(175, 185, 255);
            GirisYapBtn.Cursor = Cursors.Hand;
            GirisYapBtn.FlatAppearance.BorderColor = Color.SlateBlue;
            GirisYapBtn.FlatAppearance.BorderSize = 0;
            GirisYapBtn.FlatAppearance.MouseDownBackColor = Color.SlateBlue;
            GirisYapBtn.FlatAppearance.MouseOverBackColor = Color.SlateBlue;
            GirisYapBtn.FlatStyle = FlatStyle.Flat;
            GirisYapBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            GirisYapBtn.ForeColor = SystemColors.ActiveCaptionText;
            GirisYapBtn.Location = new Point(327, 311);
            GirisYapBtn.Name = "GirisYapBtn";
            GirisYapBtn.Size = new Size(254, 39);
            GirisYapBtn.TabIndex = 24;
            GirisYapBtn.Text = "Giriş";
            GirisYapBtn.UseVisualStyleBackColor = false;
            GirisYapBtn.Click += GirisYapBtn_Click;
            // 
            // GirisPanel
            // 
            GirisPanel.BackColor = Color.FromArgb(155, 155, 255);
            GirisPanel.Controls.Add(label2);
            GirisPanel.Controls.Add(pictureBox1);
            GirisPanel.Controls.Add(btnKayıtOl);
            GirisPanel.Controls.Add(label1);
            GirisPanel.Location = new Point(12, 11);
            GirisPanel.Name = "GirisPanel";
            GirisPanel.Size = new Size(263, 405);
            GirisPanel.TabIndex = 58;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(31, 146);
            label1.Name = "label1";
            label1.Size = new Size(203, 19);
            label1.TabIndex = 1;
            label1.Text = "Personel Yönetim Sistemi\r\n";
            // 
            // elipseToolGirisForm
            // 
            elipseToolGirisForm.CornerRadius = 18;
            elipseToolGirisForm.TargetControl = this;
            // 
            // elipseToolpanel
            // 
            elipseToolpanel.CornerRadius = 18;
            elipseToolpanel.TargetControl = GirisPanel;
            // 
            // elipseToolkayıt
            // 
            elipseToolkayıt.CornerRadius = 15;
            elipseToolkayıt.TargetControl = btnKayıtOl;
            // 
            // elipseToolGirisyap
            // 
            elipseToolGirisyap.CornerRadius = 15;
            elipseToolGirisyap.TargetControl = GirisYapBtn;
            // 
            // ExitPicBox
            // 
            ExitPicBox.Image = FormUI.Resources.Resource1.reject;
            ExitPicBox.Location = new Point(584, 2);
            ExitPicBox.Name = "ExitPicBox";
            ExitPicBox.Size = new Size(22, 23);
            ExitPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            ExitPicBox.TabIndex = 61;
            ExitPicBox.TabStop = false;
            ExitPicBox.Click += ExitPicBox_Click;
            // 
            // EpostaTextbox
            // 
            EpostaTextbox.BorderThickness = 0;
            EpostaTextbox.CustomizableEdges = customizableEdges3;
            EpostaTextbox.DefaultText = "";
            EpostaTextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            EpostaTextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            EpostaTextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            EpostaTextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            EpostaTextbox.FillColor = Color.FromArgb(236, 235, 254);
            EpostaTextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            EpostaTextbox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            EpostaTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            EpostaTextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            EpostaTextbox.Location = new Point(327, 140);
            EpostaTextbox.Margin = new Padding(4);
            EpostaTextbox.Name = "EpostaTextbox";
            EpostaTextbox.PasswordChar = '\0';
            EpostaTextbox.PlaceholderText = "";
            EpostaTextbox.SelectedText = "";
            EpostaTextbox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            EpostaTextbox.Size = new Size(252, 43);
            EpostaTextbox.TabIndex = 62;
            // 
            // SifreTxtBox
            // 
            SifreTxtBox.BorderThickness = 0;
            SifreTxtBox.CustomizableEdges = customizableEdges1;
            SifreTxtBox.DefaultText = "";
            SifreTxtBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SifreTxtBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SifreTxtBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SifreTxtBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SifreTxtBox.FillColor = Color.FromArgb(236, 235, 254);
            SifreTxtBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            SifreTxtBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            SifreTxtBox.ForeColor = Color.FromArgb(64, 64, 64);
            SifreTxtBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            SifreTxtBox.Location = new Point(327, 219);
            SifreTxtBox.Margin = new Padding(4);
            SifreTxtBox.Name = "SifreTxtBox";
            SifreTxtBox.PasswordChar = '*';
            SifreTxtBox.PlaceholderText = "";
            SifreTxtBox.SelectedText = "";
            SifreTxtBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SifreTxtBox.Size = new Size(252, 47);
            SifreTxtBox.TabIndex = 63;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = EpostaTextbox;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.BorderRadius = 15;
            guna2Elipse2.TargetControl = SifreTxtBox;
            // 
            // GirisForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.White;
            ClientSize = new Size(609, 428);
            Controls.Add(SifreTxtBox);
            Controls.Add(EpostaTextbox);
            Controls.Add(ExitPicBox);
            Controls.Add(GirisPanel);
            Controls.Add(labelGirisYap);
            Controls.Add(lblKullanıcıSifre);
            Controls.Add(lblKullanıcıAd);
            Controls.Add(chcBoxSifreGoster);
            Controls.Add(GirisYapBtn);
            Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GirisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PYS";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GirisPanel.ResumeLayout(false);
            GirisPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ExitPicBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button btnKayıtOl;
        private Label label2;
        private Label lblKullanıcıSifre;
        private Label lblKullanıcıAd;
        private Label labelGirisYap;
        private CheckBox chcBoxSifreGoster;
        private Button GirisYapBtn;
        private Panel GirisPanel;
        private Label label1;
        private FormUI.ElipseTool elipseToolGirisForm;
        private FormUI.ElipseTool elipseToolpanel;
        private FormUI.ElipseTool elipseToolkayıt;
        private FormUI.ElipseTool elipseToolGirisyap;
        private PictureBox ExitPicBox;
        private Guna.UI2.WinForms.Guna2TextBox SifreTxtBox;
        private Guna.UI2.WinForms.Guna2TextBox EpostaTextbox;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}
