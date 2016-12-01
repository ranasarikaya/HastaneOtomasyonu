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
    public partial class frmHastaKayitKarti : Form
    {




        public frmHastaKayitKarti()
        {
            InitializeComponent();
        }



        private void frmHastaKayitKarti_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            Kurumlar k = new Kurumlar();
            k.KurumTurleriGetir(cbxKurum);
            

        }
       


        private void Temizle()
        {

            txtHastaAd.Clear();
            txtHastaSoyad.Clear();
            txtTcKimlik.Clear();
            txtil.Clear();
            txtilce.Clear();
            mtxtCepTel.Clear();
            mtxtEvTel.Clear();
            mtxtCepTel.Clear();
            mtxtVergiNo.Clear();
            txtOnceki.Clear();
            txtAnneAdi.Clear();
            txtBabaAdi.Clear();
            txtAdres.Clear();
            txtHastaAd.Focus();
            txtDogumYeri.Clear();
            

            label17.ForeColor = System.Drawing.Color.Black;
            label23.ForeColor = System.Drawing.Color.Black;
            label19.ForeColor = System.Drawing.Color.Black;
            label22.ForeColor = System.Drawing.Color.Black;
            label21.ForeColor = System.Drawing.Color.Black;
            label20.ForeColor = System.Drawing.Color.Black;
            label17.ForeColor = System.Drawing.Color.Black;
            label16.ForeColor = System.Drawing.Color.Black;
            label25.ForeColor = System.Drawing.Color.Black;
            label26.ForeColor = System.Drawing.Color.Black;
            label18.ForeColor = System.Drawing.Color.Black;
            label24.ForeColor = System.Drawing.Color.Black;







        }
    

      
      



        private void cbxKurum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Kurumlar k = (Kurumlar)cbxKurum.SelectedItem;

            txtKurumTuru.Text = k.KurumAd;
            txtKurumNo.Text = Convert.ToString(k.KurumID);
        }

        private void txtAdres_TextChanged_1(object sender, EventArgs e)
        {
            txtAdres.ScrollBars = ScrollBars.Vertical;
            txtAdres.ScrollBars = ScrollBars.Both;
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtTcKimlik.Text.Trim() != "" && txtAnneAdi.Text.Trim() != "" && txtHastaAd.Text.Trim() != "" && txtBabaAdi.Text.Trim() != "" && txtDogumYeri.Text.Trim() != "" && txtHastaSoyad.Text.Trim() != "" && mtxtCepTel.Text.Trim() != "" && txtDogumYeri.Text.Trim() != "" && txtil.Text.Trim() != "" && txtilce.Text.Trim() != "" && txtBabaAdi.Text.Trim() != "")
            {
                Hastalar h = new Hastalar();
                if (h.KisiKontrol(txtTcKimlik.Text))
                {
                    MessageBox.Show("Bu Kişi Daha Önceden Kayıtlıdır");
                    txtTcKimlik.Focus();

                }
                else
                {

                    h.Ad = txtHastaAd.Text;
                    h.Soyad = txtHastaSoyad.Text;
                    h.TcKimlikNo = txtTcKimlik.Text;
                    h.Adres = txtAdres.Text;
                    h.Il = txtil.Text;
                    h.Ilce = txtilce.Text;
                    h.EvTel = mtxtEvTel.Text;
                    h.CepTel = mtxtCepTel.Text;
                    h.KanGrubu = cbxKanGrubu.Text;
                    h.BabaAd = txtBabaAdi.Text;
                    h.AnneAd = txtAnneAdi.Text;
                    h.DogumYeri = txtDogumYeri.Text;
                    h.DogumTarihi = Convert.ToDateTime(dtpDTarihi.Value);
                    h.Cinsiyet = cbxCinsiyet.Text;
                    h.MedeniHali = cbxMedeni.Text;
                    h.OncekiSoyad = txtOnceki.Text;
                    h.VergiNo = mtxtVergiNo.Text;
                    h.KayitTarihi = Convert.ToDateTime(dtpTarih.Value);
                    h.KurumID = Convert.ToInt32(txtKurumNo.Text);




                    if (h.KisiEkle(h))
                    {
                        MessageBox.Show("Kişi Bilgileri Kayıt Edildi");
                        Temizle();
                        tsbtnKaydet.Enabled = false;
                        frmHastaKayitSorgulama frm = new frmHastaKayitSorgulama();

                        frm.ShowDialog();


                    }
                    else { MessageBox.Show("Kişi Kayıt İşlemi Gerçekleşmedi!"); }
                }
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!,Dikkat Ediniz!");
                label17.ForeColor = System.Drawing.Color.Red;


                //label22.ForeColor = System.Drawing.Color.Red;
                //label21.ForeColor = System.Drawing.Color.Red;
                //label20.ForeColor = System.Drawing.Color.Red;
                //label17.ForeColor = System.Drawing.Color.Red;


                //label26.ForeColor = System.Drawing.Color.Red;
                if (txtHastaAd.Text.Trim() == "")
                {
                    label18.ForeColor = System.Drawing.Color.Red;
                }
                else
                    label18.ForeColor = System.Drawing.Color.Black;
                if (txtHastaSoyad.Text.Trim() == "")
                {
                    label23.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label23.ForeColor = System.Drawing.Color.Black;
                }

                if (txtTcKimlik.Text.Trim() == "")
                {
                    label19.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label19.ForeColor = System.Drawing.Color.Black;

                }
                if (txtil.Text.Trim() == "")
                {
                    label22.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label22.ForeColor = System.Drawing.Color.Black;
                }
                if (txtilce.Text.Trim() == "")
                {
                    label21.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label22.ForeColor = System.Drawing.Color.Black;
                }
                if (mtxtEvTel.Text.Trim() == "")
                {
                    label20.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label20.ForeColor = System.Drawing.Color.Black;
                }
                if (mtxtCepTel.Text.Trim() == "")
                {
                    label17.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label17.ForeColor = System.Drawing.Color.Red;
                }
                if (cbxKanGrubu.SelectedText.Trim() == "")
                {
                    label16.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label16.ForeColor = System.Drawing.Color.Black;
                }
                if (txtAnneAdi.Text.Trim() == "")
                {
                    label25.ForeColor = System.Drawing.Color.Red;
                }
                else
                    label25.ForeColor = System.Drawing.Color.Black;
                if (txtBabaAdi.Text.Trim() == "")
                {
                    label26.ForeColor = System.Drawing.Color.Red;
                }
                else
                    label26.ForeColor = System.Drawing.Color.Black;
                if (txtDogumYeri.Text.Trim() == "")
                {
                    label24.ForeColor = System.Drawing.Color.Red;
                }
                else
                    label24.ForeColor = System.Drawing.Color.Black;
                if (cbxCinsiyet.SelectedText.Trim() == "")
                {
                    label20.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label20.ForeColor = System.Drawing.Color.Black;
                }



            }
        }

        private void tsbtnYeni_Click(object sender, EventArgs e)
        {
            tsbtnKaydet.Enabled = true;


            Temizle();
            label17.ForeColor = System.Drawing.Color.Black;
            label23.ForeColor = System.Drawing.Color.Black;
            label19.ForeColor = System.Drawing.Color.Black;
            label22.ForeColor = System.Drawing.Color.Black;
            label21.ForeColor = System.Drawing.Color.Black;
            label20.ForeColor = System.Drawing.Color.Black;
            label17.ForeColor = System.Drawing.Color.Black;
            label16.ForeColor = System.Drawing.Color.Black;
            label25.ForeColor = System.Drawing.Color.Black;
            label26.ForeColor = System.Drawing.Color.Black;
            label18.ForeColor = System.Drawing.Color.Black;
            label24.ForeColor = System.Drawing.Color.Black;
        }

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxKurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kurumlar k = (Kurumlar)cbxKurum.SelectedItem;

            txtKurumTuru.Text = k.KurumAd;
            txtKurumNo.Text = Convert.ToString(k.KurumID);
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            pbxResim.Image = Image.FromFile(openFileDialog2.FileName);
           
        }

        private void tslblPersonelAd_Click(object sender, EventArgs e)
        {

        }
    }
}

