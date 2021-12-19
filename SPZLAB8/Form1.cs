using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SPZLAB8
{
    public partial class Form1 : Form
    {
        public List<string> list1;
        public List<string> list2;
        public List<string> list3;
        public List<string> list4;
        public Form1()
        {
            InitializeComponent();
            list1 = new List<string>();
            list2 = new List<string>();
            list3 = new List<string>();
            list4 = new List<string>();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkHardware = hklm.OpenSubKey("HARDWARE");
            RegistryKey hkDescription = hkHardware.OpenSubKey("DESCRIPTION");
            RegistryKey hkSystem = hkDescription.OpenSubKey("System");

            RegistryKey hkBIOS = hkSystem.OpenSubKey("BIOS");
            RegistryKey hkCPU = hkSystem.OpenSubKey(@"CentralProcessor\0");

            string[] BIOSArray = hkBIOS.GetValueNames();
            string[] CPUArray = hkCPU.GetValueNames();

            foreach(var item in BIOSArray)
            {
                list1.Add(item);
                list2.Add(hkBIOS.GetValue(item).ToString());
            }
            foreach (var item in CPUArray)
            {
                list3.Add(item);
                if(hkCPU.GetValue(item) == null)
                    list4.Add("");
                else
                    list4.Add(hkCPU.GetValue(item).ToString());
            }

            listBox1.Items.AddRange(list1.ToArray());
            listBox2.Items.AddRange(list2.ToArray());
            listBox3.Items.AddRange(list3.ToArray());
            listBox4.Items.AddRange(list4.ToArray());
        }
    }
}
