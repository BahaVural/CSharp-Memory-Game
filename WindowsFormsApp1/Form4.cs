using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private Button[,] kutu;
        private Button ilktıklanan = null;
        private Button ikincitıklanan = null;
        public int zaman = 0;
        private int eslesenkart = 0;
        private int kartsayısı = 10 * 10 / 2;

        List<string> semboller = new List<string>
{
    "🚗", "🍎", "🌳", "⚡", "🌊", "🍕", "🐶", "🐱", "🦁", "🍇",
    "🎩", "🌍", "✈️", "🎲", "🎤", "🎬", "🍩", "🚀", "🐠", "🎨",
    "🌟", "🏠", "💡", "🏖️", "🚴", "⏳", "🏞️", "🎁", "⚽", "🖖"
};
        public int sayac = 0;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            int toplambuton = 10 * 10;
            int X = 20;
            int Y = 20;
            int index = 0;
            List<string> sembolListesi = new List<string>();

            for (int i = 0; i < toplambuton / 2; i++)
            {
                sembolListesi.Add(semboller[i % semboller.Count]);
                sembolListesi.Add(semboller[i % semboller.Count]);
            }

            Random rnd = new Random();
            sembolListesi = sembolListesi.OrderBy(x => rnd.Next()).ToList();

            kutu = new Button[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    kutu[i, j] = new Button();
                    kutu[i, j].Location = new Point(X + j * 80, Y + i * 80);
                    kutu[i, j].Size = new Size(80, 80);
                    kutu[i, j].Text = "";
                    kutu[i, j].Font = new Font("Arial", 24, FontStyle.Bold);
                    kutu[i, j].Tag = sembolListesi[index];
                    this.Controls.Add(kutu[i, j]);
                    index++;
                    kutu[i, j].Click += async (object clickSender, EventArgs clickEventArgs) =>
                    {
                        Button tıklananbuton = (Button)clickSender;
                        tıklananbuton.Text = tıklananbuton.Tag.ToString();
                        timer1.Enabled = true;



                        if (ilktıklanan == null)
                        {
                            ilktıklanan = tıklananbuton;
                            ilktıklanan.Enabled = false;
                        }
                        else if (ikincitıklanan == null)
                        {

                            ikincitıklanan = tıklananbuton;
                            if (ilktıklanan.Text == ikincitıklanan.Text)
                            {


                                this.Controls.Remove(ilktıklanan);
                                this.Controls.Remove(ikincitıklanan);
                                sayac++;
                                label4.Text = "Hamle Sayısı:" + sayac;
                                eslesenkart++;
                                eslesenKart();

                            }
                            else
                            {
                                await Task.Delay(150);
                                ilktıklanan.Text = "";
                                ikincitıklanan.Text = "";
                                sayac++;
                                label4.Text = "Hamle Sayısı:" + sayac;
                            }
                            ilktıklanan.Enabled = true;
                            ilktıklanan = null;
                            ikincitıklanan = null;
                        }


                    };
                }

            }
        }
        private void eslesenKart()
        {
            if (eslesenkart == kartsayısı)
            {
                timer1.Enabled = false;
                MessageBox.Show("TEBRİKLER OYUNU KAZANDIN" + "\n" + "HAMLE SAYIN:" + sayac + "\n" + zaman + " SANİYEDE BİTİRDİN", "TEBRİKLERRRR");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            zaman++;
            label3.Text = $"{zaman} saniye geçti.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
            

        }
    }
}
