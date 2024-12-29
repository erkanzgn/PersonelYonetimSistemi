using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms.VisualStyles;

namespace PersonelYonetimSistemi
{
    public partial class GirisForm : Form
    {
        string connectionString = @"Server=DESKTOP-D8T97V8\SQLEXPRESS;Database=PersonelSistemiData;TrustServerCertificate=True;";
         

        public GirisForm()
        {
            InitializeComponent();
        }

        private void btnKay�tOl_Click(object sender, EventArgs e)
        {

            Kay�tForm kay�tForm = new Kay�tForm();
            kay�tForm.Show();
            this.Hide();
        }

        private void chcBoxSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            SifreTxtBox.PasswordChar = chcBoxSifreGoster.Checked ? '\0' : '*';
        }


        private void GirisYapBtn_Click(object sender, EventArgs e)
        {
            //string email = EpostaTextbox.Text.Trim();
            //string sifre = SifreTxtBox.Text.Trim();

            //if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifre))
            //{
            //    MessageBox.Show("E-posta ve �ifre alanlar� bo� b�rak�lamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();

            //        // Kullan�c� bilgilerini sorgula
            //        string query = "SELECT KullaniciAd, Eposta , Sifre FROM Tbl_Kullanici WHERE Eposta = @Eposta AND Sifre = @Sifre" ;
            //        SqlCommand command = new SqlCommand(query, conn);
            //        command.Parameters.AddWithValue("@Email", email);
            //        command.Parameters.AddWithValue("@Sifre", sifre);

            //        SqlDataReader reader = command.ExecuteReader();

            //        if (reader.Read())
            //        {
            //            string kullan�c�Ad� = reader["KullaniciAdi"].ToString();
            //            string kullan�c�Email = reader["Eposta"].ToString();

            //            // Ana formu a�arken bilgileri g�nder
            //            Y�neticiMainForm anaForm = new Y�neticiMainForm(kullan�c�Ad�, kullan�c�Email);
            //            anaForm.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show("E-posta veya �ifre hatal�.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            Y�neticiMainForm mainForm = new Y�neticiMainForm();
            mainForm.Show();
            this.Hide();

        }


        private void GirisYap(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GirisYapBtn_Click(sender, e);
            }
        }

        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
