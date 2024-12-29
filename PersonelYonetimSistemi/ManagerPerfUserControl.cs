using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace FormUI
{
    public partial class ManagerPerfUserControl : UserControl
    {
        string connectionstring = @"Server=DESKTOP-D8T97V8\SQLEXPRESS;Database=PersonelSistemiData;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        private DataRow personel1;
        private DataRow personel2;

        public ManagerPerfUserControl()
        {
            InitializeComponent();
            DataGridViewYenile();

            PersonelDataGridWiew.MultiSelect = true;
            PersonelDataGridWiew.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void KarsilastirBtn_Click(object sender, EventArgs e)
        {
            if (personel1 != null && personel2 != null)
            {
                KarsılastırmaForm karsılastırmaForm = new KarsılastırmaForm(personel1, personel2);
                karsılastırmaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen iki personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void YenileBtn_Click(object sender, EventArgs e)
        {
            DataGridViewYenile();
        }

        private void DataGridViewYenile()
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT p.PersonelID, p.Ad, p.Soyad, p.Eposta, p.Pozisyon, d.DepartmanAdi, " +
                                   "ISNULL(pr.Verimlilik, 0) AS Verimlilik, ISNULL(pr.Isbirligi, 0) AS Isbirligi, ISNULL(pr.ProjeTamamlama, 0) AS ProjeTamamlama " +
                                   "FROM Tbl_Personel p " +
                                   "LEFT JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID " +
                                   "LEFT JOIN Tbl_Performans pr ON p.PersonelID = pr.PersonelID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataTable.Columns.Add("GenelPuan", typeof(decimal));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int verimlilik = Convert.ToInt16(row["Verimlilik"]);
                        int isbirligi = Convert.ToInt16(row["Isbirligi"]);
                        int projeTamamlama = Convert.ToInt16(row["ProjeTamamlama"]);
                        int genelPuan = (verimlilik + isbirligi + projeTamamlama) / 3;
                        row["GenelPuan"] = genelPuan;
                    }

                    PersonelDataGridWiew.DataSource = dataTable;
                    PersonelDataGridWiew.Columns["PersonelID"].Visible = false;
                    PersonelDataGridWiew.Columns["Ad"].HeaderText = "Ad";
                    PersonelDataGridWiew.Columns["Soyad"].HeaderText = "Soyad";
                    PersonelDataGridWiew.Columns["DepartmanAdi"].HeaderText = "Departman";
                    PersonelDataGridWiew.Columns["Pozisyon"].HeaderText = "Pozisyon";
                    PersonelDataGridWiew.Columns["Verimlilik"].Visible = false;
                    PersonelDataGridWiew.Columns["Isbirligi"].Visible = false;
                    PersonelDataGridWiew.Columns["ProjeTamamlama"].Visible = false;
                    PersonelDataGridWiew.Columns["GenelPuan"].Visible = false;
                    PersonelDataGridWiew.Columns["Eposta"].Visible = false;

                    DepartmanlarıYükle(connection);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                PersonelSıralama((DataTable)PersonelDataGridWiew.DataSource);
                DepartmanPerformansSiralama((DataTable)PersonelDataGridWiew.DataSource);
            }
        }

        private void AraButton_Click(object sender, EventArgs e)
        {
            string adSoyad = PersonelAraTxtBox.Text.Trim();
            string[] adSoyadArray = adSoyad.Split(' ');
            string ad = adSoyadArray.Length > 0 ? adSoyadArray[0] : "";
            string soyad = adSoyadArray.Length > 1 ? adSoyadArray[1] : "";
            string departman = departmanComboBox.SelectedItem?.ToString();

            string query = "SELECT p.PersonelID, p.Ad, p.Soyad, p.Eposta, p.Pozisyon, d.DepartmanAdi, " +
                           "ISNULL(pr.Verimlilik, 0) AS Verimlilik, ISNULL(pr.Isbirligi, 0) AS Isbirligi, ISNULL(pr.ProjeTamamlama, 0) AS ProjeTamamlama " +
                           "FROM Tbl_Personel p " +
                           "LEFT JOIN Tbl_Departman d ON p.DepartmanID = d.DepartmanID " +
                           "LEFT JOIN Tbl_Performans pr ON p.PersonelID = pr.PersonelID " +
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

                    dataTable.Columns.Add("GenelPuan", typeof(decimal));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int verimlilik = Convert.ToInt16(row["Verimlilik"]);
                        int isbirligi = Convert.ToInt16(row["Isbirligi"]);
                        int projeTamamlama = Convert.ToInt16(row["ProjeTamamlama"]);
                        int genelPuan = (verimlilik + isbirligi + projeTamamlama) / 3;
                        row["GenelPuan"] = genelPuan;
                    }

                    PersonelDataGridWiew.DataSource = dataTable;
                    PersonelDataGridWiew.Columns["PersonelID"].Visible = false;
                    PersonelDataGridWiew.Columns["Ad"].HeaderText = "Ad";
                    PersonelDataGridWiew.Columns["Soyad"].HeaderText = "Soyad";
                    PersonelDataGridWiew.Columns["DepartmanAdi"].Visible = false;
                    PersonelDataGridWiew.Columns["Verimlilik"].HeaderText = "Verimlilik";
                    PersonelDataGridWiew.Columns["Isbirligi"].HeaderText = "İşbirliği";
                    PersonelDataGridWiew.Columns["ProjeTamamlama"].HeaderText = "Proje Tamamlama";
                    PersonelDataGridWiew.Columns["GenelPuan"].HeaderText = "Genel Puan";

                    connection.Close();
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
            departmanComboBox.Items.Clear();

            while (departmanReader.Read())
            {
                string departmanAdi = departmanReader["DepartmanAdi"].ToString();
                departmanComboBox.Items.Add(departmanAdi);
            }
            departmanReader.Close();
        }

        private void PersonelDataGridWiew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = PersonelDataGridWiew.Rows[e.RowIndex];

                    VerimlilikTxtBox.Text = row.Cells["Verimlilik"].Value?.ToString() ?? string.Empty;
                    IsbirligiTxtBox.Text = row.Cells["Isbirligi"].Value?.ToString() ?? string.Empty;
                    ProjeTamamlamaTxtBox.Text = row.Cells["ProjeTamamlama"].Value?.ToString() ?? string.Empty;
                    // Ad ve Soyad'ı birleştirerek SecilenPersonelAd etiketine atayın
                    string ad = row.Cells["Ad"].Value?.ToString() ?? string.Empty;
                    string soyad = row.Cells["Soyad"].Value?.ToString() ?? string.Empty;
                    SecilenPersonelAd.Text = $"{ad} {soyad}";

                    SecilenPersonelEpostaLbl.Text = row.Cells["Eposta"].Value?.ToString() ?? string.Empty;

                    int genelPuan = Convert.ToInt32(row.Cells["GenelPuan"].Value);
                    GenelPuanProcessingBar.Value = genelPuan;

                    int verimlilik = Convert.ToInt32(row.Cells["Verimlilik"].Value);
                    VerimlilikProcessingBar.Value = verimlilik;

                    int isbirligi = Convert.ToInt32(row.Cells["Isbirligi"].Value);
                    IsbirligiProcessingBar.Value = isbirligi;

                    int projeTamamlama = Convert.ToInt32(row.Cells["ProjeTamamlama"].Value);
                    ProjeProcessingBar.Value = projeTamamlama;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PerformansEkleBtn_Click(object sender, EventArgs e)
        {
            if (PersonelDataGridWiew.SelectedRows.Count > 0)
            {
                int personelID = Convert.ToInt32(PersonelDataGridWiew.SelectedRows[0].Cells["PersonelID"].Value);
                int verimlilik = Convert.ToInt32(VerimlilikTxtBox.Text);
                int isbirligi = Convert.ToInt32(IsbirligiTxtBox.Text);
                int projeTamamlama = Convert.ToInt32(ProjeTamamlamaTxtBox.Text);

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    try
                    {
                        connection.Open();

                        string query = "INSERT INTO Tbl_Performans (PersonelID, Verimlilik, Isbirligi, ProjeTamamlama ,DegerlendirmeTarihi) " +
                                       "VALUES (@PersonelID, @Verimlilik, @Isbirligi, @ProjeTamamlama ,GETDATE())";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PersonelID", personelID);
                        command.Parameters.AddWithValue("@Verimlilik", verimlilik);
                        command.Parameters.AddWithValue("@Isbirligi", isbirligi);
                        command.Parameters.AddWithValue("@ProjeTamamlama", projeTamamlama);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Performans bilgileri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewYenile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PerformansGüncelleBtn_Click(object sender, EventArgs e)
        {
            if (PersonelDataGridWiew.SelectedRows.Count > 0)
            {
                int personelID = Convert.ToInt32(PersonelDataGridWiew.SelectedRows[0].Cells["PersonelID"].Value);
                int verimlilik = Convert.ToInt32(VerimlilikTxtBox.Text);
                int isbirligi = Convert.ToInt32(IsbirligiTxtBox.Text);
                int projeTamamlama = Convert.ToInt32(ProjeTamamlamaTxtBox.Text);

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    try
                    {
                        connection.Open();

                        string query = "UPDATE Tbl_Performans SET Verimlilik = @Verimlilik, Isbirligi = @Isbirligi, ProjeTamamlama = @ProjeTamamlama " +
                                       "WHERE PersonelID = @PersonelID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PersonelID", personelID);
                        command.Parameters.AddWithValue("@Verimlilik", verimlilik);
                        command.Parameters.AddWithValue("@Isbirligi", isbirligi);
                        command.Parameters.AddWithValue("@ProjeTamamlama", projeTamamlama);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Performans bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewYenile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PerformansSilBtn_Click(object sender, EventArgs e)
        {
            if (PersonelDataGridWiew.SelectedRows.Count > 0)
            {
                int personelID = Convert.ToInt32(PersonelDataGridWiew.SelectedRows[0].Cells["PersonelID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM Tbl_Performans WHERE PersonelID = @PersonelID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PersonelID", personelID);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Performans bilgileri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewYenile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CokluSecBtn_Click(object sender, EventArgs e)
        {
            PersonelDataGridWiew.SelectionChanged += PersonelDataGridWiew_SelectionChanged;
        }

        private void PersonelDataGridWiew_SelectionChanged(object sender, EventArgs e)
        {
            if (PersonelDataGridWiew.SelectedRows.Count == 2)
            {
                var result = MessageBox.Show("İki Kullanıcı seçildi, Karşılaştırma Ekranına Gitmek İstermisiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    personel1 = ((DataRowView)PersonelDataGridWiew.SelectedRows[0].DataBoundItem).Row;
                    personel2 = ((DataRowView)PersonelDataGridWiew.SelectedRows[1].DataBoundItem).Row;
                    KarsilastirBtn_Click(sender, e);
                }
            }
            if (PersonelDataGridWiew.SelectedRows.Count > 2)
            {
                MessageBox.Show("Sadece iki personel seçebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PersonelDataGridWiew.ClearSelection();
            }
        }

        private void PersonelSıralama(DataTable dataTable)
        {
            var sortedRows = dataTable.AsEnumerable()
                                      .OrderByDescending(row => row.Field<decimal>("GenelPuan"))
                                      .Take(3)
                                      .ToList();

            if (sortedRows.Count > 0)
            {
                BirinciPersonelLbl.Text = $"{sortedRows[0]["Ad"]} {sortedRows[0]["Soyad"]}";
                //BirinciPersonelPicBox.Image = GetPersonelImage(sortedRows[0]["PersonelID"]);
            }

            if (sortedRows.Count > 1)
            {
                IkinciPersonelLbl.Text = $"{sortedRows[1]["Ad"]} {sortedRows[1]["Soyad"]}";
                //IkınciPersonelPicBox.Image = GetPersonelImage(sortedRows[1]["PersonelID"]);
            }

            if (sortedRows.Count > 2)
            {
                UcuncuPersonelLbl.Text = $"{sortedRows[2]["Ad"]} {sortedRows[2]["Soyad"]}";
                //UcuncuPersonelPicBox.Image = GetPersonelImage(sortedRows[2]["PersonelID"]);
            }
        }

        //private Image GetPersonelImage(object personelID)
        //{
        //    // Personel resmini veritabanından veya dosya sisteminden yükleyin
        //    // Bu örnekte, varsayılan bir resim döndürülüyor
        //    //return Properties.Resources.DefaultPersonelImage;
        //}
        private void DepartmanPerformansSiralama(DataTable dataTable)
        {

            var departmanPuanlari = new Dictionary<string, List<decimal>>();

            foreach (DataRow row in dataTable.Rows)
            {
                string departmanAdi = row["DepartmanAdi"].ToString();
                decimal genelPuan = row.Field<decimal>("GenelPuan");

                if (!departmanPuanlari.ContainsKey(departmanAdi))
                {
                    departmanPuanlari[departmanAdi] = new List<decimal>();
                }

                departmanPuanlari[departmanAdi].Add(genelPuan);
            }

            foreach (var departman in departmanPuanlari)
            {
                string departmanAdi = departman.Key;
                List<decimal> puanlar = departman.Value;
                decimal ortalamaPuan = puanlar.Average();


                switch (departmanAdi)
                {
                    case "Bilgi Teknolojileri":
                        BilgiTeknoProccesBar.Value = (int)ortalamaPuan;
                        Departman1lbl.Text = $"{departmanAdi}";
                        break;
                    case "Insan Kaynaklari":
                        InsanKaynProcessingBar.Value = (int)ortalamaPuan;
                        Departman2lbl.Text = $"{departmanAdi}";
                        break;
                    case "Finans":
                        FinansProccesBar.Value = (int)ortalamaPuan;
                        Departman3lbl.Text = $"{departmanAdi}";
                        break;
                    case "Pazarlama":
                        PazarlamaProcessingBar.Value = (int)ortalamaPuan;
                        Departman4lbl.Text = $"{departmanAdi}";
                        break;
                    case "Veri Bilimi":
                        VeriBilimiProcesingBar.Value = (int)ortalamaPuan;
                        Departman5lbl.Text = $"{departmanAdi}";
                        break;
                    case "Proje Yönetimi":
                        ProjeYonetimProcssingBar.Value = (int)ortalamaPuan;
                        Departman6lbl.Text = $"{departmanAdi}";
                        break;
                    default:
                        break;
                }
          
            }
        }

        private void IsbirligiTxtBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void IsbirligiTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSadeceSayi_KeyPress(sender, e);
        }
        private void txtSadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void VerimlilikTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSadeceSayi_KeyPress(sender, e);
        }

        private void ProjeTamamlamaTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSadeceSayi_KeyPress(sender, e);
        }


        private void YaziyiDikeyFormattaYaz(Label label, string metin)
        {
           
            string dikeyMetin = string.Join("\n", metin.ToCharArray());

            
            label.Text = dikeyMetin;
            label.AutoSize = false; 
            label.TextAlign = ContentAlignment.MiddleCenter; 
            label.Size = new Size(30, 20 * metin.Length); 
        }

    }
}

