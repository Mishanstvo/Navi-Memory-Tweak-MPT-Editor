using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryVoltageChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.mpt)|*.mpt|All files(*.*)|*.*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("All the processes described below represent a massive intervention in the control of the graphics card and its software (BIOS)! Use this software entirely at your own risk and responsibility, and may only be performed by experienced users for evaluation purposes!","Information!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        string filename;
        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
             filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            label5.Text = filename;
            using (var file = File.Open(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                ////read min///
                file.Position = 1326;
               string min1 = Convert.ToString(file.ReadByte(), 16);
                file.Position = 1327;
               String min2= Convert.ToString(file.ReadByte(),16);
                String min = min1 + min2;
                if (min == "2413")
                {
                    comboBox2.Text = "1225";
                }
                if (min == "8813")
                {
                    comboBox1.Text = "1250";
                }
                if (min == "ec13")
                {
                    comboBox1.Text = "1275";
                }
                if (min == "5014")
                {
                    comboBox1.Text = "1300";
                }
                if (min == "b414")
                {
                    comboBox1.Text = "1325";
                }
                if (min == "1815")
                {
                    comboBox1.Text = "1350";
                }
                ////read min///
                ////read max //
                file.Position = 1328;
                string max1 = Convert.ToString(file.ReadByte(), 16);
                file.Position = 1329;
                String max2 = Convert.ToString(file.ReadByte(), 16);
                String max = max1 + max2;
                if (max == "2413")
                {
                    comboBox2.Text = "1225";
                }
                if (max == "8813")
                {
                    comboBox2.Text = "1250";
                }
                if(max=="ec13")
                {
                    comboBox2.Text = "1275";
                }
                if (max == "5014")
                {
                    comboBox2.Text = "1300";
                }
                if (max == "b414")
                {
                    comboBox2.Text = "1325";
                }
                if (max == "1815")
                {
                    comboBox2.Text = "1350";
                }


                //////memory controller////

                file.Position = 1318;
                string mincon1 = Convert.ToString(file.ReadByte(), 16);
                file.Position = 1319;
                String mincon2 = Convert.ToString(file.ReadByte(), 16);
                String mincon = mincon1 + mincon2;
              //  MessageBox.Show(mincon);
               
                if (mincon == "8ca")
                {
                    comboBox3.Text = "675";
                }
                if (mincon == "f0a")
                {
                    comboBox3.Text = "700";
                }
                if (mincon == "54b")
                {
                    comboBox3.Text = "725";
                }
                if (mincon == "b8b")
                {
                    comboBox3.Text = "750";
                }
                if (mincon == "1cc")
                {
                    comboBox3.Text = "775";
                }
                if (mincon == "80c")
                {
                    comboBox3.Text = "800";
                }
                if (mincon == "e4c")
                {
                    comboBox3.Text = "825";
                }
                if (mincon == "48d")
                {
                    comboBox3.Text = "850";
                }
                ///////maxcon
                file.Position = 1320;
                string maxcon1 = Convert.ToString(file.ReadByte(), 16);
                file.Position = 1321;
                String maxcon2 = Convert.ToString(file.ReadByte(), 16);
                String maxcon = maxcon1 + maxcon2;
              
                if (maxcon == "8ca")
                {
                    comboBox4.Text = "675";
                }
                if (maxcon == "f0a")
                {
                    comboBox4.Text = "700";
                }
                if (maxcon == "54b")
                {
                    comboBox4.Text = "725";
                }
                if (maxcon == "b8b")
                {
                    comboBox4.Text = "750";
                }
                if (maxcon == "1cc")
                {
                    comboBox4.Text = "775";
                }
                if (maxcon == "80c")
                {
                    comboBox4.Text = "800";
                }
                if (maxcon == "e4c")
                {
                    comboBox4.Text = "825";
                }
                if (maxcon == "48d")
                {
                    comboBox4.Text = "850";
                }
                if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" )
                {
                    MessageBox.Show("Unknown value in one or more fields! \n Press OK to continue.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.Text) <= Convert.ToInt32(comboBox2.Text) && Convert.ToInt32(comboBox3.Text) <= Convert.ToInt32(comboBox4.Text))
            {
                using (var file = File.Open(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                
                    if (comboBox1.Text == "1225")
                    {
                        file.Position = 1326;
                        file.WriteByte(0x24);
                        file.Position = 1327;
                        file.WriteByte(0x13);
                    }

                    if (comboBox1.Text == "1250")
                    {
                        file.Position = 1326;
                        file.WriteByte(0x88);
                        file.Position = 1327;
                        file.WriteByte(0x13);
                    }
                    if (comboBox1.Text == "1275")
                    {
                        file.Position = 1326;
                        file.WriteByte(0xEC);
                        file.Position = 1327;
                        file.WriteByte(0x13);
                    }
                    if (comboBox1.Text == "1300")
                    {
                        file.Position = 1326;
                        file.WriteByte(0x50);
                        file.Position = 1327;
                        file.WriteByte(0x14);
                    }
                    if (comboBox1.Text == "1325")
                    {
                        file.Position = 1326;
                        file.WriteByte(0xB4);
                        file.Position = 1327;
                        file.WriteByte(0x14);
                    }
                    if (comboBox1.Text == "1350")
                    {
                        file.Position = 1326;
                        file.WriteByte(0x18);
                        file.Position = 1327;
                        file.WriteByte(0x15);
                    }
                    ///max///
                    ///
                    if (comboBox2.Text == "1225")
                    {
                        file.Position = 1328;
                        file.WriteByte(0x24);
                        file.Position = 1329;
                        file.WriteByte(0x13);
                        file.Position = 1330;
                        file.WriteByte(0x24);
                        file.Position = 1331;
                        file.WriteByte(0x13);
                        file.Position = 1332;
                        file.WriteByte(0x24);
                        file.Position = 1333;
                        file.WriteByte(0x13);
                    }

                    if (comboBox2.Text == "1250")
                    {
                        file.Position = 1328;
                        file.WriteByte(0x88);
                        file.Position = 1329;
                        file.WriteByte(0x13);
                        file.Position = 1330;
                        file.WriteByte(0x88);
                        file.Position = 1331;
                        file.WriteByte(0x13);
                        file.Position = 1332;
                        file.WriteByte(0x88);
                        file.Position = 1333;
                        file.WriteByte(0x13);
                    }
                    if (comboBox2.Text == "1275")
                    {
                        file.Position = 1328;
                        file.WriteByte(0xEC);
                        file.Position = 1329;
                        file.WriteByte(0x13);
                        file.Position = 1330;
                        file.WriteByte(0xEC);
                        file.Position = 1331;
                        file.WriteByte(0x13);
                        file.Position = 1332;
                        file.WriteByte(0xEC);
                        file.Position = 1333;
                        file.WriteByte(0x13);
                    }
                    if (comboBox2.Text == "1300")
                    {
                        file.Position = 1328;
                        file.WriteByte(0x50);
                        file.Position = 1329;
                        file.WriteByte(0x14);
                        file.Position = 1330;
                        file.WriteByte(0x50);
                        file.Position = 1331;
                        file.WriteByte(0x14);
                        file.Position = 1332;
                        file.WriteByte(0x50);
                        file.Position = 1333;
                        file.WriteByte(0x14);
                    }
                    if (comboBox2.Text == "1325")
                    {
                        file.Position = 1328;
                        file.WriteByte(0xB4);
                        file.Position = 1329;
                        file.WriteByte(0x14);
                        file.Position = 1330;
                        file.WriteByte(0xB4);
                        file.Position = 1331;
                        file.WriteByte(0x14);
                        file.Position = 1332;
                        file.WriteByte(0xB4);
                        file.Position = 1333;
                        file.WriteByte(0x14);
                    }
                    if (comboBox2.Text == "1350")
                    {
                        file.Position = 1328;
                        file.WriteByte(0x18);
                        file.Position = 1329;
                        file.WriteByte(0x15);
                        file.Position = 1330;
                        file.WriteByte(0x18);
                        file.Position = 1331;
                        file.WriteByte(0x15);
                        file.Position = 1332;
                        file.WriteByte(0x18);
                        file.Position = 1333;
                        file.WriteByte(0x15);
                    }
                    ///max///
                    ///conmin///
                    if (comboBox3.Text == "675")
                    {
                        file.Position = 1318;
                        file.WriteByte(0x8C);
                        file.Position = 1319;
                        file.WriteByte(0x0A);
                    }
                    if (comboBox3.Text == "700")
                    {
                        file.Position = 1318;
                        file.WriteByte(0xF0);
                        file.Position = 1319;
                        file.WriteByte(0x0A);
                    }
                    if (comboBox3.Text == "725")
                    {
                        file.Position = 1318;
                        file.WriteByte(0x54);
                        file.Position = 1319;
                        file.WriteByte(0x0B);
                    }
                    if (comboBox3.Text == "750")
                    {
                        file.Position = 1318;
                        file.WriteByte(0xB8);
                        file.Position = 1319;
                        file.WriteByte(0x0B);
                    }
                    if (comboBox3.Text == "775")
                    {
                        file.Position = 1318;
                        file.WriteByte(0x1C);
                        file.Position = 1319;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox3.Text == "800")
                    {
                        file.Position = 1318;
                        file.WriteByte(0x80);
                        file.Position = 1319;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox3.Text == "825")
                    {
                        file.Position = 1318;
                        file.WriteByte(0xE4);
                        file.Position = 1319;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox3.Text == "850")
                    {
                        file.Position = 1318;
                        file.WriteByte(0x48);
                        file.Position = 1319;
                        file.WriteByte(0x0D);
                    }
                    //////conmax
                    ///
                    if (comboBox4.Text == "675")
                    {
                        file.Position = 1320;
                        file.WriteByte(0x8C);
                        file.Position = 1321;
                        file.WriteByte(0x0A);
                        file.Position = 1322;
                        file.WriteByte(0x8C);
                        file.Position = 1323;
                        file.WriteByte(0x0A);
                        file.Position = 1324;
                        file.WriteByte(0x8C);
                        file.Position = 1325;
                        file.WriteByte(0x0A);
                    }
                    if (comboBox4.Text == "700")
                    {
                        file.Position = 1320;
                        file.WriteByte(0xF0);
                        file.Position = 1321;
                        file.WriteByte(0x0A);
                        file.Position = 1322;
                        file.WriteByte(0xF0);
                        file.Position = 1323;
                        file.WriteByte(0x0A);
                        file.Position = 1324;
                        file.WriteByte(0xF0);
                        file.Position = 1325;
                        file.WriteByte(0x0A);
                    }
                    if (comboBox4.Text == "725")
                    {
                        file.Position = 1320;
                        file.WriteByte(0x54);
                        file.Position = 1321;
                        file.WriteByte(0x0B);
                        file.Position = 1322;
                        file.WriteByte(0x54);
                        file.Position = 1323;
                        file.WriteByte(0x0B);
                        file.Position = 1324;
                        file.WriteByte(0x54);
                        file.Position = 1325;
                        file.WriteByte(0x0B);
                    }
                    if (comboBox4.Text == "750")
                    {
                        file.Position = 1320;
                        file.WriteByte(0xB8);
                        file.Position = 1321;
                        file.WriteByte(0x0B);
                        file.Position = 1322;
                        file.WriteByte(0xB8);
                        file.Position = 1323;
                        file.WriteByte(0x0B);
                        file.Position = 1324;
                        file.WriteByte(0xB8);
                        file.Position = 1325;
                        file.WriteByte(0x0B);
                    }
                    if (comboBox4.Text == "775")
                    {
                        file.Position = 1320;
                        file.WriteByte(0x1C);
                        file.Position = 1321;
                        file.WriteByte(0x0C);
                        file.Position = 1322;
                        file.WriteByte(0x1C);
                        file.Position = 1323;
                        file.WriteByte(0x0C);
                        file.Position = 1324;
                        file.WriteByte(0x1C);
                        file.Position = 1325;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox4.Text == "800")
                    {
                        file.Position = 1320;
                        file.WriteByte(0x80);
                        file.Position = 1321;
                        file.WriteByte(0x0C);
                        file.Position = 1322;
                        file.WriteByte(0x80);
                        file.Position = 1323;
                        file.WriteByte(0x0C);
                        file.Position = 1324;
                        file.WriteByte(0x80);
                        file.Position = 1325;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox4.Text == "825")
                    {
                        file.Position = 1320;
                        file.WriteByte(0xE4);
                        file.Position = 1321;
                        file.WriteByte(0x0C);
                        file.Position = 1322;
                        file.WriteByte(0xE4);
                        file.Position = 1323;
                        file.WriteByte(0x0C);
                        file.Position = 1324;
                        file.WriteByte(0xE4);
                        file.Position = 1325;
                        file.WriteByte(0x0C);
                    }
                    if (comboBox4.Text == "850")
                    {
                        file.Position = 1320;
                        file.WriteByte(0x48);
                        file.Position = 1321;
                        file.WriteByte(0x0D);
                        file.Position = 1322;
                        file.WriteByte(0x48);
                        file.Position = 1323;
                        file.WriteByte(0x0D);
                        file.Position = 1324;
                        file.WriteByte(0x48);
                        file.Position = 1325;
                        file.WriteByte(0x0D);
                    }


                    MessageBox.Show("Success write!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Minimum value cannot be higher than the maximum!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.Show();
        }
    }
}
