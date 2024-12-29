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
    public partial class KarsılastırmaForm : Form
    {
        public KarsılastırmaForm()
        {
            InitializeComponent();
        }
        public KarsılastırmaForm(DataRow Personel1, DataRow Personel2)
        {
            InitializeComponent();
            LoadPersonelData(Personel1, Personel2);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Personel1Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadPersonelData(DataRow personel1, DataRow personel2)
        {
           
             string ad = personel1["Ad"].ToString();
             string SoyAd= personel1["Soyad"].ToString();
             Personel1AdLbl.Text = $"{ad} {SoyAd}";
            Personel1EpostaLbl.Text = personel1["Eposta"].ToString();
            Personel1VerimlilikProcessBar.Value = Convert.ToInt32(personel1["Verimlilik"]);
            Personel1IsbirligiProcessBar.Value = Convert.ToInt32(personel1["Isbirligi"]);
            Personel1ProjeProcessBar.Value = Convert.ToInt32(personel1["ProjeTamamlama"]);
            Personel1GenelPuanProccessBar.Value = Convert.ToInt32(personel1["GenelPuan"]);

            string ad2 = personel2["Ad"].ToString();
            string SoyAd2 = personel2["Soyad"].ToString();
            Personel2AdLbl.Text = $"{ad2} {SoyAd2}";
            Personel2EpostaLbl.Text = personel2["Eposta"].ToString();
            Personel2VerimlilikProcessBar.Value = Convert.ToInt32(personel2["Verimlilik"]);
            Personel2IsbirligiProcessBar.Value = Convert.ToInt32(personel2["Isbirligi"]);
            Personel2ProjeProcessBar.Value = Convert.ToInt32(personel2["ProjeTamamlama"]);
            Personel2GenelPuanProccessBar.Value = Convert.ToInt32(personel2["GenelPuan"]);
        }
    }
}
