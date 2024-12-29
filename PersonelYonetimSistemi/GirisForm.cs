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

        private void btnKayýtOl_Click(object sender, EventArgs e)
        {

            KayýtForm kayýtForm = new KayýtForm();
            kayýtForm.Show();
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
            //    MessageBox.Show("E-posta ve þifre alanlarý boþ býrakýlamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();

            //        // Kullanýcý bilgilerini sorgula
            //        string query = "SELECT KullaniciAd, Eposta , Sifre FROM Tbl_Kullanici WHERE Eposta = @Eposta AND Sifre = @Sifre" ;
            //        SqlCommand command = new SqlCommand(query, conn);
            //        command.Parameters.AddWithValue("@Email", email);
            //        command.Parameters.AddWithValue("@Sifre", sifre);

            //        SqlDataReader reader = command.ExecuteReader();

            //        if (reader.Read())
            //        {
            //            string kullanýcýAdý = reader["KullaniciAdi"].ToString();
            //            string kullanýcýEmail = reader["Eposta"].ToString();

            //            // Ana formu açarken bilgileri gönder
            //            YöneticiMainForm anaForm = new YöneticiMainForm(kullanýcýAdý, kullanýcýEmail);
            //            anaForm.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show("E-posta veya þifre hatalý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            YöneticiMainForm mainForm = new YöneticiMainForm();
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
