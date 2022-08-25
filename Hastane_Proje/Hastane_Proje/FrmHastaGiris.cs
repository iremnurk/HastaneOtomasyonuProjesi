using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Proje
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
            
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {   //Hasta TC ve şifre uyuyor mu?
            SqlCommand komut = new SqlCommand ("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();//Komuttan gelen değerleri oku
            //eğer okuma işlemi doğru bir şekilde olursa hasta detay sayfasına git
            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = MskTC.Text;//giriş formunda aldığı tc değişkenini hasta detay formuna yazdırdı                     
                fr.Show();
                this.Hide();
            }
            //hatalı okuma varsa uyarı ver
            else
            {
                MessageBox.Show("Hatalı TC & Şifre");
            }
            bgl.baglanti().Close();//bağlantıyı kapattık

        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MskTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
