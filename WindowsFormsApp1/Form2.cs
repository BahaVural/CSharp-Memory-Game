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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form1 kolay = new Form1();
                kolay.ShowDialog();
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                Form3 orta = new Form3();
                orta.ShowDialog();
                this.Hide();
            }
            else
            {
                Form4 zor = new Form4();
                zor.ShowDialog();
                this.Hide();
            }
        }
    }
}
