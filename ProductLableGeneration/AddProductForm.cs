using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductLableGeneration
{
    public partial class AddProductForm : Form
    {

        public List<Product> Products { get; set; }
        public TextUtil _textUtil = new TextUtil();
        public string _path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "products.dat";
        public Main MainForm { get; set; }

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show(@"Please input all the necessary fields!", @"Acess Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Product product = new Product()
            {
                GUID = System.Guid.NewGuid().ToString(),
                STWPN = this.txtPN.Text.Trim(),
                QuantityForOneContainer = this.txtQuantityForOneContainer.Text.Trim(),
                PartNumber = this.txtPartNumber.Text.Trim(),
                Boxes = this.txtBox.Text.Trim(),
                Description = this.txtDescription.Text.Trim(),
                EngineeringChange = this.txtEngineeringChange.Text.Trim(),
                GrossWeightDown = this.txtGrossWTDOWN.Text.Trim(),
                NetWeightDown = this.txtNETDOWN.Text.Trim(),
                GrossWeightUp = this.txtGrossWTUP.Text.Trim(),
                NetWeightUp = this.txtNETWTUP.Text.Trim(),
                QuantiryUp = this.txtQuantityUp.Text.Trim(),
                QuantityDown = this.txtQuantityDown.Text.Trim(),
                Receiver = this.txtReceiver.Text.Trim(),
                SupplierAddress = this.txtSupplierAddress.Text.Trim(),
                SupplierCode = this.txtSupplierCode.Text.Trim()
            };
            Products.Add(product);
            _textUtil.ArchiveProducts(_path, Products);
            this.MainForm.ChangeDataSource(Products);
            this.Close();
        }

        private bool ValidateInput()
        {
            if (this.txtPN.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtQuantityForOneContainer.Text.Trim() == "")
            {
                return false;
            } if (this.txtPartNumber.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtBox.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtDescription.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtEngineeringChange.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtGrossWTDOWN.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtNETDOWN.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtGrossWTUP.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtGrossWTUP.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtQuantityUp.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtQuantityDown.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtReceiver.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtSupplierAddress.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtSupplierCode.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPartNumber_Leave(object sender, EventArgs e)
        {
            bool singal = true;
            while (singal)
            {
                if (this.txtPartNumber.Text.Length < 11)
                {
                    this.txtPartNumber.Text = "0" + this.txtPartNumber.Text;
                }
                else
                {
                    singal = false;
                }
            }
        }
    }
}
