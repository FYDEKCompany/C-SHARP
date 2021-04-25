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
    public partial class FormGrafik : Form
    {
        public FormGrafik()
        {
            InitializeComponent();
        }

        //GLOBAL ALANDA SQL ADRESİMİZE BAĞLANDIK
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-LLAB3NO\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void FormGrafik_Load(object sender, EventArgs e)
        {
            //baglantı'yı AÇIYORUZ
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP "PerSehir'den HEPSİNİ SAY TBL_PERSONEL'DEN SEÇ Ve PerSehir'e Göre Gurupla" DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand komutGrafik = new SqlCommand("Select PerSehir,Count(*) From TBL_PERSONEL Group By PerSehir",baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader grafikOku = komutGrafik.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while(grafikOku.Read())
            {
                //chart1 in Sehirler inde X ve Y Olarak X'e grafikOku'nun 0. indexi,Y'ye grafikOku'nun 1. indexi
                chart1.Series["Sehirler"].Points.AddXY(grafikOku[0], grafikOku[1]);
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //
            baglantı.Open();

            //SQL KOMUTU OLUŞTURUP " Mesleğe göre PerMaas ın Ortalama Miktarı TBL_PERSONEL'DEN SEÇ Ve PerMeslek'e Göre Gurupla" DİYORUZ VE SONUNA ,baglantı KOYMAYI UNUTMUYORUZ
            SqlCommand komutGrafik2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) From TBL_PERSONEL Group By PerMeslek", baglantı);

            //VERİ OKUYUCU OLUŞTURUYORUZ VE SQL KOMUTU İLE İLİŞKİLENDİRİYORUZ
            SqlDataReader grafikOku2 = komutGrafik2.ExecuteReader();

            //VERİ OKUYUCU OKUMA İŞLEMİ YAPTIĞI MÜDDETÇE
            while (grafikOku2.Read())
            {

                //chart1 in Meslek-Maas ında X ve Y Olarak X'e grafikOku'nun 0. indexi,Y'ye grafikOku'nun 1. indexi
                chart2.Series["Meslek-Maas"].Points.AddXY(grafikOku2[0], grafikOku2[1]);
            }

            //baglantı'yı KAPATIYORUZ
            baglantı.Close();
        }

                

        
    }
}
