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
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        private void randevuSorgulamaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hastaKayitmitm_Click(object sender, EventArgs e)
        {
            frmHastaKayitKarti frm = new frmHastaKayitKarti();
            frm.Show();

        }

        private void klinikTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlinikTanimlama frm = new frmKlinikTanimlama();
            frm.ShowDialog();
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            tslblPersonelAdi.Text = Genel.PersonelAdi + " " + Genel.PersonelSoyadi;
        }

        private void tsbHastaKabul_Click(object sender, EventArgs e)
        {
            if (Genel.UnvanID==1002 || Genel.UnvanID==1003)
            {
                frmHastaKayitSorgulama frm = new frmHastaKayitSorgulama();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bu Alana giriş yetkiniz yok!!");
            }
           
        }

        private void tsbMuayene_Click(object sender, EventArgs e)
        {
            if(Genel.UnvanID !=1)
            {
                MessageBox.Show("Bu sayfaya giriş yetkiniz yok !","YETKİ YOK",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            

               

            }

            else
            {

                frmMuayeneListesi frm = new frmMuayeneListesi();
                frm.ShowDialog();


            }

        }

        private void tsbVezne_Click(object sender, EventArgs e)
        {
            if(Genel.UnvanID !=1002)
            {

                MessageBox.Show("Bu sayfaya giriş yetkiniz yok !", "YETKİ YOK", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
            else
            {

                //Vezne Sayfası Açılacak 

            }
        }

        private void personelİslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Genel.UnvanID != 1003)
            {
                MessageBox.Show("Bu bölüme giriş yetkiniz yok !", "YETKİ YOK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void randevuİslemlerimitm_Click(object sender, EventArgs e)
        {

        }

        private void hastaKabulmitm_Click(object sender, EventArgs e)
        {
            frmHastaKayitSorgulama frm = new frmHastaKayitSorgulama();
            frm.ShowDialog();
        }

        private void tahlilTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sosyalGüvenlikKurumuTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSGKTanimlama frm = new frmSGKTanimlama();
            frm.ShowDialog();
        }

        private void teshisEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHizmetIslemleri frm = new frmHizmetIslemleri();
            frm.ShowDialog();
        }

        private void tsbRandevu_Click(object sender, EventArgs e)
        {
            frmHastaKayitSorgulama frm = new frmHastaKayitSorgulama();
            frm.ShowDialog();
        }
    }
}
