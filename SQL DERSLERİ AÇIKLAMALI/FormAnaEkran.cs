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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //DEĞİŞKENLER GLOBAL ALANDA
        string ad;
        string soyad;
        string sehir;
        int maas;
        string durum;
        string meslek;

        //Form Yüklendiğinde Ne Olsun Yeri
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tBL_PERSONELTableAdapter1.Fill(this.personelVeriTabaniDataSet1.TBL_PERSONEL);
        }

        //LİSTELE BUTONU
        private void buttonListele_Click(object sender, EventArgs e)
        {
            this.tBL_PERSONELTableAdapter1.Fill(this.personelVeriTabaniDataSet1.TBL_PERSONEL);
        }

        //GLOBAL ALANDA SQL ADRESİMİZE BAĞLANDIK
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-LLAB3NO\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        //KAYDET BUTONU
        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            //DEĞİŞKENLERE DEĞER ATADIM TEXTBOXLARDAKİLER FELAN
            ad = textAd.Text;
            soyad = textSoyad.Text;
            sehir = comboSehir.Text;
            maas = Convert.ToInt16(maskedMaas.Text);
            meslek = textMeslek.Text;
            
            //RADİO BUTONLARIN DURUMUNA GÖRE DURUM DEĞİŞKENİNE DEĞER ATADIK
            if (radioEvli.Checked == true)
            {
                durum = "True";
            }

            //RADİO BUTONLARIN DURUMUNA GÖRE DURUM DEĞİŞKENİNE DEĞER ATADIK
            if (radioBekar.Checked == true)
            {
                durum = "False";
            }

            //BAĞLANTIYI AÇTIK (BAĞLANTI NESNESİ)
            baglantı.Open();

            //SqlCommand SINIFINDAN YENİ BİR NESNE OLUŞTURDUK , NE YAPACAĞIMIZI , NEREYE EKLEYECEĞİMİZİ , HANGİ BÖLÜME HANGİ PARAMETREYİ ATAYACAĞIMIZI YAZDIK "SONUNA SqlConnection SINIFINDAN OLUŞTURDUĞUMUZ NESNEYİ EKLEMEYİ UNUTMUYORUZ!"
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONEL(PerAD,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglantı);
            
            //PARAMETRELERE DEĞER ATADIK
            komut.Parameters.AddWithValue("@p1", ad);
            komut.Parameters.AddWithValue("@p2", soyad);
            komut.Parameters.AddWithValue("@p3", sehir);
            komut.Parameters.AddWithValue("@p4", maas);
            komut.Parameters.AddWithValue("@p5", meslek);
            komut.Parameters.AddWithValue("@p6", durum);
            
            //YAZDIĞIMIZ KOMUTU ÇALIŞTIRDIK
            komut.ExecuteNonQuery();

            //BAĞLANTIYI KAPATTIK (BAĞLANTI NESNESİ)
            baglantı.Close();

            //MESAJ VERDİK
            MessageBox.Show("Başarıyla Kayıt Oldunuz");
        }

        //Radio Butonları Temizleme
        private void radioEvli_CheckedChanged(object sender, EventArgs e)
        {
            durum = "True";
        }

        //Radio Butonları Temizleme
        private void radioBekar_CheckedChanged(object sender, EventArgs e)
        {
            durum = "False";
        }

        //Temizle Methodu
        void temizle()
        {
            //TEXTBOXLARA FELAN NULL DEĞER ATADIK
            textId.Text = "";
            textAd.Text = "";
            textSoyad.Text = "";
            comboSehir.Text = "";
            maskedMaas.Text = "";
            textMeslek.Text = "";

            //RADİO BUTONLARINI SEÇİLİ DEĞİL YAPTIK
            radioEvli.Checked = false;
            radioBekar.Checked = false;

            //PERSONEL ID YE İMLECİ GETİRDİK
            textId.Focus();
        }

        //TEMİZLE BUTONU
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        //DataGridView e Çift Tıklanırsa Ne Olacağı
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //BİR DEĞİŞKEN BELİRLEDİK
            int secilendeger;

            //O DEĞİŞKENE SEÇİLEN SATIRI ATADIK
            secilendeger = dataGridView1.SelectedCells[0].RowIndex;

            //SEÇİLEN SATIRDAKİ DEĞERLERİ "SIRASIYLA" TEXTBOX , COMBOBOX ve MASKEDTEXTBOX LARA ATADIK BURADA DEĞİŞKEN KÖPRÜ GÖREVİ GÖRÜYOR.
            textId.Text = dataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            textAd.Text = dataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.Rows[secilendeger].Cells[2].Value.ToString();
            comboSehir.Text = dataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            maskedMaas.Text = dataGridView1.Rows[secilendeger].Cells[4].Value.ToString();
            durum = dataGridView1.Rows[secilendeger].Cells[5].Value.ToString();
            textMeslek.Text = dataGridView1.Rows[secilendeger].Cells[6].Value.ToString();

            //EĞER DURUM DEĞİŞKENİMİZ 'FALSE' İSE BEKAR'I İŞARETLE
            if (durum == "False")
            {
                radioBekar.Checked = true;
            }

            //EĞER DURUM DEĞİŞKENİMİZ 'TRUE' İSE BEKAR'I İŞARETLE
            if (durum == "True")
            {
                radioEvli.Checked = true;
            }

        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            //BAĞLANTIYI AÇTIK (BAĞLANTI NESNESİ)
            baglantı.Open();

            //SqlCommand SINIFINDAN YENİ BİR NESNE OLUŞTURDUK , NE YAPACAĞIMIZI , NEREDEN SİLECEĞİMİZİ VE PERSONEL ID MİZ PARAMETREYE EŞİT İSE ŞARTINI YAZDIK "SONUNA SqlConnection SINIFINDAN OLUŞTURDUĞUMUZ NESNEYİ EKLEMEYİ UNUTMUYORUZ!"
            SqlCommand komutsil = new SqlCommand("Delete  From TBL_PERSONEL Where PerId=@k1", baglantı);

            //PARAMETREMİZE DEĞER ATADIK
            komutsil.Parameters.AddWithValue("@k1", textId.Text);

            //KOMUTUMUZU ÇALIŞTIRDIK
            komutsil.ExecuteNonQuery();

            //BAĞLANTIYI KAPATTIK (BAĞLANTI NESNESİ)
            baglantı.Close();

            //EĞER PERSONEL ID TEXTBOX'I BOŞ İSE DOLDURUN MESAJI VERDİK
            if (textId.Text == "")
            {
                MessageBox.Show("Personel Silmek İçin Önce Bir Personel Seçin!");
            }
            
            //DEĞİLSE BAŞARILI MESAJINI VERDİK
            else
            {
                MessageBox.Show("Personel Başarıyla Silindi");
            }

        }

        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            //BAĞLANTIMIZI AÇTIK (BAĞLANTI NESNESİ)
            baglantı.Open();

            //SqlCommand SINIFINDAN NESNE OLUŞTURDUK , NE YAPACAĞIMIZI , NEYİ VEYA NELERİ GÜNCELLEYECEĞİMİZİ EĞER PERSONEL ID PARAMETREMİZE EŞİT İSE KOMUTUYLA BİTİRDİK "SONUNA SqlConnection SINIFINDAN OLUŞTURDUĞUMUZ NESNEYİ EKLEMEYİ UNUTMUYORUZ!"
            SqlCommand komutGuncelle = new SqlCommand("Update  TBL_PERSONEL Set PerAd=@a1,perSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where PerId = @a7", baglantı);
            
            //PARAMETRELERE DEĞER ATADIK
            komutGuncelle.Parameters.AddWithValue("@a1", textAd.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", textSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", comboSehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", maskedMaas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", durum);
            komutGuncelle.Parameters.AddWithValue("@a6", textMeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", textId.Text);

            //KOMUTUMUZU ÇALIŞTIRDIK
            komutGuncelle.ExecuteNonQuery();

            //BAĞLANTIMIZI KAPATTTIK (BAĞLANTI NESNESİ)
            baglantı.Close();

            //MESAJ VERDİK
            MessageBox.Show("Personel Bilgileriniz Başarıyla Güncellendi");

        }

        //İSTATİSTİK BUTONU
        private void buttonIstatistikler_Click(object sender, EventArgs e)
        {
            FormIstatistik istatistik = new FormIstatistik();
            istatistik.Show();
        }

        //GRAFİK BUTONU
        private void buttonGrafikler_Click(object sender, EventArgs e)
        {
            FormGrafik formGrafik = new FormGrafik();
            formGrafik.Show();
        }

        //RAPOR BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            FormRapor raporForm = new FormRapor();
            raporForm.Show();
        }
    }
}
