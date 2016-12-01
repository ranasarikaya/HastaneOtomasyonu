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
    public partial class frmRandevuIptal : Form
    {
        public frmRandevuIptal()
        {
            InitializeComponent();
        }

        private void frmRandevuIptal_Load(object sender, EventArgs e)
        {
          
            txtHastaAdi.Text = Genel.SeciliHastaAd;
            txtHastaSoyadi.Text = Genel.SeciliHastaSoyad;
          

            Klinikler k = new Klinikler();
            k.KlinikAdiGetir(cbKlinikler);
           
           
           
             
        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {
            Randevular r = new Randevular();
            string tarih = cbRandevuTarih.SelectedItem.ToString();
            string saat = cbRandevuSaat.SelectedItem.ToString();
            if(r.RandevuSil(Genel.HekimID, Genel.SeciliHastaID, tarih, saat))
            {

                MessageBox.Show("Randevu bilgileri silindi!");





            }
        }

        private void cbKlinikler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Personeller p = new Personeller();
            string KlinikAdi = cbKlinikler.SelectedItem.ToString();
            p.PersonelAdiGetir(cbHekimler, KlinikAdi);
        }

        private void cbHekimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmHastaKayitSorgulama frm = new frmHastaKayitSorgulama();
            Personeller p = new Personeller();
            string Hekim = cbHekimler.SelectedItem.ToString();
            string[] Hekim1 = Hekim.Split(' ');
            string HekimAd = Hekim1[0];
            string HekimSoyad = Hekim1[1];
            Genel.HekimID = p.HekimIDBul(HekimAd, HekimSoyad);
          
            Randevular r = new Randevular();
            if (r.RandevuTaraByRandevuIptalTarih(Genel.HekimID, Genel.SeciliHastaID, cbRandevuTarih))
            {

               


            }
            else
            {

                MessageBox.Show("Randevunuz bulunmamaktadır!");

            }
        }

        private void cbRandevuTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            Randevular r = new Randevular();
            Genel.RandevuTarih = cbRandevuTarih.SelectedItem.ToString();
            r.RandevuTaraByRandevuIptalSaat(Genel.HekimID, Genel.SeciliHastaID, Genel.RandevuTarih, cbRandevuSaat);
        }

        private void cbRandevuSaat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
