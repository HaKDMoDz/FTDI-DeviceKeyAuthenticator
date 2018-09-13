using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using FTChipID;

/* 
 * 
 * 
 PLEASE NOTE
  You must add a reference to the FTChipIDNet.dll in order to use this sample
  To do this:
    1. Click on Solution explorer tab.
    2. Right click the References tree.
    3. Choose Add Reference option.
    4. Browse to the FTChipIDNet.dll (as a personal preference I place this in my bin directory)
    5. Click OK
*
*
*/
namespace CSChipID
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnFindDevices;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colSerial;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colLocationID;
        private System.Windows.Forms.ColumnHeader colChipID;
        private System.Windows.Forms.ListView lstDevices;
        private Label info;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDevices = new System.Windows.Forms.ListView();
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChipID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFindDevices = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstDevices
            // 
            this.lstDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colSerial,
            this.colDescription,
            this.colLocationID,
            this.colChipID});
            this.lstDevices.Location = new System.Drawing.Point(19, 9);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(461, 240);
            this.lstDevices.TabIndex = 0;
            this.lstDevices.UseCompatibleStateImageBehavior = false;
            this.lstDevices.View = System.Windows.Forms.View.Details;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 30;
            // 
            // colSerial
            // 
            this.colSerial.Text = "Serial";
            this.colSerial.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 100;
            // 
            // colLocationID
            // 
            this.colLocationID.Text = "LocationID";
            this.colLocationID.Width = 70;
            // 
            // colChipID
            // 
            this.colChipID.Text = "ChipID";
            this.colChipID.Width = 100;
            // 
            // btnFindDevices
            // 
            this.btnFindDevices.Location = new System.Drawing.Point(19, 258);
            this.btnFindDevices.Name = "btnFindDevices";
            this.btnFindDevices.Size = new System.Drawing.Size(125, 27);
            this.btnFindDevices.TabIndex = 1;
            this.btnFindDevices.Text = "Find 232R Devices";
            this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(166, 263);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 17);
            this.info.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(497, 288);
            this.Controls.Add(this.info);
            this.Controls.Add(this.btnFindDevices);
            this.Controls.Add(this.lstDevices);
            this.Name = "MainForm";
            this.Text = "ChipID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        /*My Altered Function to test chip id value compared to allowed chip id
         * key type function for valid chip id test
         * 
         */
        void matchChipID()
        {
            int numDevices = 0, LocID = 0, ChipID = 0;
            string SerialBuffer = "01234567890123456789012345678901234567890123456789";
            string Description = "01234567890123456789012345678901234567890123456789";
            string item;
            string key;

            //lstDevices.Items.Clear();

            try
            {
                FTChipID.ChipID.GetNumDevices(ref numDevices);
                if (numDevices > 0)
                {
                    for (int i = 0; i < numDevices; i++)
                    {

                        item = i.ToString();
                        FTChipID.ChipID.GetDeviceSerialNumber(i, ref SerialBuffer, 50);
                        item = item + " " + SerialBuffer;
                        FTChipID.ChipID.GetDeviceDescription(i, ref Description, 50);
                        item = item + " " + Description;
                        FTChipID.ChipID.GetDeviceLocationID(i, ref LocID);
                        item = item + " 0x" + LocID.ToString("X");
                        FTChipID.ChipID.GetDeviceChipID(i, ref ChipID);
                        item = item + " 0x" + ChipID.ToString("X");
                        key = "0x" + ChipID.ToString("X");
                        info.Text = item;
                        Clipboard.SetText(key);
                        if(key == "0x7F9CCFDD")
                        {
                            System.Media.SystemSounds.Asterisk.Play();
                            MessageBox.Show("FTDI232 Device Key Matches\r\nOfficial Device Key In Use.", "Authenticated Device!");

                        }
                        else
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                            MessageBox.Show("Unauthenticated FTDI Device\r\nKey Does Not Match\r\nPlease Insert Correct Device!", "Invalid Serial Device!");
                        }
                    }
                }
            }

            catch (FTChipID.ChipIDException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        




        /*  Original button click event feature to get chip id , id, location added to a function for call
         * 
         */
        void getChipInfo()
        {
            int numDevices = 0, LocID = 0, ChipID = 0;
            string SerialBuffer = "01234567890123456789012345678901234567890123456789";
            string Description = "01234567890123456789012345678901234567890123456789";
            ListViewItem item;

            lstDevices.Items.Clear();

            try
            {
                FTChipID.ChipID.GetNumDevices(ref numDevices);
                if (numDevices > 0)
                {
                    for (int i = 0; i < numDevices; i++)
                    {
                        item = new ListViewItem();
                        item.Text = i.ToString();
                        FTChipID.ChipID.GetDeviceSerialNumber(i, ref SerialBuffer, 50);
                        item.SubItems.Add(SerialBuffer);
                        FTChipID.ChipID.GetDeviceDescription(i, ref Description, 50);
                        item.SubItems.Add(Description);
                        FTChipID.ChipID.GetDeviceLocationID(i, ref LocID);
                        item.SubItems.Add("0x" + LocID.ToString("X"));
                        FTChipID.ChipID.GetDeviceChipID(i, ref ChipID);
                        item.SubItems.Add("0x" + ChipID.ToString("X"));
                        lstDevices.Items.Add(item);
                    }
                }
            }

            catch (FTChipID.ChipIDException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
         	

        private void btnFindDevices_Click(object sender, System.EventArgs e)
        {
            getChipInfo();
            matchChipID();
        }

    }
}
