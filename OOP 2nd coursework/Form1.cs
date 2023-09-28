/*********************************************************************************
**                                SAKARYA ÜNİVERSİTESİ
**                         BİLGİSAYAR VE BİLİŞİM BİLİMLER FAKÜLTESİ       
**                             BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                            NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                2021-2022 BAHAR DÖNEMİ
**
**                         ÖDEV NUMARASI: 2
**                         ÖĞRENCİ ADI: NIHAD ASGAROV
**                         ÖĞRENCİ NUMARASI: B211210554
**                         DERSİN ALINDIĞI GRUP: A
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ParayiYaziyaCevir(string gelentutar)
            {
                decimal dectutar = Convert.ToDecimal(gelentutar);
                string strTutar = dectutar.ToString("F2").Replace('.', ',');
                string lira = strTutar.Substring(0, strTutar.IndexOf(','));
                string kurus = strTutar.Substring(strTutar.IndexOf(',') + 1, 2);
                string yazi = "";
                string[] birler = { "", " BİR", " İKİ", " ÜÇ", " DÖRT", " BEŞ", " ALTI", " YEDİ", " SEKİZ", " DOKUZ" };
                string[] onlar = { "", " ON", " YİRMİ", " OTUZ", " KIRK", " ELLİ", " ALTMIŞ", " YETMİŞ", " SEKSEN", " DOKSAN" };
                string[] binler = { " KATRİLYON", " TRİLYON", " MİLYAR", " MİLYON", " BİN", "" };
                int grupSayisi = 6;
                lira = lira.PadLeft(grupSayisi * 3, '0');
                string grupDegeri;
                for (int i = 0; i < grupSayisi * 3; i += 3)
                {
                    grupDegeri = "";
                    if (lira.Substring(i, 1) != "0")
                        grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + " YÜZ";
                    if (grupDegeri == " BİR YÜZ")
                        grupDegeri = " YÜZ";
                    grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))];
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))];
                    if (grupDegeri != "")
                        grupDegeri += "" + binler[i / 3];
                    if (grupDegeri == " BİR BİN")
                        grupDegeri = " BİN";
                    yazi += grupDegeri;
                }
                if (yazi != "")
                    yazi += " TL ";
                int yaziUzunlugu = yazi.Length;
                if (kurus.Substring(0, 1) != "0")
                    yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];
                if (kurus.Substring(1, 1) != "0")
                    yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];
                if (yazi.Length > yaziUzunlugu)
                    yazi += " KURUŞ";
                else
                    yazi += "";
                return yazi;
            }
            label1.Text = ParayiYaziyaCevir(textBox1.Text);
        }
    }
}
