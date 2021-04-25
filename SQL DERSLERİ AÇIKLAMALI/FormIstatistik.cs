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
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        //GLOBAL ALANDA SQL ADRESİMİZE BAĞLANDIK
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-LLAB3NO\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "HEPSİ'nin TOPLAM SAYISINI SEÇ TBL_PERSONEL'DEN" DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand toplamPer = new SqlCommand("Select Count(*) From TBL_PERSONEL",baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader toplamPerOku = toplamPer.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (toplamPerOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelToplam.Text = toplamPerOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////

            //TOPLAM EVLİ PERSONEL DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerDurum=1 OLMA ŞARTIYLA HEPSİ'nin TOPLAM SAYISINI TBL_PERSONEL'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand toplamEvliPer = new SqlCommand("Select Count(*) From TBL_PERSONEL where PerDurum=1", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader toplamEvliPerOku = toplamEvliPer.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (toplamEvliPerOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelEvli.Text = toplamEvliPerOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////

            //TOPLAM BEKAR PERSONEL DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerDurum=0 OLMA ŞARTIYLA HEPSİ'nin TOPLAM SAYISINI TBL_PERSONEL'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand toplamBekarPer = new SqlCommand("Select Count(*) From TBL_PERSONEL where PerDurum=1", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader toplamBekarPerOku = toplamBekarPer.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (toplamBekarPerOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelBekar.Text = toplamBekarPerOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////

            //SEHİR ÇEŞİTİNİN DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerSehir'in TEKRARSIZ DEĞERİNİ TBL_PERSONEL'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand sehirCesit = new SqlCommand("Select Count(Distinct(PerSehir)) From TBL_PERSONEL", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader sehirCesitOku = sehirCesit.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (sehirCesitOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelSehirSayi.Text = sehirCesitOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////

            //TOPLAM MAAŞ DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerMaas'ın TOPLAM DEĞERİNİ TBL_PERSONEL'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand toplamMaas = new SqlCommand("Select Sum(PerMaas) From TBL_PERSONEL", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader toplamMaasOku = toplamMaas.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (toplamMaasOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelTopMaas.Text = toplamMaasOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////

            //ORTALAMA MAAŞ DEĞERİNİ LABELE YAZMA İLK baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerMaas'ın ORTALAMA DEĞERİNİ TBL_PERSONEL'DEN SEÇ " DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand ortMaas = new SqlCommand("Select Avg(PerMaas) From TBL_PERSONEL", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader ortMaasOku = ortMaas.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (ortMaasOku.Read())
            {
                //LABELIN TEXT İ VERİ OKUYUCUNUN İLK DEĞERİNİN STRİNG HALİ OLSUN
                labelOrtMaas.Text = ortMaasOku[0].ToString();
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();
        }
    }
}
