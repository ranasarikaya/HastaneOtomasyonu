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
    public partial class frmHizmetIslemleri : Form
    {
        public frmHizmetIslemleri()
        {
            InitializeComponent();
        }

        private void frmHizmetIslemleri_Load(object sender, EventArgs e)
        {

            Klinikler k = new Klinikler();
            frmHizmetTanimlama frm = new frmHizmetTanimlama();
            k.KlinikAdiGetir(cbKlinikAdlari);
            int index = cbKlinikAdlari.FindString(txtKlinikAd.Text);
            cbKlinikAdlari.SelectedIndex = index;
        }

        private void tsbtnEkle_Click(object sender, EventArgs e)
        {
            Hizmetler h = new Hizmetler();
            h.HizmetAdi = txtHizmetAd.Text;
            h.Ucret = Convert.ToInt32(txtUcret.Text);
            h.Aciklama = txtAciklama.Text;

            Klinikler k = new Klinikler();
            h.KlinikID=k.KlinikIDBul(cbKlinikAdlari.SelectedItem.ToString());

           
            
           

            if (h.HizmetVarmi(txtHizmetAd.Text))
            {
                MessageBox.Show("Hizmet zaten var.", "UYARI");
            }
            else
            {
                if (h.HizmetEkle(h))
                {

                    MessageBox.Show("Hizmet bilgileri başarıyla eklendi.");
                    //k.KlinikleriGetir(Genel.lvKlinikler);



                }
                else
                {
                    MessageBox.Show("Hizmet bilgileri eklenemedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            Temizle();
        }
        public void Temizle()
        {


            txtHizmetAd.Clear();
            txtAciklama.Clear();
            txtUcret.Clear();
            cbKlinikAdlari.SelectedIndex = 0;
            //txtKlinikAdi.Clear();
            txtHizmetAd.Focus();





        }

        private void tsbtnDuzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hizmet bilgilerini değiştirmek istediğinize emin misiniz?", "Düzenlensin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hizmetler h = new Hizmetler();
                h.HizmetID = Convert.ToInt32(txtHizmetID.Text);
                h.HizmetAdi = txtHizmetAd.Text;
                h.Ucret = Convert.ToDouble(txtUcret.Text);
                h.Aciklama = txtAciklama.Text;
               
                Klinikler k = new Klinikler();
                
                h.KlinikID = k.KlinikIDBul(cbKlinikAdlari.SelectedItem.ToString());



                if (h.HizmetDuzenle(h))
                {

                    MessageBox.Show("Hizmet Bilgileri değiştirildi..");
                    this.Close();


                }
                else
                {

                    MessageBox.Show("Bilgileri kontrol ediniz..");
                }
            }
        }

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbKlinikAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hizmetler h = new Hizmetler();
            //txtKlinikAdi.Text = cbKlinikAdlari.SelectedItem.ToString();
            
        }
    }
}
