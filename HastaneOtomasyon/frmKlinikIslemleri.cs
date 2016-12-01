using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HastaneOtomasyon.Models;

namespace HastaneOtomasyon
{
    public partial class frmKlinikIslemleri : Form
    {
        public frmKlinikIslemleri()
        {
            InitializeComponent();
        }

        private void frmKlinikIslemleri_Load(object sender, EventArgs e)
        {
            //txtKlinikNo.Text = Genel.KlinikNo.ToString();
            //if(tsbtnDuzenle.Visible==true)
            //{
            //    txtKlinikNo.Text = Genel.SeciliKlinikNo.ToString();
            //    txtKlinikAd.Text = Genel.SeciliKlinikAd;
            //    txtAciklama.Text = Genel.SeciliAciklama;
            //    txtRandevuSure.Text = Genel.SeciliRandevuSure.ToString();

            //}
        
            
                
        }

        //private void tsbtnDuzenle_Click(object sender, EventArgs e)
        //{
        //    Klinikler k = new Klinikler();
        //    k.KlinikNo = Convert.ToInt32(txtKlinikNo.Text);
        //    k.KlinikAd = txtKlinikAd.Text;
        //    k.RandevuSure = Convert.ToInt32(txtRandevuSure.Text);
        //    k.Aciklama = txtAciklama.Text;

        //    if(k.KlinikDuzenle(k))
        //    {

        //        MessageBox.Show("Klinik Bilgileri değiştirildi..");
        //        this.Close();


        //    }
        //    else
        //    {

        //        MessageBox.Show("Bilgileri kontrol ediniz..");
        //    }
            
        //}

        private void tsbtnEkle_Click(object sender, EventArgs e)
        {
            Klinikler k = new Klinikler();
            k.KlinikAd = txtKlinikAd.Text;
            k.RandevuSure = Convert.ToInt32(txtRandevuSure.Text);
            k.Aciklama = txtAciklama.Text;

            if (k.KlinikVarmi(txtKlinikAd.Text))
            {
                MessageBox.Show("Klinik zaten var.", "UYARI");
            }
            else
            {
                if (k.KlinikEkle(k))
                {

                    MessageBox.Show("Klinik bilgileri başarıyla eklendi.");
                    //k.KlinikleriGetir(Genel.lvKlinikler);



                }
                else
                {
                    MessageBox.Show("Klinik bilgileri eklenemedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            Temizle();
        }
        public void Temizle()
        {


            txtKlinikAd.Clear();
            txtAciklama.Clear();
            txtRandevuSure.Clear();
            txtKlinikAd.Focus();





        }

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            Klinikler k = new Klinikler();
            frmKlinikTanimlama frm = new frmKlinikTanimlama();
            
           
            this.Close();
       }

        private void tsbtnDuzenle_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Klinik bilgilerini değiştirmek istediğinize emin misiniz?", "Düzenlensin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Klinikler k = new Klinikler();
                k.KlinikNo = Convert.ToInt32(txtKlinikNo.Text);
                k.KlinikAd = txtKlinikAd.Text;
                k.RandevuSure = Convert.ToInt32(txtRandevuSure.Text);
                k.Aciklama = txtAciklama.Text;

                if (k.KlinikDuzenle(k))
                {

                    MessageBox.Show("Klinik Bilgileri değiştirildi..");
                    this.Close();


                }
                else
                {

                    MessageBox.Show("Bilgileri kontrol ediniz..");
                }
            }
        }
    }
}
