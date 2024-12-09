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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
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
            elipseToolEposta = new FormUI.ElipseTool();
            GirisEpostaTxtBox = new TextBox();
            elipseToolSifre = new FormUI.ElipseTool();
            GirisSifreTxtBox = new TextBox();
            elipseToolGirisyap = new FormUI.ElipseTool();
            EpostaPanel = new Panel();
            elipseEpostaPanel = new FormUI.ElipseTool();
            elipsSifrePanel = new FormUI.ElipseTool();
            SifrePanel = new Panel();
            textBox1 = new TextBox();
            ExitPicBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GirisPanel.SuspendLayout();
            EpostaPanel.SuspendLayout();
            SifrePanel.SuspendLayout();
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
            lblKullanıcıSifre.Location = new Point(327, 208);
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
            // elipseToolEposta
            // 
            elipseToolEposta.CornerRadius = 15;
            elipseToolEposta.TargetControl = GirisEpostaTxtBox;
            // 
            // GirisEpostaTxtBox
            // 
            GirisEpostaTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            GirisEpostaTxtBox.BackColor = Color.FromArgb(235, 235, 245);
            GirisEpostaTxtBox.BorderStyle = BorderStyle.None;
            GirisEpostaTxtBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            GirisEpostaTxtBox.Location = new Point(-1, 8);
            GirisEpostaTxtBox.MaxLength = 32;
            GirisEpostaTxtBox.Multiline = true;
            GirisEpostaTxtBox.Name = "GirisEpostaTxtBox";
            GirisEpostaTxtBox.Size = new Size(255, 27);
            GirisEpostaTxtBox.TabIndex = 52;
            // 
            // elipseToolSifre
            // 
            elipseToolSifre.CornerRadius = 15;
            elipseToolSifre.TargetControl = GirisSifreTxtBox;
            // 
            // GirisSifreTxtBox
            // 
            GirisSifreTxtBox.BackColor = Color.FromArgb(235, 235, 245);
            GirisSifreTxtBox.BorderStyle = BorderStyle.None;
            GirisSifreTxtBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            GirisSifreTxtBox.Location = new Point(-1, 8);
            GirisSifreTxtBox.MaxLength = 32;
            GirisSifreTxtBox.Multiline = true;
            GirisSifreTxtBox.Name = "GirisSifreTxtBox";
            GirisSifreTxtBox.PasswordChar = '*';
            GirisSifreTxtBox.Size = new Size(255, 27);
            GirisSifreTxtBox.TabIndex = 53;
            // 
            // elipseToolGirisyap
            // 
            elipseToolGirisyap.CornerRadius = 15;
            elipseToolGirisyap.TargetControl = GirisYapBtn;
            // 
            // EpostaPanel
            // 
            EpostaPanel.BackColor = Color.FromArgb(235, 235, 245);
            EpostaPanel.Controls.Add(GirisEpostaTxtBox);
            EpostaPanel.Location = new Point(327, 139);
            EpostaPanel.Name = "EpostaPanel";
            EpostaPanel.Size = new Size(254, 40);
            EpostaPanel.TabIndex = 59;
            // 
            // elipseEpostaPanel
            // 
            elipseEpostaPanel.CornerRadius = 15;
            elipseEpostaPanel.TargetControl = EpostaPanel;
            // 
            // elipsSifrePanel
            // 
            elipsSifrePanel.CornerRadius = 15;
            elipsSifrePanel.TargetControl = SifrePanel;
            // 
            // SifrePanel
            // 
            SifrePanel.BackColor = Color.FromArgb(235, 235, 245);
            SifrePanel.Controls.Add(textBox1);
            SifrePanel.Controls.Add(GirisSifreTxtBox);
            SifrePanel.Location = new Point(326, 227);
            SifrePanel.Name = "SifrePanel";
            SifrePanel.Size = new Size(254, 40);
            SifrePanel.TabIndex = 60;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.BackColor = Color.FromArgb(235, 235, 245);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(-1, 7);
            textBox1.MaxLength = 32;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 0);
            textBox1.TabIndex = 52;
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
            // GirisForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.White;
            ClientSize = new Size(609, 428);
            Controls.Add(ExitPicBox);
            Controls.Add(SifrePanel);
            Controls.Add(EpostaPanel);
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
            EpostaPanel.ResumeLayout(false);
            EpostaPanel.PerformLayout();
            SifrePanel.ResumeLayout(false);
            SifrePanel.PerformLayout();
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
        private FormUI.ElipseTool elipseToolEposta;
        private FormUI.ElipseTool elipseToolSifre;
        private FormUI.ElipseTool elipseToolGirisyap;
        private Panel SifrePanel;
        private TextBox textBox1;
        private Panel EpostaPanel;
        private TextBox GirisEpostaTxtBox;
        private TextBox GirisSifreTxtBox;
        private FormUI.ElipseTool elipseEpostaPanel;
        private FormUI.ElipseTool elipsSifrePanel;
        private PictureBox ExitPicBox;
    }
}
