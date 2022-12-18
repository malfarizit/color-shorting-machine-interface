using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace FastFoodDemo
{
    public partial class MySecondCustmControl : UserControl
    {
        private SerialPort myport;
        private DateTime datetime;
        private string in_data;
        int hasil,hasill,hasilll,hasillll,hasilllll,count;
        string in_data_1;
        public MySecondCustmControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Start button
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = port_name_tb.Text;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += Myport_DataReceived;
            try
            {
                myport.Open();
                data_tb.Text = "";
                myport.Write("s");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        private void Myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
            in_data = in_data.Trim();

            this.Invoke(new EventHandler(displaydata_event));

        }
        private void displaydata_event(object sender, EventArgs e)
        {
            datetime = DateTime.Now;
            if(in_data_1 != in_data)
            {
                    if (in_data == "1")
                    {
                        button4.BackColor = Color.Red;
                        button5.BackColor = Color.WhiteSmoke;
                        //button6.BackColor = Color.WhiteSmoke;
                        //button7.BackColor = Color.WhiteSmoke;
                        //button8.BackColor = Color.WhiteSmoke;
                        hasil++;
                        count += 1;
                        label2.Text = String.Format("{0}", hasil);
                    }
                    else if (in_data == "3")
                    {
                        button4.BackColor = Color.WhiteSmoke;
                        button5.BackColor = Color.Yellow;
                        //button6.BackColor = Color.WhiteSmoke;
                        //button7.BackColor = Color.WhiteSmoke;
                        //button8.BackColor = Color.WhiteSmoke;
                        hasill++;
                        label3.Text = String.Format("{0}", hasill);
                    }
                    //else if (in_data == "asd")
                    //{
                    //    button4.BackColor = Color.WhiteSmoke;
                    //    button5.BackColor = Color.WhiteSmoke;
                    //    button6.BackColor = Color.Green;
                    //    button7.BackColor = Color.WhiteSmoke;
                    //    button8.BackColor = Color.WhiteSmoke;
                    //    hasilll++;
                    //    label4.Text = String.Format("{0}", hasilll);
                    //}
                    //else if (in_data == "BIRU")
                    //{
                    //    button4.BackColor = Color.WhiteSmoke;
                    //    button5.BackColor = Color.WhiteSmoke;
                    //    button6.BackColor = Color.WhiteSmoke;
                    //    button7.BackColor = Color.Blue;
                    //    button8.BackColor = Color.WhiteSmoke;
                    //    hasillll++;
                    //    label5.Text = String.Format("{0}", hasillll);
                    //}
                    //else if (in_data == "SILVER")
                    //{
                    //    button4.BackColor = Color.WhiteSmoke;
                    //    button5.BackColor = Color.WhiteSmoke;
                    //    button6.BackColor = Color.WhiteSmoke;
                    //    button7.BackColor = Color.WhiteSmoke;
                    //    button8.BackColor = Color.Silver;
                    //    hasilllll++;
                    //    label6.Text = String.Format("{0}", hasilllll);
                    //}


                    string time = datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;
                    data_tb.AppendText(in_data + "\n");
                }
            in_data_1 = in_data;
        }
            
         

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myport.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
            }
            string merah, kuning, hijau, biru, silver;
            int total;
            merah = label2.Text;
            kuning = label3.Text;
            hijau = label4.Text;
            biru = label5.Text;
            silver = label6.Text;
            total = Convert.ToInt32(merah) + Convert.ToInt32(kuning) + Convert.ToInt32(hijau) + Convert.ToInt32(biru) + Convert.ToInt32(silver);
            txtHasil.Text = total.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string pathfile = @"C:\Users\Muhammad Alfarizi\Documents\Visual Studio 2015\Projects\Mikro\LOG\";
                string filename = "log2.txt";
                System.IO.File.WriteAllText(pathfile + filename, data_tb.Text);
                MessageBox.Show("Data has been saved to " + pathfile, "Save File");
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message, "Error");
            }
        }
    }
    }
