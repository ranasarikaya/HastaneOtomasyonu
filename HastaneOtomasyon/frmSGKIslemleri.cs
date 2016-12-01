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
    public partial class frmSGKIslemleri : Form
    {
        public frmSGKIslemleri()
        {
            InitializeComponent();
        }

     

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSGKIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void tsbtnDuzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kurumlar bilgilerini değiştirmek istediğinize emin misiniz?", "Düzenlensin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Kurumlar k = new Kurumlar();
                k.KurumID = Convert.ToInt32(txtKurumNo.Text);
                k.KurumAd = txtKurumAd.Text;
                k.Iskonto = Convert.ToInt32(txtIskonto.Text);
               

                if (k.KurumDuzenle(k))
                {

                    MessageBox.Show("Kurum Bilgileri değiştirildi..");
                    this.Close();


                }
                else
                {

                    MessageBox.Show("Bilgileri kontrol ediniz..");
                }
            }

        }

        private void tsbtnEkle_Click(object sender, EventArgs e)
        {
            Kurumlar k = new Kurumlar();
            k.KurumAd = txtKurumAd.Text;
            k.Iskonto = Convert.ToInt32(txtIskonto.Text);
            

            if (k.KurumVarmi(txtKurumAd.Text))
            {
                MessageBox.Show("Kurum zaten var.", "UYARI");
            }
            else
            {
                if (k.KurumEkle(k))
                {

                    MessageBox.Show("Kurum bilgileri başarıyla eklendi.");
                    //k.KlinikleriGetir(Genel.lvKlinikler);



                }
                else
                {
                    MessageBox.Show("Kurum bilgileri eklenemedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            Temizle();
        }
        public void Temizle()
        {


            txtKurumAd.Clear();
           
            txtIskonto.Clear();
            txtKurumAd.Focus();





        }

        private void tsbtnKapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
