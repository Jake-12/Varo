using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using XDevkit;
using JRPC_Client;

namespace Varo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        IXboxConsole xbox; //Define Console Variable
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }
        private void SimpleButton1_Click(object sender, EventArgs e){
            //Connecting Xbox 
         if (xbox.Connect(out xbox)){ 
            MessageBox.Show("Successfully Connected to Console!");
            xbox.XNotify("Connected to Varo!");
            xbox.XNotify("Varo, Created by Jake! <3");
            xbox.XNotify("Open-Sourced on GitHub!");
            label1.ForeColor = Color.Green;
            label1.Text = "Status: Connected!";
            textBox1.Text = ("Kernel Version: " + xbox.GetKernalVersion());
            textBox2.Text = ("CPU Key: " + xbox.GetCPUKey());
            textBox3.Text = ("CPU Temperature: " + xbox.GetTemperature(JRPC.TemperatureType.CPU));
            textBox4.Text = ("GPU Temperature: " + xbox.GetTemperature(JRPC.TemperatureType.GPU));
            textBox5.Text = ("Motherboard Temperature: " + xbox.GetTemperature(JRPC.TemperatureType.MotherBoard));
            textBox6.Text = ("IP Address: " + xbox.XboxIP());
        }else{
            MessageBox.Show("Connect Locate Console!"); //This can be due to Neighborhood not installed or JRPC2 as plugin. 
        }
        }
    }
}
