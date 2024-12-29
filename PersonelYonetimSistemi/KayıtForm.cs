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
        string connectionString = @"Server=DESKTOP-D8T97V8\SQLEXPRESS;Database=PersonelSistemiData;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public KayıtForm()
        {

            InitializeComponent();
            LoadDataAsync();
            KullanıcıAdtxtBox.TabIndex = 0;
            KullanıcıEpostaTxtBox.TabIndex = 1;
            KullanıcıSifreTxtBox.TabIndex = 2;

        }

        public async void LoadDataAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "Select * from Tbl_Kullanici";
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

                    MessageBox.Show(ex.Message, "Bağlantı Hatası :");
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
            KullanıcıSifreTxtBox.PasswordChar = SifreGosterChkBox.Checked ? '\0' : '*';
        }

        private void KayıtOlBtn_Click(object sender, EventArgs e)
        {

            //eposta düzen kontrolu
            string email = KullanıcıEpostaTxtBox.Text.Trim();
            string gmailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            string outlookPattern = @"^[a-zA-Z0-9._%+-]+@outlook\.com$";
            string hotmailPattern = @"^[a-zA-Z0-9._%+-]+@hotmail\.com$";
            string icloudPattern = @"^[a-zA-Z0-9._%+-]+@icloud\.com$";
            string examplePattern = @"^[a-zA-Z0-9._%+-]+@example\.com$";



            if (KullanıcıAdtxtBox.Text == ""
                || SifreGosterChkBox.Text == ""
                || KullanıcıEpostaTxtBox.Text == "")
            {
                MessageBox.Show("Lüften Boş Alanları Doldurun!", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //eposta düzen kontrolu
                if (!Regex.IsMatch(email, gmailPattern) && !Regex.IsMatch(email, outlookPattern) &&
            !Regex.IsMatch(email, hotmailPattern) && !Regex.IsMatch(email, icloudPattern)&&!Regex.IsMatch(email,examplePattern))
                {
                    MessageBox.Show("Geçersiz e-posta adresi ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    KullanıcıEpostaTxtBox.Focus();
                    return;

                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string selectUserQuery = "SELECT COUNT(KullaniciID) FROM Tbl_Kullanici WHERE Eposta = @Eposta";
                        using (SqlCommand checkUser = new SqlCommand(selectUserQuery, conn))
                        {

                            checkUser.Parameters.AddWithValue("@Eposta", KullanıcıEpostaTxtBox.Text.Trim());

                            int count = (int)checkUser.ExecuteScalar();
                            if (count >= 1)
                            {

                                MessageBox.Show("Bu e-posta ile kayıtlı bir kullanıcı zaten var!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                string insertUserQuery = "INSERT INTO Tbl_Kullanici (KullaniciAdi,Eposta,Sifre) VALUES (@Ad, @Eposta, @Sifre)";
                                using (SqlCommand command = new SqlCommand(insertUserQuery, conn))
                                {
                                    command.Parameters.AddWithValue("@Ad", KullanıcıAdtxtBox.Text.Trim());
                                    command.Parameters.AddWithValue("@Eposta", KullanıcıEpostaTxtBox.Text.Trim());
                                    command.Parameters.AddWithValue("@Sifre", KullanıcıSifreTxtBox.Text.Trim());


                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Başarıyla kayıt edildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    GirisForm form = new GirisForm();
                                    form.Show();
                                    this.Close();
                                }
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı hatası: " + ex.Message);
                    }
                 }
                 
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
            KayıtForm.ActiveForm.Close();
        }

        private void lblKullanıcıSifre_Click(object sender, EventArgs e)
        {

        }

        private void labelKayıtEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
