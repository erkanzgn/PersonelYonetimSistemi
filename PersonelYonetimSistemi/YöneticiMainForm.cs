using FormUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelYonetimSistemi
{
    public partial class YöneticiMainForm : Form
    {
        private string kullanıcıAdı;
        private string kullanıcıEmail;

        public YöneticiMainForm()
        {
            InitializeComponent();

        }
        public YöneticiMainForm(string ad, string email)
        {
            InitializeComponent();
            kullanıcıAdı = ad;
            kullanıcıEmail = email;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //KullanıcıAdLbl.Text=kullanıcıAdı.ToString();
            //EpostaLbl.Text=kullanıcıEmail.ToString();
            //WelcomeLabel.Text = ZamanKontrolu();
        }

        private void ShowUserControl(UserControl userControl)
        {
            managerPerfUserControl1.Visible = false;
            managerPersonelUserControl1.Visible = false;

            userControl.Visible = true;
        }
        private void CloseUserControl(UserControl userControl)
        {
            userControl.Visible = false;

        }

        private string ZamanKontrolu()
        {
            DateTime simdikiZaman = DateTime.Now;
            int saat = simdikiZaman.Hour;

            if (saat >= 5 && saat < 12)
            {
                return $"Günaydın! {kullanıcıAdı}";
            }
            else if (saat >= 12 && saat < 18)
            {
                return $"İyi günler! {kullanıcıAdı}";
            }
            else if (saat >= 18 && saat < 24)
            {
                return $"İyi akşamlar! {kullanıcıAdı}";
            }
            else
            {
                return $"İyi geceler! {kullanıcıAdı}";
            }
        }

        private void PersonelYonetimBtn_Click(object sender, EventArgs e)
        {
            ShowUserControl(managerPersonelUserControl1);
        }

        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimzedLbl_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PerformansBtn_Click(object sender, EventArgs e)
        {
            ShowUserControl(managerPerfUserControl1);
        }

        private void AnaPanelSol_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managerPersonelUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void managerPerfUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void izinveMesaiBtn_Click(object sender, EventArgs e)
        {
            ShowUserControl(managerIzinUserControl1);
        }
    }
}

