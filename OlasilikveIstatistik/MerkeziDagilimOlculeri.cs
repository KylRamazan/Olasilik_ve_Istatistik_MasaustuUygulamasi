using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlasilikveIstatistik
{
    public partial class MerkeziDagilimOlculeri : Form
    {
        public MerkeziDagilimOlculeri()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text == "")
            {
                errorProvider1.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else if (txtSayilar.Text == "")
            {
                errorProvider2.SetError(txtSayilar, "Bu alan boş geçilemez");
            }
            else
            {
                label1.Location = new Point(240, 70);
                label2.Location = new Point(270, 127);
                label16.Location = new Point(590, 135);
                txtSayiAdedi.Location = new Point(393, 67);
                txtSayilar.Location = new Point(393, 124);
                btnHesapla.Location = new Point(429, 252);

                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;

                int sayiAdedi = Convert.ToInt32(txtSayiAdedi.Text);
                double[] sayilar = new double[sayiAdedi];
                for (int i = 0; i < txtSayilar.Lines.Length; i++)
                {
                    sayilar[i] = Convert.ToDouble(txtSayilar.Lines[i]);
                }

                double gecici;
                for (int i = 0; i < sayilar.Length; i++)
                {
                    for (int j = 1; j < sayilar.Length; j++)
                    {
                        if (sayilar[j - 1] > sayilar[j])
                        {
                            gecici = sayilar[j - 1];
                            sayilar[j - 1] = sayilar[j];
                            sayilar[j] = gecici;
                        }
                    }
                }

                double toplam = 0;
                for (int i = 0; i < sayiAdedi; i++)
                {
                    toplam += sayilar[i];
                }
                double aritmetikOrtalama = toplam / sayiAdedi;

                double kareSonuc = 0.0;
                for(int i=0;i<sayiAdedi;i++)
                {
                    kareSonuc +=(Math.Pow(sayilar[i]-aritmetikOrtalama,2));
                }
                double sonuc = kareSonuc/(sayiAdedi-1);
                label10.Text =Convert.ToString(Math.Round(sonuc,2));

                label11.Text = Convert.ToString(Math.Round(Math.Sqrt(sonuc), 2));

                double mutlakDegerSonuc=0.0,mutlakDegerToplamSonuc=0.0;
                for (int i=0;i<sayiAdedi;i++)
                {
                    mutlakDegerSonuc = sayilar[i] - aritmetikOrtalama;
                    if(mutlakDegerSonuc<0)
                    {
                        mutlakDegerSonuc = (-1)*mutlakDegerSonuc;
                    }
                    mutlakDegerToplamSonuc +=mutlakDegerSonuc;
                }
                label12.Text = Convert.ToString(Math.Round((mutlakDegerToplamSonuc/sayiAdedi), 2));


                double maxSayi = sayilar[0], minSayi = sayilar[0];
                for (int i = 1; i < sayilar.Length; i++)
                {
                    if (sayilar[i] > maxSayi)
                    {
                        maxSayi = sayilar[i];
                    }

                    if (sayilar[i] < minSayi)
                    {
                        minSayi = sayilar[i];
                    }
                }

                double R = maxSayi - minSayi;
                int k = (int)Math.Sqrt(sayiAdedi) + 1;
                double h = (int)(R / k) + 1;

                double[] sinifLimitleriAlt = new double[k];
                double[] sinifLimitleriUst = new double[k];
                sinifLimitleriAlt[0] = minSayi;
                for (int i = 1; i < k; i++)
                {
                    sinifLimitleriAlt[i] = sinifLimitleriAlt[i - 1] + h;
                }
                int x = 1;
                for (int i = 0; i < sayilar.Length; i++)
                {
                    if (x < k)
                    {
                        if (sayilar[i] % 1 != 0)
                        {
                            sinifLimitleriUst[x - 1] = sinifLimitleriAlt[x] - (0.1);
                            x++;
                        }
                        else
                        {
                            sinifLimitleriUst[x - 1] = sinifLimitleriAlt[x] - 1;
                            x++;
                        }
                    }
                }
                sinifLimitleriUst[k - 1] = sinifLimitleriUst[k - 2] + h;

                double[] sinifSinirlariAlt = new double[k];
                double[] sinifSinirlariUst = new double[k];
                sinifSinirlariUst[0] = (sinifLimitleriAlt[1] + sinifLimitleriUst[0]) / 2;
                for (int i = 1; i < k; i++)
                {
                    sinifSinirlariUst[i] = sinifSinirlariUst[i - 1] + h;
                }
                for (int i = 1; i < k; i++)
                {
                    sinifSinirlariAlt[i] = sinifSinirlariUst[i - 1];
                }
                sinifSinirlariAlt[0] = sinifSinirlariUst[0] - h;

                int[] sinifFrekansi = new int[k];
                int sinifFrekansiTekrar = 0;
                double gecici2;
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < sayilar.Length; i++)
                    {
                        gecici2 = sayilar[i];
                        if (sinifSinirlariAlt[j] < gecici2 && gecici2 < sinifSinirlariUst[j])
                        {
                            sinifFrekansiTekrar++;
                        }
                    }
                    sinifFrekansi[j] = sinifFrekansiTekrar;
                    sinifFrekansiTekrar = 0;
                }

                double q1SinifSonucu = sayiAdedi/4.0;
                int n1=0,n1Toplam=0;
                for(int i=0;i<k;i++)
                {
                    if(q1SinifSonucu>=n1Toplam)
                    {
                        n1Toplam +=sinifFrekansi[i];
                    }
                    else
                    {
                        n1 =i;
                        break;
                    }
                }
                
                int q1OncekiToplam = 0;
                for(int i=0;i<n1-1;i++)
                {
                    q1OncekiToplam += sinifFrekansi[i];
                }
                double J1 =q1SinifSonucu-q1OncekiToplam;
                int fQ1 =sinifFrekansi[n1-1];
                double L1=sinifSinirlariAlt[n1-1];
                double Q1 =L1+((J1*h)/fQ1);

                label13.Text = Convert.ToString(Math.Round(Q1,2));

                double q3SinifSonucu =(3*sayiAdedi)/4.0;
                int n3 = 0,n3Toplam=0;
                for (int i = 0; i < k; i++)
                {
                    if (q3SinifSonucu >= n3Toplam)
                    {
                        n3Toplam += sinifFrekansi[i];
                    }
                    else
                    {
                        n3 = i;
                        break;
                    }
                    if(i==k-1)
                    {
                        n3 =i+1;
                    }
                }

                int q3OncekiToplam = 0;
                for (int i = 0; i < n3-1; i++)
                {
                    q3OncekiToplam += sinifFrekansi[i];
                }
                double J3 = q3SinifSonucu - q3OncekiToplam;
                double fQ3 =sinifFrekansi[n3-1];
                double L3 =sinifSinirlariAlt[n3-1];
                double Q3 = L3 + ((J3 * h) / fQ3);
                label14.Text = Convert.ToString(Math.Round(Q3, 2));

                double DK = Math.Sqrt(sonuc) /aritmetikOrtalama;
                label15.Text =Convert.ToString(Math.Round(DK,2));
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MerkeziDagilimOlculeri_Load(object sender, EventArgs e)
        {
            txtSayilar.ScrollBars = ScrollBars.Vertical;
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label16.Text = ("<=NOT:Bu alana girilen en son \n değerden sonra imleç degerin \n yanında kalmalı (son degerden \n sonra enter tuşuna basmayınız)!");
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }

        private void txtSayiAdedi_TextChanged(object sender, EventArgs e)
        {
            if (txtSayiAdedi.Text == "")
            {

                errorProvider1.SetError(txtSayiAdedi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSayilar_TextChanged(object sender, EventArgs e)
        {
            if (txtSayilar.Text == "")
            {

                errorProvider2.SetError(txtSayilar, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtSayiAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
