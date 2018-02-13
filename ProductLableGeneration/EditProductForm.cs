using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProductLableGeneration
{
    public partial class EditProductForm : Form
    {

        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public TextUtil _textUtil = new TextUtil();
        public string _configPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "products.dat";
        public Main MainForm { get; set; }

        public EditProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedProduct == null)
            {
                return;
            }
            if (!ValidateInput())
            {
                MessageBox.Show(@"Please input all the necessary fields!", @"Acess Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string guid = SelectedProduct.GUID;
            Product product = GetProductByGUID(guid, Products);
            product.STWPN = this.comboBox1.Text.Trim();
            product.PartNumber = this.txtPartNumber.Text.Trim();
            product.Receiver = this.txtReceiver.Text.Trim();
            product.Boxes = this.txtBox.Text.Trim();
            product.Description = this.txtDescription.Text.Trim();
            product.QuantiryUp = this.txtQuantityUp.Text.Trim();
            product.QuantityDown = this.txtQuantityDown.Text.Trim();
            product.NetWeightUp = this.txtNETUP.Text.Trim();
            product.GrossWeightUp = this.txtGrossWTUP.Text.Trim();
            product.NetWeightDown = this.txtNETDOWN.Text.Trim();
            product.GrossWeightDown = this.txtGrossWTDOWN.Text.Trim();
            product.SupplierCode = this.txtSupplierCode.Text.Trim();
            product.SupplierAddress = this.txtSupplierAddress.Text.Trim();
            product.EngineeringChange = this.txtEngineeringChange.Text.Trim();
            product.QuantityForOneContainer = this.txtQuantityForOneContainer.Text.Trim();
            _textUtil.ArchiveProducts(_configPath, Products);

            this.comboBox1.Items.Clear();
            foreach (var p in Products)
            {
                this.comboBox1.Items.Add(p);
            }
            if (this.Products.Count > 0)
            {
                this.comboBox1.SelectedItem = product;
            }

            MessageBox.Show(@"The change has been saved successfully!", @"Work Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Product GetProductByGUID(string guid, List<Product> list)
        {
            return list.FirstOrDefault(product => product.GUID == guid);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            Product product = this.comboBox1.SelectedItem as Product;
            if (product != null)
            {
                SelectedProduct = product;
                bool singal = true;
                while (singal)
                {
                    if (product.PartNumber.Length < 11)
                    {
                        product.PartNumber = "0" + product.PartNumber;
                    }
                    else
                    {
                        singal = false;
                    }
                }
                this.txtPartNumber.Text = product.PartNumber;
                this.txtQuantityForOneContainer.Text = product.QuantitySerial;
                this.txtReceiver.Text = product.Receiver;
                this.txtBox.Text = product.Boxes;
                this.txtDescription.Text = product.Description;
                this.txtQuantityUp.Text = product.QuantiryUp;
                this.txtQuantityDown.Text = product.QuantityDown;
                this.txtNETUP.Text = product.NetWeightUp;
                this.txtGrossWTUP.Text = product.GrossWeightUp;
                this.txtNETDOWN.Text = product.NetWeightDown;
                this.txtGrossWTDOWN.Text = product.GrossWeightDown;
                this.txtSupplierCode.Text = product.SupplierCode;
                this.txtSupplierAddress.Text = product.SupplierAddress;
                this.txtEngineeringChange.Text = product.EngineeringChange;
                this.txtQuantityForOneContainer.Text = product.QuantityForOneContainer;
            }
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            if (this.comboBox1.Text.Trim() == "")
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
            if (this.txtGrossWTUP.Text.Trim() == "")
            {
                return false;
            }
            if (this.txtNETUP.Text.Trim() == "")
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




        private void EditProductForm_Shown(object sender, EventArgs e)
        {
            try
            {
                Products = _textUtil.GetProducts(_configPath);
            }
            catch (JsonReaderException)
            {
                MessageBox.Show("The configration file is broken, it will be re-created!");
                Products = new List<Product>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Products = new List<Product>();
            }
            this.comboBox1.DisplayMember = "STWPN";
            this.comboBox1.ValueMember = "STWPN";
            this.comboBox1.SelectedIndexChanged += OnIndexChanged;
            foreach (var product in Products)
            {
                this.comboBox1.Items.Add(product);
            }
            if (this.Products.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
                SelectedProduct = Products[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.MainForm.ChangeDataSource(Products);
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
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
