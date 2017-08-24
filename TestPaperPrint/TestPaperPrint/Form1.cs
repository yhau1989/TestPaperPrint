using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPaperPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Puedes utilizar WMI para obtener la informacion del servicio con algo asi

            try
            {
                string PrinterJobs = "SELECT * FROM Win32_PrintJob";

                ManagementObjectSearcher FindPrintJobs = new ManagementObjectSearcher(PrinterJobs);
                ManagementObjectCollection prntJobCollection = FindPrintJobs.Get();

                lbl_printers.Text = "";

                foreach (ManagementObject prntJob in prntJobCollection)
                {

                    System.String jobName = prntJob.Properties["Name"].Value.ToString();
                    //lbl_printers.Text += jobName + "\n";

                    char[] JobSplit = new char[1];
                    JobSplit[0] = Convert.ToChar(",");
                    string prnterName = jobName.Split(JobSplit)[0];
                    lbl_printers.Text += "\t\t printerName: " + prnterName + "\n";
                    string documentName = "Doucment Name->" + prntJob.Properties["Document"].Value.ToString() + " Sender Name->" + prntJob.Properties["owner"].Value.ToString();
                    lbl_printers.Text += "\t\t documentName: " + documentName + "\n";


                    /*if (String.Compare(prnterName, printerName, true) == 0)
                    {
                        printJobCollection.Add(documentName);
                    }*/

                }
            }
            catch (Exception ex)
            {

                lbl_printers.Text = ex.Message;
            }
        }

       
    }
}
