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
        }

        private void ShowUserControl(UserControl userControl)
        {
            // userControlPersonel1.Visible = false;

            userControl.Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //PersonelYönetimiForm personel = new PersonelYönetimiForm();
            //personel.Show();
            //this.Hide();

            // ShowUserControl(userControlPersonel1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void İzinYönetPanel_Click(object sender, EventArgs e)
        {

        }

        private void Raporlamalbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void RaporlamaButonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GotoBackPicBox_Click(object sender, EventArgs e)
        {

        }

        private void PerformansPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}

