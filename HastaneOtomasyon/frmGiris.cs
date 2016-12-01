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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void llblSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
           


        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Personeller p = new Personeller();



            if (p.KullaniciVarmi(txtKullaniciAd.Text, txtSfr.Text))
            {
                frmAnasayfa frm = new frmAnasayfa();
                p =p.PersonelBilgileriGetir(txtKullaniciAd.Text,txtSfr.Text);
                Genel.PersonelID = p.PersonelID;
                Genel.KlinikID = p.KlinikID;
                Genel.UnvanID = p.UnvanID;
                Genel.PersonelAdi = p.Ad;
                Genel.PersonelSoyadi = p.Soyad;
                
                Klinikler k = new Klinikler();
                
                Genel.KlinikAdi= k.KlinikAdiGetir(p.KlinikID);
                frm.tslblKlinikAd.Text = Genel.KlinikAdi;
                if (p.UnvanID==1)
                {
                    frm.tslblPersonelAdi.Text ="Doktor "+ p.Ad + " " + p.Soyad;
                }
                else if(p.UnvanID==2)
                {

                    frm.tslblPersonelAdi.Text = "Hemşire " + p.Ad + " " + p.Soyad;

                }
                else if(p.UnvanID==3)
                {

                    frm.tslblPersonelAdi.Text = "Danışman " + p.Ad + " " + p.Soyad;

                }
                
               
                frm.ShowDialog();
                this.Close();


            }
            else
            {

                MessageBox.Show("Kullanici adi veya şifre bilgileri yanlış !! ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
    }
}
