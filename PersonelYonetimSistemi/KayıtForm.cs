using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;


namespace PersonelYonetimSistemi
{
    public partial class KayıtForm : Form
    {
        string connectionString = @"Server=DESKTOP-VCCOBNG\SQLEXPRESS01;Database=PYS_Data;Trusted_Connection=True;";

        public KayıtForm()
        {

            InitializeComponent();
            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "Select * from users";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Tabloda veri bulunamadı!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Bağlantı Hatası :", ex.Message);
                }
            }
        }


        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisForm girisForm = new GirisForm();
            girisForm.Show();

            this.Close();
        }

        private void chcBoxSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            KayıtSifreTxtBox.PasswordChar = SifreGosterChkBox.Checked ? '\0' : '*';
        }

        private void KayıtOlBtn_Click(object sender, EventArgs e)
        {
            
            //eposta düzen kontrolu
            string email = KayıtEpostaTxtBox.Text.Trim();
            string gmailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            string outlookPattern = @"^[a-zA-Z0-9._%+-]+@outlook\.com$";
            string hotmailPattern = @"^[a-zA-Z0-9._%+-]+@hotmail\.com$";
            string icloudPattern = @"^[a-zA-Z0-9._%+-]+@icloud\.com$";



            if (KayıtKullanıcıAdıTxtBox.Text == ""
                || KullanıcıSoyadLbl.Text == ""
                || KayıtSifreTxtBox.Text == ""
                || KayıtEpostaTxtBox.Text == "")
            {
                MessageBox.Show("Lüften Boş Alanları Doldurun!", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //eposta düzen kontrolu
                if (!Regex.IsMatch(email, gmailPattern) && !Regex.IsMatch(email, outlookPattern) &&
            !Regex.IsMatch(email, hotmailPattern) && !Regex.IsMatch(email, icloudPattern))
                {
                    MessageBox.Show("Geçersiz e-posta adresi ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    KayıtEpostaTxtBox.Focus();
                    return;

                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string selectUserQuery = "SELECT COUNT(id) FROM users WHERE Email = @Email";
                        using (SqlCommand checkUser = new SqlCommand(selectUserQuery, conn))
                        {

                            checkUser.Parameters.AddWithValue("@Email", KayıtEpostaTxtBox.Text.Trim());

                            int count = (int)checkUser.ExecuteScalar();
                            if (count >= 1)
                            {

                                MessageBox.Show("Bu e-posta ile kayıtlı bir kullanıcı zaten var!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                string insertUserQuery = "INSERT INTO users (Ad, SoyAd, Email, Sifre) VALUES (@Ad, @SoyAd, @Email, @Sifre)";
                                using (SqlCommand command = new SqlCommand(insertUserQuery, conn))
                                {
                                    command.Parameters.AddWithValue("@Ad", KayıtKullanıcıAdıTxtBox.Text.Trim());
                                    command.Parameters.AddWithValue("@SoyAd", KullanıcıSoyAdTxtBox.Text.Trim());
                                    command.Parameters.AddWithValue("@Email", KayıtEpostaTxtBox.Text.Trim());
                                    command.Parameters.AddWithValue("@Sifre", KayıtSifreTxtBox.Text.Trim());


                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Başarıyla kayıt edildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    GirisForm form = new GirisForm();
                                    form.Show();
                                    this.Close();
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı hatası: " + ex.Message);
                    }
                }

            }

        }


        private void GirisYap(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGirisYap_Click(sender, e);
            }
        }

        private void KayıtKullanıcıAdıTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                KullanıcıSoyAdTxtBox.Focus();
            }
        }
        private void KullanıcıSoyAdTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                KayıtEpostaTxtBox.Focus();
            }
        }
        private void KayıtEpostaTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                KayıtSifreTxtBox.Focus();
            }
        }
        private void KayıtSifreTxtBox_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                KayıtOlBtn.Focus();
            }
        }

        private void KayıtSifreTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void KayıtForm_Load(object sender, EventArgs e)
        {

        }

        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
