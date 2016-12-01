using HastaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class frmHastaKabul : Form
    {
        public frmHastaKabul()
        {
            InitializeComponent();
        }

        private void frmHastaKabul_Load(object sender, EventArgs e)
        {
            tslblPersonelAd.Text = Genel.PersonelAdi + " " + Genel.PersonelSoyadi;
            Klinikler k = new Klinikler();
            k.KlinikAdiGetir(cbKlinikler);
            cbKlinikler.SelectedIndex = 0;
            Personeller p = new Personeller();
            p.PersonelAdiGetir(cbHekimler, cbKlinikler.SelectedItem.ToString());
            cbHekimler.SelectedIndex = 0;
            txtHastaID.Text = Genel.SeciliHastaID.ToString();


        }

        private void btnRandevuVer_Click(object sender, EventArgs e)
        {
            
            Personeller p = new Personeller();
            string Hekim = cbHekimler.SelectedItem.ToString();
            string[] Hekim1 = Hekim.Split(' ');
            string HekimAd = Hekim1[0];
            string HekimSoyad = Hekim1[1];
            Genel.HekimID = p.HekimIDBul(HekimAd,HekimSoyad);
            frmRandevular frm = new frmRandevular();
            frm.ShowDialog();
            txtRandevuGün.Text = Genel.RandevuTarih;
            txtRandevuSaat.Text = Genel.RandevuSaat;


        }

        private void cbKlinikler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Personeller p = new Personeller();
            p.PersonelAdiGetir(cbHekimler, cbKlinikler.SelectedItem.ToString());
         
        }

        private void gbxRandevu_Enter(object sender, EventArgs e)
        {

        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {

        }
    }
}
