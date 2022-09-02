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
    public partial class FrekansTablosu : Form
    {
        public FrekansTablosu()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSayiAdedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSayilar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FrekansTablosu_Load(object sender, EventArgs e)
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
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Text = ("<=NOT:Bu alana girilen en son \n değerden sonra imleç degerin \n yanında kalmalı (son degerden \n sonra enter tuşuna basmayınız)!");
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
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Location = new Point(580, 125);
                listSinifLimitleriAlt.Visible = true;
                listSinifLimitleriUst.Visible = true;
                listSinifSinirlariAlt.Visible = true;
                listSinifSinirlariUst.Visible = true;
                listSinifFrekansi.Visible = true;
                listSon.Visible = true;
                listEklenikFrekans.Visible = true;
                listOransalFrekans.Visible = true;
                listOransalEklenikFrekans.Visible = true;

                label1.Location = new Point(251, 52);
                label2.Location = new Point(277, 112);
                txtSayiAdedi.Location = new Point(397, 49);
                txtSayilar.Location = new Point(397, 109);
                btnHesapla.Location = new Point(433, 243);

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

                double maxSayi = sayilar[0],minSayi=sayilar[0];
                for(int i=1;i<sayilar.Length;i++)
                {
                    if(sayilar[i]>maxSayi)
                    {
                        maxSayi = sayilar[i];
                    }

                    if(sayilar[i] < minSayi)
                    {
                        minSayi = sayilar[i];
                    }
                }

                double R = maxSayi - minSayi ;
                int k =(int)Math.Sqrt(sayiAdedi)+1;
                double h =(int)(R/k)+1;

                double[] sinifLimitleriAlt = new double[k];
                double[] sinifLimitleriUst = new double[k];
                sinifLimitleriAlt[0] = minSayi;
                for (int i=1;i<k;i++)
                {
                    sinifLimitleriAlt[i] = sinifLimitleriAlt[i-1]+h;
                }
                int x = 1;
                for (int i=0;i<sayilar.Length;i++)
                {
                    if(x<k)
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
                for (int i=1;i<k;i++)
                {
                    sinifSinirlariUst[i] = sinifSinirlariUst[i-1] + h;
                }
                for (int i = 1; i < k; i++)
                {
                    sinifSinirlariAlt[i] = sinifSinirlariUst[i-1];
                }
                sinifSinirlariAlt[0] = sinifSinirlariUst[0]-h;

                int[] sinifFrekansi = new int[k];
                int sinifFrekansiTekrar = 0;
                double gecici2;
                for(int j=0;j<k;j++)
                {
                    for (int i=0;i<sayilar.Length;i++)
                    {
                        gecici2 = sayilar[i];
                        if (sinifSinirlariAlt[j] < gecici2 && gecici2 < sinifSinirlariUst[j])
                        {
                            sinifFrekansiTekrar++;
                        }
                    }
                    sinifFrekansi[j] =sinifFrekansiTekrar;
                    sinifFrekansiTekrar = 0;
                }

                double[] son = new double[k];
                for(int i=0;i<k;i++)
                {
                    son[i] =(sinifLimitleriAlt[i]+sinifLimitleriUst[i])/2;
                }

                int[] eklenikFrekans =new int[k];
                eklenikFrekans[0] =sinifFrekansi[0];
                for (int i=1;i<k;i++)
                {
                    eklenikFrekans[i] = eklenikFrekans[i-1]+ sinifFrekansi[i];
                }

                double[] oransalFrekans = new double[k];
                for(int i=0;i<k;i++)
                {
                    oransalFrekans[i] =(double)sinifFrekansi[i]/sayiAdedi;
                }

                double[] oransalEklenikFrekans = new double[k];
                for (int i = 0; i < k; i++)
                {
                    oransalEklenikFrekans[i] = (double)eklenikFrekans[i] / sayiAdedi;
                }

                for (int i=0;i<k;i++)
                {
                    listSinifLimitleriAlt.Items.Add(Math.Round(sinifLimitleriAlt[i],2));
                    listSinifLimitleriUst.Items.Add(Math.Round(sinifLimitleriUst[i],2));
                    listSinifSinirlariAlt.Items.Add(Math.Round(sinifSinirlariAlt[i],2));
                    listSinifSinirlariUst.Items.Add(Math.Round(sinifSinirlariUst[i],2));
                    listSinifFrekansi.Items.Add(sinifFrekansi[i]);
                    listSon.Items.Add(Math.Round(son[i],2));
                    listEklenikFrekans.Items.Add(eklenikFrekans[i]);
                    listOransalFrekans.Items.Add(Math.Round(oransalFrekans[i],2));
                    listOransalEklenikFrekans.Items.Add(Math.Round(oransalEklenikFrekans[i],2));
                }
            }
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
    }
}
