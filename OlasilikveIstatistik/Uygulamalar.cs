using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OlasilikveIstatistik
{
    public partial class Uygulamalar : Form
    {
        public Uygulamalar()
        {
            InitializeComponent();
        }

        public static int[] sirala(int[] dizi)
        {
            int gecici;
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 1; j < dizi.Length; j++)
                {
                    if (dizi[j - 1] > dizi[j])
                    {
                        gecici = dizi[j - 1];
                        dizi[j - 1] = dizi[j];
                        dizi[j] = gecici;
                    }
                }
            }
            return dizi;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg,int wparam,int lparam);

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Banner_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.Content.Controls.Count > 0)
                this.Content.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Content.Controls.Add(fh);
            this.Content.Tag = fh;
            fh.Show();
        }

        private void btnBasitSeri_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new BasitSeri());
        }

        private void btnBasitRastgele_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new BasitRastgele());
        }

        private void btnSistematikRastgele_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new SistematikRastgele());
        }

        private void btnFrekansSerisi_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrekansSerisi());
        }

        private void btnFrekansTablosu_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrekansTablosu());
        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMerkeziEgilimOlculeri_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new MerkeziEgilimOlculeri());
        }

        private void btnMerkeziDagilimOlculeri_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new MerkeziDagilimOlculeri());
        }

        private void btnKombinasyon_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Kombinasyon());
        }

        private void btnPermutasyon_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Permutasyon());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            labelNumara2.Enabled = true;
            labelNumara1.Enabled = false;
            labelGeri.Visible = true;
            labelIleri.Visible = false;
            panel2.Visible = true;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            labelNumara2.Enabled = false;
        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void labelGeri_Click(object sender, EventArgs e)
        {
            labelGeri.Visible = false;
            labelIleri.Visible = true;
            labelNumara1.Enabled = true;
            labelNumara2.Enabled = false;
            panel2.Visible = false;
        }

        private void Banner_Paint(object sender, PaintEventArgs e)
        {

        }
    }
        
}
