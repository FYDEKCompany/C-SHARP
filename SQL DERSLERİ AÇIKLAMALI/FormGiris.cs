using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//BUNU KOYMAYI UNUTMUYORUZ
using System.Data.SqlClient;

namespace der35_Personel_Kayıtları_SQL
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        //GLOBAL ALANDA SQL ADRESİMİZE BAĞLANDIK
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-LLAB3NO\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "KullanıcıAdı @kAdi parametresine ve Sifre @sifre parametresine eşitse TBL_YÖNETİCİ'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand kullaniciAdi = new SqlCommand("Select * From TBL_YONETİCİ where KullaniciAdi=@kAdi and Sifre=@sifre",baglantı);
            
            //PARAMETREYE TEXTBOX DAN TEXT ÇEKTİK
            kullaniciAdi.Parameters.AddWithValue("@kAdi", textKullanici.Text);

            //PARAMETREYE TEXTBOX DAN TEXT ÇEKTİK
            kullaniciAdi.Parameters.AddWithValue("@sifre", textSifre.Text);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader kullaniciAdiOku = kullaniciAdi.ExecuteReader();

            //EĞER KullanıcıAdıOku Okunuyorsa
            if (kullaniciAdiOku.Read())
            {
                Form1 anaForm = new Form1();

                //ANAFORM'u AÇ
                anaForm.Show();

                //BU FORMU GİZLE
                this.Hide();
            }

            //OKUNMUYORSA
            else
            {
                //MESAJ KUTUSUNDA MESAJ GÖSTER
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Lütfen Tekrar Deneyin");
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();
        }
    }
}
