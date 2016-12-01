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
    public partial class frmHizmetTanimlama : Form
    {
        public frmHizmetTanimlama()
        {
            InitializeComponent();
        }

        private void frmHizmetTanimlama_Load(object sender, EventArgs e)
        {
            Hizmetler h = new Hizmetler();
            h.HizmetleriGetir(lvHizmetler);
        }

        private void tsbtnAdaGore_TextChanged(object sender, EventArgs e)
        {
            Hizmetler h = new Hizmetler();
            h.AdaGoreArama(tstxtAdaGore.Text, lvHizmetler);
        }

        private void tstxtKlinikAdinaGore_TextChanged(object sender, EventArgs e)
        {
            Hizmetler h = new Hizmetler();
            h.KlinikAdinaGoreArama(tstxtKlinikAdinaGore.Text, lvHizmetler);
        }

        private void tsbtnEkle_Click(object sender, EventArgs e)
        {
            frmHizmetIslemleri frm = new frmHizmetIslemleri();
            frm.Text = "Hizmet Ekleme İşlemleri";

            frm.Top = 0;
            frm.Left = 0;
            frm.lblHizmetID.Visible = false;
            frm.txtHizmetID.Visible = false;
            frm.tsbtnDuzenle.Visible = false;
            frm.tsbtnEkle.Visible = true;
            Klinikler k = new Klinikler();
            k.KlinikAdiGetir(frm.cbKlinikAdlari);
            frm.ShowDialog();

            
            Hizmetler h = new Hizmetler();
            h.HizmetleriGetir(lvHizmetler);

        }

        private void tsbtnDuzenle_Click(object sender, EventArgs e)
        {
            if (lvHizmetler.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hizmet bilgisi seçilmedi!!");
            }
            else
            {
                frmHizmetIslemleri frm = new frmHizmetIslemleri();
                frm.Text = "Hizmet Düzenleme İşlemleri";
                frm.Top = 0;
                frm.Left = 0;
                frm.tsbtnEkle.Visible = false;
                frm.txtHizmetID.Text = lvHizmetler.SelectedItems[0].SubItems[0].Text;
                frm.txtHizmetAd.Text = lvHizmetler.SelectedItems[0].SubItems[1].Text;
                frm.txtAciklama.Text = lvHizmetler.SelectedItems[0].SubItems[2].Text;
                frm.txtKlinikAd.Text= lvHizmetler.SelectedItems[0].SubItems[3].Text;


                
                frm.txtKlinikNo.Text = lvHizmetler.SelectedItems[0].SubItems[5].Text;

                


                frm.txtUcret.Text = lvHizmetler.SelectedItems[0].SubItems[4].Text;


                frm.ShowDialog();




            }







          
        
        Hizmetler h = new Hizmetler();
        h.HizmetleriGetir(lvHizmetler);
        }

        private void tsbtnSil_Click(object sender, EventArgs e)
        {
            if (lvHizmetler.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hizmet bilgisi seçilmedi!!");


            }
            else
            {
                if (MessageBox.Show("Hizmet bilgisini silmek istediğinize emin misiniz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Hizmetler h = new Hizmetler();
                    h.HizmetID = Convert.ToInt32(lvHizmetler.SelectedItems[0].SubItems[0].Text);
                    h.HizmetAdi = lvHizmetler.SelectedItems[0].SubItems[1].Text;
                    h.Ucret = Convert.ToDouble(lvHizmetler.SelectedItems[0].SubItems[4].Text);
                    h.KlinikID = Convert.ToInt32(lvHizmetler.SelectedItems[0].SubItems[5].Text);
                    h.Aciklama = lvHizmetler.SelectedItems[0].SubItems[2].Text;
                    if (h.HizmetSil(h))
                    {

                        MessageBox.Show("Hizmet bilgileri silindi.");
                        h.HizmetleriGetir(lvHizmetler);

                    }


                }

            }
        }

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
