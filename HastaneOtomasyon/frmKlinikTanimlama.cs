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
    public partial class frmKlinikTanimlama : Form
    {
        public frmKlinikTanimlama()
        {
            InitializeComponent();
        }

        private void frmKlinikTanimlama_Load(object sender, EventArgs e)
        {

            Klinikler k = new Klinikler();
            k.KlinikleriGetir(lvKlinikler);

            //k.KlinikleriGetir(lvKlinikler);



        }

        private void tsbtnEkle_Click(object sender, EventArgs e)
        {
            frmKlinikIslemleri frm = new frmKlinikIslemleri();
            frm.Text = "Klinik Ekleme İşlemleri";

            frm.Top = 0;
            frm.Left = 0;
            frm.lblKlinikNo.Visible = false;
            frm.txtKlinikNo.Visible= false;
            frm.tsbtnDuzenle.Visible = false;
            frm.tsbtnEkle.Visible = true;
            
            frm.ShowDialog();

            
            Klinikler k = new Klinikler();
            k.KlinikleriGetir(lvKlinikler);

        }

        private void lvKlinikler_DoubleClick(object sender, EventArgs e)
        {
            //Genel.SeciliKlinikNo = Convert.ToInt32(lvKlinikler.SelectedItems[0].Text);
            //Genel.SeciliKlinikAd = lvKlinikler.SelectedItems[0].SubItems[1].Text;
            //Genel.SeciliRandevuSure = Convert.ToInt32(lvKlinikler.SelectedItems[0].SubItems[2].Text);
            //Genel.SeciliAciklama = lvKlinikler.SelectedItems[0].SubItems[3].Text;

            


        }

        private void tsbtnDuzenle_Click(object sender, EventArgs e)
        {
            if (lvKlinikler.SelectedItems.Count==0)
            {
                MessageBox.Show("Klinik bilgisi seçilmedi!!");
            }
            else
            {
                frmKlinikIslemleri frm = new frmKlinikIslemleri();
                frm.Text = "Klinik Düzenleme İşlemleri";
                frm.Top = 0;
                frm.Left = 0;
                frm.tsbtnEkle.Visible = false;
                frm.txtKlinikNo.Text = lvKlinikler.SelectedItems[0].SubItems[0].Text;
                frm.txtKlinikAd.Text = lvKlinikler.SelectedItems[0].SubItems[1].Text;
                frm.txtRandevuSure.Text = lvKlinikler.SelectedItems[0].SubItems[2].Text;


                frm.ShowDialog();
            }
            Klinikler k = new Klinikler();
            k.KlinikleriGetir(lvKlinikler);
            
        }

        private void tsbtnSil_Click(object sender, EventArgs e)
        {
            if (lvKlinikler.SelectedItems.Count == 0)
            {
                MessageBox.Show("Klinik bilgisi seçilmedi!!");


            }
            else
            {
                if (MessageBox.Show("Klinik bilgisini silmek istediğinize emin misiniz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Klinikler k = new Klinikler();
                    k.KlinikNo = Convert.ToInt32(lvKlinikler.SelectedItems[0].SubItems[0].Text);
                    k.KlinikAd = lvKlinikler.SelectedItems[0].SubItems[1].Text;
                    k.RandevuSure = Convert.ToInt32(lvKlinikler.SelectedItems[0].SubItems[2].Text);
                    k.Aciklama = lvKlinikler.SelectedItems[0].SubItems[3].Text;
                    if (k.KlinikSil(k))
                    {

                        MessageBox.Show("Klinik bilgileri silindi.");
                        k.KlinikleriGetir(lvKlinikler);

                    }


                }

            }
        }

        private void tstxtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Klinikler k = new Klinikler();
            k.AdaGoreArama(tstxtAdaGore.Text, lvKlinikler);
        }

        private void tsbtnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
