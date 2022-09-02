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
    public partial class MerkeziEgilimOlculeri : Form
    {
        public MerkeziEgilimOlculeri()
        {
            InitializeComponent();
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
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                
                label1.Location = new Point(244,74);
                label2.Location = new Point(274,133);
                label11.Location = new Point(590,135);
                txtSayiAdedi.Location = new Point(406,71);
                txtSayilar.Location = new Point(406,128);
                btnHesapla.Location = new Point(440,263);

                int sayiAdedi = Convert.ToInt32(txtSayiAdedi.Text);
                double[] sayilar = new double[sayiAdedi];
                for (int i = 0; i < txtSayilar.Lines.Length; i++)
                {
                    sayilar[i] = Convert.ToInt32(txtSayilar.Lines[i]);
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
                for(int i=0;i<sayiAdedi;i++)
                {
                    toplam += sayilar[i];
                }

                double aritmetikOrtalama = toplam / sayiAdedi;
                label7.Text =Convert.ToString(Math.Round(aritmetikOrtalama,2));

                double sayi, sayi2;
                double medyan=0.0;
                if (sayiAdedi%2==0)
                {
                    sayi = sayilar[(sayiAdedi/2)-1];
                    sayi2 = sayilar[(sayiAdedi / 2)];
                    medyan = (sayi + sayi2) / 2;
                    if(medyan%1!=0)
                    {
                        label8.Text = Convert.ToString(Math.Round(medyan, 2));
                    }
                    else
                    {
                        label8.Text = Convert.ToString((int)medyan);
                    }
                }
                else
                {
                    label8.Text = Convert.ToString(sayilar[(int)(sayiAdedi/2)]);
                }

                int[] tekrarDegerleri = new int[sayiAdedi];
                int tekrarSayisi = 0;
                for (int i = 0; i < sayilar.Length; i++)
                {
                    for (int j = 0; j < sayilar.Length; j++)
                    {
                        if (sayilar[i] == sayilar[j])
                        {
                            tekrarSayisi++;
                        }
                    }
                    tekrarDegerleri[i] = tekrarSayisi;
                    tekrarSayisi = 0;
                }

                int enBuyuk = tekrarDegerleri[0],indis=0;
                for(int i=1;i<sayiAdedi;i++)
                {
                    if(enBuyuk<tekrarDegerleri[i])
                    {
                        enBuyuk = tekrarDegerleri[i];
                        indis = i;
                    }
                }
                label9.Text = Convert.ToString(sayilar[indis]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void MerkeziEgilimOlculeri_Load(object sender, EventArgs e)
        {
            txtSayilar.ScrollBars = ScrollBars.Vertical;
            errorProvider1.BlinkRate = 400;
            errorProvider2.BlinkRate = 400;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Text = ("<=NOT:Bu alana girilen en son \n değerden sonra imleç degerin \n yanında kalmalı (son degerden \n sonra enter tuşuna basmayınız)!");
            
        }

        private void txtSayiAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSayilar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
