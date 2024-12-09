using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms.VisualStyles;

namespace PersonelYonetimSistemi
{
    public partial class GirisForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PYSData;Trusted_Connection=True;";

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
            GirisSifreTxtBox.PasswordChar = chcBoxSifreGoster.Checked ? '\0' : '*';
        }


        private void GirisYapBtn_Click(object sender, EventArgs e)
        {
            //string email = GirisEpostaTxtBox.Text.Trim();
            //string sifre = GirisSifreTxtBox.Text.Trim();

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
            //        string query = "SELECT Ad, Email FROM Users WHERE Email = @Email AND Sifre = @Sifre";
            //        SqlCommand command = new SqlCommand(query, conn);
            //        command.Parameters.AddWithValue("@Email", email);
            //        command.Parameters.AddWithValue("@Sifre", sifre);

            //        SqlDataReader reader = command.ExecuteReader();

            //        if (reader.Read())
            //        {
            //            string kullan�c�Ad� = reader["Ad"].ToString();
            //            string kullan�c�Email = reader["Email"].ToString();

            //            // Ana formu a�arken bilgileri g�nder
            //            MainForm anaForm = new MainForm(kullan�c�Ad�, kullan�c�Email);
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
