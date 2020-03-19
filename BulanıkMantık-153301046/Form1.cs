using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanıkMantık_153301046
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BulanıkMantık bm;
        double hassaslik;
        double kirlilik;
        double miktar;
        private void button1_Click(object sender, EventArgs e)
        {
            hassaslik = (double)numericUpDown1.Value;
            kirlilik = (double)numericUpDown2.Value;
            miktar = (double)numericUpDown3.Value;
            bm = new BulanıkMantık(hassaslik, miktar, kirlilik);
            bm.Kume(label7, label8, label11);
            reset_datagrid();
            isaretle();
            listBox1.Items.Clear();
            Dictionary<int, double> mamdani_sonuc = new Dictionary<int, double>();
            mamdani_sonuc = bm.NumaraBul();
            var sirala = mamdani_sonuc.OrderBy(i => i.Key);
            foreach (var i in sirala)
            {
                listBox1.Items.Add("Kural " + i.Key + " = " + i.Value);
            }

            bm.cikis_fonksiyon_degerler(listBox2, listBox3, listBox4);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datagrid_doldur();

        }
        void datagrid_doldur()
        {
           
            string[,] kural_al = TemelKural.kurallar;
            for(int i=0; i<27; i++)
            {
                dataGridView1.Rows.Add();
                for(int j=0; j<6; j++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[j+1].Value = kural_al[i, j];
                }
            }
        }
        void isaretle()
        {
            string[,] kural = TemelKural.kurallar;

            for (int k = 0; k < bm.hassasligi.Count; k++)
            {
                for (int m = 0; m < bm.miktari.Count; m++)
                {
                    for (int n = 0; n < bm.kirliligi.Count; n++)
                    {
                        for (int i = 0; i < 27; i++)
                        {
                            if (kural[i, 0] == bm.hassasligi[k] && kural[i, 1] == bm.miktari[m] && kural[i, 2] == bm.kirliligi[n])
                            {
                                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                                renk.BackColor = Color.DarkSeaGreen;
                                dataGridView1.Rows[i].DefaultCellStyle = renk;
                                i++;
                            }
                        }
                    }
                }
            }
        }
        void reset_datagrid()
        {
            for(int i=0; i<27; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                renk.BackColor = Color.White;
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Dictionary<int,double> mamdani_sonuc = new Dictionary<int, double>();
            mamdani_sonuc = bm.NumaraBul();
            var sirala = mamdani_sonuc.OrderBy(i => i.Key);
            foreach(var i in sirala)
            {
                listBox1.Items.Add("Kural "+i.Key + " = " + i.Value);
            }
            
            bm.cikis_fonksiyon_degerler(listBox2,listBox3,listBox4);

        }*/
    }
}
