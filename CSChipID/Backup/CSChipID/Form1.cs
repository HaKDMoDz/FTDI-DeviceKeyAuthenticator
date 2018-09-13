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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstDevices = new System.Windows.Forms.ListView();
			this.btnFindDevices = new System.Windows.Forms.Button();
			this.colNumber = new System.Windows.Forms.ColumnHeader();
			this.colSerial = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.colLocationID = new System.Windows.Forms.ColumnHeader();
			this.colChipID = new System.Windows.Forms.ColumnHeader();
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
			this.lstDevices.Location = new System.Drawing.Point(16, 8);
			this.lstDevices.Name = "lstDevices";
			this.lstDevices.Size = new System.Drawing.Size(384, 208);
			this.lstDevices.TabIndex = 0;
			this.lstDevices.View = System.Windows.Forms.View.Details;
			// 
			// btnFindDevices
			// 
			this.btnFindDevices.Location = new System.Drawing.Point(16, 224);
			this.btnFindDevices.Name = "btnFindDevices";
			this.btnFindDevices.Size = new System.Drawing.Size(104, 23);
			this.btnFindDevices.TabIndex = 1;
			this.btnFindDevices.Text = "Find 232R Devices";
			this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
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
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 261);
			this.Controls.Add(this.btnFindDevices);
			this.Controls.Add(this.lstDevices);
			this.Name = "MainForm";
			this.Text = "ChipID";
			this.ResumeLayout(false);

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

		private void btnFindDevices_Click(object sender, System.EventArgs e)
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

			catch(FTChipID.ChipIDException ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
