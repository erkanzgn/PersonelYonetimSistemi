using Microsoft.Data.SqlClient;
using PersonelYonetimSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ManagerPersonelUserControl : UserControl
    {
        string connectionstring = @"Server=DESKTOP-D8T97V8\SQLEXPRESS;Database=PersonelSistemiData;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        public ManagerPersonelUserControl()
        {
            InitializeComponent();
            //DataGridView tıkalama
            PersonelDataGridView.CellClick += PersonelDataGridView_CellClick;
            //Arama TextBox
            PersonelAraTextBox.Text = "Personel Ara";
            PersonelAraTextBox.ForeColor = Color.Gray;
            PersonelAraTextBox.GotFocus += TextBox_GotFocus;
            PersonelAraTextBox.LostFocus += TextBox1_LostFocus;
            //Departman ComboBox
            TümKayıtlarıGetir();
            DataGridViewYenile();



        }
        int toplamKayitSayisi = 0;
        private void TümKayıtlarıGetir()
        {
            string query = "SELECT PersonelID, Ad, Soyad, Pozisyon, d.DepartmanAdi, Maas, Telefon, Eposta " +
                           "FROM Tbl_Personel p " +
                           "INNER JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    PersonelDataGridView.Rows.Clear();
                    while (reader.Read())
                    {
                        PersonelDataGridView.Rows.Add(
                            reader["PersonelID"].ToString(),
                            reader["Ad"].ToString(),
                            reader["Soyad"].ToString(),
                            reader["Pozisyon"].ToString(),
                            reader["DepartmanAdi"].ToString(),
                            reader["Maas"].ToString(),
                            reader["Telefon"].ToString(),
                            reader["Eposta"].ToString()
                        );
                        toplamKayitSayisi++;
                    }
                    reader.Close();

                    ToplamKayıtlbl.Text = "Toplam Kayıt Sayısı: " + toplamKayitSayisi;
                    DepartmanlarıYükle(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void DepartmanlarıYükle(SqlConnection connection)
        {
            string departmanQuery = "SELECT DepartmanAdi FROM Tbl_Departman";
            SqlCommand departmanCommand = new SqlCommand(departmanQuery, connection);
            SqlDataReader departmanReader = departmanCommand.ExecuteReader();
            DepartmanComboBox.Items.Clear();
            KullanıcıDepartmanCmbBox.Items.Clear();
            while (departmanReader.Read())
            {
                string departmanAdi = departmanReader["DepartmanAdi"].ToString();
                DepartmanComboBox.Items.Add(departmanAdi);
                KullanıcıDepartmanCmbBox.Items.Add(departmanAdi);
            }
            departmanReader.Close();
        }


        private bool BosTxtBoxKontrolu()
        {
            bool dolu = true;
            if (string.IsNullOrWhiteSpace(AdTxtBox.Text) ||
                string.IsNullOrWhiteSpace(SoyAdTxtBox.Text) ||
                string.IsNullOrWhiteSpace(PozisyonTxtBox.Text) ||
                string.IsNullOrWhiteSpace(KullanıcıDepartmanCmbBox.Text) ||
                MaasNumericUpDown.Value == 0) { dolu = false; }
            return dolu;
        }

        private void ComboBox1_GotFocus(object sender, EventArgs e)
        {
            if (DepartmanComboBox.Text == "Departman seçin..." && DepartmanComboBox.ForeColor == Color.Gray)
            {
                DepartmanComboBox.Text = "";
                DepartmanComboBox.ForeColor = Color.Black;
            }
        }

        private void PersonelDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = PersonelDataGridView.Rows[e.RowIndex];

                    AdTxtBox.Text = row.Cells["Ad"].Value?.ToString() ?? string.Empty;
                    SoyAdTxtBox.Text = row.Cells["Soyad"].Value?.ToString() ?? string.Empty;
                    PozisyonTxtBox.Text = row.Cells["Pozisyon"].Value?.ToString() ?? string.Empty;
                    TelefonTxtbox.Text = row.Cells["Telefon"].Value?.ToString() ?? string.Empty;
                    EpostaTxtBox.Text = row.Cells["Eposta"].Value?.ToString() ?? string.Empty;
                    KullanıcıDepartmanCmbBox.Text = row.Cells["DepartmanAdi"].Value?.ToString() ?? string.Empty;
                    if (decimal.TryParse(row.Cells["Maas"].Value?.ToString(), out decimal maas))
                    {
                        MaasNumericUpDown.Value = maas;
                    }
                    else
                    {
                        MaasNumericUpDown.Value = 0;
                    }
                    if (bool.TryParse(row.Cells["Aktif"].Value?.ToString(), out bool aktif))
                    {
                        AktifChcBox.Checked = aktif;
                    }
                    else
                    {
                        AktifChcBox.Checked = false;
                    }
                    SetRadioButtonYetki(row.Cells["Yetki"].Value?.ToString() ?? string.Empty);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewYenile()
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT PersonelID, Ad, Soyad, Pozisyon, d.DepartmanAdi, Maas, Telefon, Eposta, Aktif " +
                                   "FROM Tbl_Personel p " +
                                   "INNER JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    PersonelDataGridView.DataSource = dataTable;
                    PersonelDataGridView.Columns["PersonelID"].HeaderText = "ID";
                    PersonelDataGridView.Columns["Ad"].HeaderText = "Ad";
                    PersonelDataGridView.Columns["Soyad"].HeaderText = "Soyad";
                    PersonelDataGridView.Columns["Pozisyon"].HeaderText = "Pozisyon";
                    PersonelDataGridView.Columns["DepartmanAdi"].HeaderText = "Departman";
                    PersonelDataGridView.Columns["Maas"].HeaderText = "Maaş";
                    PersonelDataGridView.Columns["Telefon"].HeaderText = "Telefon";
                    PersonelDataGridView.Columns["Eposta"].HeaderText = "Eposta";

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void ComboBox1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DepartmanComboBox.Text))
            {
                DepartmanComboBox.Text = "Departman seçin...";
                DepartmanComboBox.ForeColor = Color.Gray;
            }
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (PersonelAraTextBox.Text == "Personel Ara" && PersonelAraTextBox.ForeColor == Color.Gray)
            {
                PersonelAraTextBox.Text = "";
                PersonelAraTextBox.ForeColor = Color.Black;
            }
        }
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PersonelAraTextBox.Text))
            {
                PersonelAraTextBox.Text = "Personel Ara";
                PersonelAraTextBox.ForeColor = Color.Gray;
            }
        }


        private void TelefonTxtbox_TextChanged(object sender, EventArgs e)
        {
            string input = TelefonTxtbox.Text;
            if (input.Length > 11 || !input.All(char.IsNumber))
            {
                TelefonTxtbox.Text = input.Substring(0, Math.Min(11, input.Length));
                TelefonTxtbox.SelectionStart = TelefonTxtbox.Text.Length;
            }
        }



        private void SetRadioButtonYetki(string role)
        {
            if (role == "Yönetici")
            {
                YetkiliRadioButon.Checked = true;
            }
            else if (role == "Personel")
            {
                PersonelRadioButon.Checked = true;
            }
        }

        private void ManagerPYUserControl_Load(object sender, EventArgs e)
        {

        }

        private void AraBtn_Click_1(object sender, EventArgs e)
        {
            string adSoyad = PersonelAraTextBox.Text.Trim();
            string[] adSoyadArray = adSoyad.Split(' ');
            string ad = adSoyadArray.Length > 0 ? adSoyadArray[0] : "";
            string soyad = adSoyadArray.Length > 1 ? adSoyadArray[1] : "";
            string departman = DepartmanComboBox.SelectedItem?.ToString();

            string query = "SELECT PersonelID, Ad, Soyad, Pozisyon, Maas, Eposta, Telefon, d.DepartmanAdi, p.Aktif " +
                           "FROM Tbl_Personel p " +
                           "INNER JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID " +
                           "WHERE p.Ad LIKE @Ad AND p.Soyad LIKE @Soyad";

            if (!string.IsNullOrEmpty(departman))
            {
                query += " AND d.DepartmanAdi = @Departman";
            }

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ad", "%" + ad + "%");
                    command.Parameters.AddWithValue("@Soyad", "%" + soyad + "%");

                    if (!string.IsNullOrEmpty(departman))
                    {
                        command.Parameters.AddWithValue("@Departman", departman);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'in veri kaynağını ayarla
                    PersonelDataGridView.DataSource = dataTable;

                    // DataGridView ayarları
                    PersonelDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    PersonelDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    //PersonelDataGridView.DefaultCellStyle.IsNullValueDefault = DataGridViewTriState.True;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }




        private void TemizleBtn_Click_1(object sender, EventArgs e)
        {
            AdTxtBox.Text = "";
            SoyAdTxtBox.Text = "";
            PozisyonTxtBox.Text = "";
            KullanıcıDepartmanCmbBox.Text = "";
            TelefonTxtbox.Text = "";
            EpostaTxtBox.Text = "";
            MaasNumericUpDown.Value = 0;
            AktifChcBox.Checked = false;
            PersonelAraTextBox.Text = "Personel Ara";
            PersonelAraTextBox.ForeColor = Color.Gray;
            PersonelAraTextBox.GotFocus += TextBox_GotFocus;
            PersonelAraTextBox.LostFocus += TextBox1_LostFocus;
        }

        private void AdTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GuncelleBtn_Click_1(object sender, EventArgs e)
        {
            if (PersonelDataGridView.SelectedRows.Count > 0)
            {
                int personelID = Convert.ToInt32(PersonelDataGridView.SelectedRows[0].Cells["PersonelID"].Value);
                string ad = AdTxtBox.Text;
                string soyad = SoyAdTxtBox.Text;
                string pozisyon = PozisyonTxtBox.Text;
                string departman = KullanıcıDepartmanCmbBox.Text;
                decimal maas = Convert.ToDecimal(MaasNumericUpDown.Value);
                string email = EpostaTxtBox.Text;
                bool aktif = AktifChcBox.Checked;

                string yetki = "";
                if (YetkiliRadioButon.Checked)
                {
                    yetki = "Yönetici";
                }
                else if (PersonelRadioButon.Checked)
                {
                    yetki = "Personel";
                }

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        string query = "UPDATE Tbl_Personel " +
                                       "SET Ad = @Ad, Soyad = @Soyad, Pozisyon = @Pozisyon, " +
                                       "DepartmanID = (SELECT DepartmanID FROM Tbl_Departman WHERE DepartmanAdi = @DepartmanAdi), " +
                                       "Maas = @Maas, Eposta = @Eposta, Aktif = @Aktif " +
                                       "WHERE PersonelID = @PersonelID; " +
                                       "UPDATE Tbl_Kullanici " +
                                       "SET Eposta = @Eposta, Yetki = @Yetki " +
                                       "WHERE PersonelID = @PersonelID";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PersonelID", personelID);
                            command.Parameters.AddWithValue("@Ad", ad);
                            command.Parameters.AddWithValue("@Soyad", soyad);
                            command.Parameters.AddWithValue("@Pozisyon", pozisyon);
                            command.Parameters.AddWithValue("@DepartmanAdi", departman);
                            command.Parameters.AddWithValue("@Maas", maas);
                            command.Parameters.AddWithValue("@Eposta", email);
                            command.Parameters.AddWithValue("@Aktif", aktif);
                            command.Parameters.AddWithValue("@Yetki", yetki);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Personel ve kullanıcı bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewYenile();
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Güncellemek için bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void Kaydet_Click_1(object sender, EventArgs e)
        {
            if (BosTxtBoxKontrolu())
            {
                string ad = AdTxtBox.Text;
                string soyAd = SoyAdTxtBox.Text;
                string pozisyon = PozisyonTxtBox.Text;
                string departman = KullanıcıDepartmanCmbBox.Text;
                string telefon = TelefonTxtbox.Text;
                string eposta = EpostaTxtBox.Text;
                decimal maas = Convert.ToDecimal(MaasNumericUpDown.Value);
                bool aktif = AktifChcBox.Checked;
                string yetki = YetkiliRadioButon.Checked ? "Yönetici" : "Personel";

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    try
                    {
                        connection.Open();

                        string checkUserQuery = "SELECT COUNT(*) FROM Tbl_Kullanici WHERE Eposta=@Eposta";
                        using (SqlCommand cmd = new SqlCommand(checkUserQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Eposta", eposta);
                            int userCount = (int)cmd.ExecuteScalar();
                            if (userCount == 0)
                            {
                                MessageBox.Show("Bu personel kullanıcılar tablosunda kayıtlı değil\n Lütfen Kayıt Oluşturun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                KayıtForm kayıtForm = new KayıtForm();
                                kayıtForm.ShowDialog();

                                string getUserIdQuery1 = "SELECT KullaniciID FROM Tbl_Kullanici WHERE Eposta=@Eposta";
                                using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery1, connection))
                                {
                                    getUserIdCmd.Parameters.AddWithValue("@Eposta", eposta);
                                    object Userresult = getUserIdCmd.ExecuteScalar();
                                    if (Userresult == null)
                                    {
                                        MessageBox.Show("Kullanıcı kaydı oluşturulamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }

                        string getUserIdQuery = "SELECT KullaniciID FROM Tbl_Kullanici WHERE Eposta=@Eposta";
                        using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, connection))
                        {
                            getUserIdCmd.Parameters.AddWithValue("@Eposta", eposta);
                            int kullaniciID = (int)getUserIdCmd.ExecuteScalar();

                            string query = "INSERT INTO Tbl_Personel (Ad, Soyad, DepartmanID, Pozisyon, Maas, Aktif, Telefon, Eposta, KullaniciID,BaslamaTarihi) " +
                                           "VALUES (@Ad, @Soyad, (SELECT DepartmanID FROM Tbl_Departman WHERE DepartmanAdi = @DepartmanAdi), @Pozisyon, @Maas, @Aktif, @Telefon, @Eposta, @KullaniciID,GETDATE())";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Ad", ad);
                                command.Parameters.AddWithValue("@Soyad", soyAd);
                                command.Parameters.AddWithValue("@Pozisyon", pozisyon);
                                command.Parameters.AddWithValue("@DepartmanAdi", departman);
                                command.Parameters.AddWithValue("@Maas", maas);
                                command.Parameters.AddWithValue("@Telefon", telefon);
                                command.Parameters.AddWithValue("@Eposta", eposta);
                                command.Parameters.AddWithValue("@Aktif", aktif);
                                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    MessageBox.Show("Personel Başarıyla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ekleme İşlemi Başarısız oldu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            string kullaniciQuery = "INSERT INTO Tbl_Kullanici (Yetki) VALUES (@Yetki); SELECT SCOPE_IDENTITY();";

                            using (SqlCommand kullaniciCommand = new SqlCommand(kullaniciQuery, connection))
                            {
                                kullaniciCommand.Parameters.AddWithValue("@Yetki", yetki);
                                kullaniciID = Convert.ToInt32(kullaniciCommand.ExecuteScalar());
                            }
                        }

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void SilBtn_Click_1(object sender, EventArgs e)
        {
            if (PersonelDataGridView.SelectedRows.Count > 0)
            {
                int personelID = Convert.ToInt32(PersonelDataGridView.SelectedRows[0].Cells["PersonelID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        // Personel tablosundan silme işlemi
                        string deletePersonelQuery = "DELETE FROM Tbl_Personel WHERE PersonelID = @PersonelID";
                        using (SqlCommand command = new SqlCommand(deletePersonelQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PersonelID", personelID);
                            command.ExecuteNonQuery();
                        }

                        // Kullanici tablosundan silme işlemi
                        string deleteKullaniciQuery = "DELETE FROM Tbl_Kullanici WHERE PersonelID = @PersonelID";
                        using (SqlCommand command = new SqlCommand(deleteKullaniciQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PersonelID", personelID);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Personel ve kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewYenile();
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void PersonelDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridWieviYenile_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT PersonelID, Ad, Soyad, Pozisyon, d.DepartmanAdi, Maas, Telefon, Eposta, Aktif " +
                                   "FROM Tbl_Personel p " +
                                   "INNER JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    PersonelDataGridView.DataSource = dataTable;
                    PersonelDataGridView.Columns["PersonelID"].HeaderText = "ID";
                    PersonelDataGridView.Columns["Ad"].HeaderText = "Ad";
                    PersonelDataGridView.Columns["Soyad"].HeaderText = "Soyad";
                    PersonelDataGridView.Columns["Pozisyon"].HeaderText = "Pozisyon";
                    PersonelDataGridView.Columns["DepartmanAdi"].HeaderText = "Departman";
                    PersonelDataGridView.Columns["Maas"].HeaderText = "Maaş";
                    PersonelDataGridView.Columns["Telefon"].HeaderText = "Telefon";
                    PersonelDataGridView.Columns["Eposta"].HeaderText = "Eposta";
                    PersonelDataGridView.Columns["Aktif"].HeaderText = "Aktif";

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

