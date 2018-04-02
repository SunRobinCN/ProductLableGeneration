using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;

namespace ProductLableGeneration
{
    public partial class Main : Form
    {
        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public TextUtil _textUtil = new TextUtil();
        public PDFGenerator _pdfGenerator = new PDFGenerator();
        public string _configPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "products.dat";

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm();
            addForm.Products = Products;
            addForm.MainForm = this;
            addForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                this.txtFilePath.Text = folderBrowserDialog.SelectedPath;
            SettingConfig("path", folderBrowserDialog.SelectedPath);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //this.txtBatchDate.Text = "20141009";
            //this.txtBatchQuantity.Text = "3";
            //this.txtDate.Text = "D140203";
            this.txtFilePath.Text = ReadConfig("path");
        }



        private void OnIndexChanged(object sender, EventArgs e)
        {
            Product product = this.comboBox1.SelectedItem as Product;
            if (product != null)
            {
                SelectedProduct = product;
                this.txtPartNumber.Text = product.PartNumber;
                this.txtQantityInAll.Text = product.QuantityForOneContainer;
                this.txtReceiver.Text = product.Receiver;
                this.txtBoxes.Text = product.Boxes;
                this.txtDescription.Text = product.Description;
                this.txtQuantityUp.Text = product.QuantiryUp;
                this.txtQuantityDown.Text = product.QuantityDown;
                this.txtNETWTDOWN.Text = product.NetWeightDown;
                this.txtGrossWTDOWN.Text = product.GrossWeightDown;
                this.txtNETWTUP.Text = product.NetWeightUp;
                this.txtGrossWTUP.Text = product.GrossWeightUp;
                this.txtSupplierCode.Text = product.SupplierCode;
                this.txtSupplierAddress.Text = product.SupplierAddress;
                this.txtEnginerringChange.Text = product.EngineeringChange;
                this.txtLogisticRefer.Text = product.QuantityForOneContainer;
            }
        }

        public void ChangeDataSource(List<Product> list)
        {
            this.comboBox1.Items.Clear();
            foreach (var product in list)
            {
                this.comboBox1.Items.Add(product);
            }
            if (list.Count > 0)
            {
                this.comboBox1.SelectedIndex = list.Count - 1;
            }
            else
            {
                this.comboBox1.Text = "";
                this.txtPartNumber.Text = "";
                this.txtReceiver.Text = "";
                this.txtBoxes.Text = "";
                this.txtDescription.Text = "";
                this.txtQuantityUp.Text = "";
                this.txtQuantityDown.Text = "";
                this.txtNETWTDOWN.Text = "";
                this.txtGrossWTDOWN.Text = "";
                this.txtNETWTUP.Text = "";
                this.txtGrossWTUP.Text = "";
                this.txtSupplierCode.Text = "";
                this.txtSupplierAddress.Text = "";
                this.txtEnginerringChange.Text = "";
            }

        }

        private bool InputValidate()
        {
            if (this.comboBox1.Text == "" || SelectedProduct == null)
            {
                MessageBox.Show(@"Please select product!", @"Input Error!");
                return false;
            }

            int batchDate;
            int batchQuantity;
            if (txtBatchDate.Text == "" || !int.TryParse(txtBatchDate.Text, out batchDate))
            {
                MessageBox.Show(@"Batch date is not correct!", @"Input Error!");
                return false;
            }
            if (txtContainerQuantity.Text == "" || !int.TryParse(txtContainerQuantity.Text, out batchQuantity))
            {
                MessageBox.Show(@"Batch quantity is not correct!", @"Input Error!");
                return false;
            }

            int serialQuantity;

            if (txtQantityInAll.Text == "" || !int.TryParse(txtQantityInAll.Text, out serialQuantity))
            {
                MessageBox.Show(@"Serial quantity is not correct!", @"Input Error!");
                return false;
            }

            if (this.txtFilePath.Text.Trim() == "")
            {
                MessageBox.Show(@"Please select the folder to store PDF!", @"Input Error!");
                return false;
            }
            int result;
            bool r = int.TryParse(this.txtBatchDate.Text, out result);
            if (!r)
            {
                MessageBox.Show("You batch number is not in right format!");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!InputValidate())
            {
                return;
            }

            Task.Factory.StartNew(() =>
            {
                this.button2.Enabled = false;
                Dictionary<string, List<Label>> dic = GenerateLabelList();
                try
                {
                    _pdfGenerator.ExcecuteAll(dic);
                    MessageBox.Show(@"Congratulations! The PDF has been created successfully!", @"Work Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(@"You don't have enough access to put file in the selected folder!", @"Acess Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.IO.IOException exc)
                {
                    MessageBox.Show(@"There is an exsited file with the same name in the destination folder!",
                        @"Acess Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(exc.Message);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Acess Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.button2.Enabled = true;
                }
            });
        }

        public Dictionary<string, List<Label>> GenerateLabelList()
        {
            string folderPath = this.txtFilePath.Text;
            string startBatchDate = this.txtBatchDate.Text;
            int numberUP = Convert.ToInt32(SelectedProduct.QuantiryUp);
            int numberDown = Convert.ToInt32(SelectedProduct.QuantityDown);
            string batchQuantity  = CountBatchNumber(Convert.ToInt32(this.txtQantityInAll.Text), numberUP, numberDown).ToString();
            int startBatchNumberInt = Convert.ToInt32(startBatchDate) * 10 + 1;
            int endBatchNumberInt = startBatchNumberInt + Convert.ToInt32(this.txtContainerQuantity.Text) - 1;
            int startSerialNumberInt = 1;
            int endSerialNumberInt = Convert.ToInt32(batchQuantity);
            string labelDate = this.txtDate.Text;
            string dock = this.txtDock.Text;
            Dictionary<string, List<Label>> dic = new Dictionary<string, List<Label>>();
            int count = 1;
            for (int i = startBatchNumberInt; i <= endBatchNumberInt; i++)
            {
                string filePath = folderPath + "\\" + SelectedProduct.STWPN + "_" + startBatchDate + "_" + (count++) + ".pdf";
                List<Label> list = new List<Label>();
                for (int j = startSerialNumberInt; j <= endSerialNumberInt; j++)
                {
                    Label label = new Label();
                    Product p = new Product()
                    {
                        GUID = System.Guid.NewGuid().ToString(),
                        STWPN = SelectedProduct.STWPN,
                        QuantitySerial = SelectedProduct.QuantitySerial,
                        PartNumber = SelectedProduct.PartNumber,
                        Boxes = SelectedProduct.Boxes,
                        Description = SelectedProduct.Description,
                        EngineeringChange = SelectedProduct.EngineeringChange,
                        GrossWeightDown = SelectedProduct.GrossWeightDown,
                        NetWeightDown = SelectedProduct.NetWeightDown,
                        GrossWeightUp = SelectedProduct.GrossWeightUp,
                        NetWeightUp = SelectedProduct.NetWeightUp,
                        QuantiryUp = SelectedProduct.QuantiryUp,
                        QuantityDown = SelectedProduct.QuantityDown,
                        Receiver = SelectedProduct.Receiver,
                        SupplierAddress = SelectedProduct.SupplierAddress,
                        SupplierCode = SelectedProduct.SupplierCode,
                        Dock = dock
                    };
                    label.Product = p;
                    label.Date = labelDate;
                    label.BatchNumber = i.ToString();
                    label.SerialNumber = startBatchDate + j.ToString("D3");
                    label.TotalAmount = this.txtQantityInAll.Text;
                    label.FixedQuantity = j % 2 == 0 ? label.Product.QuantityDown : label.Product.QuantiryUp;
                    label.Product.NetWeight = j % 2 == 0 ? label.Product.NetWeightDown : label.Product.NetWeightUp;
                    label.Product.GrossWeight = j % 2 == 0 ? label.Product.GrossWeightDown : label.Product.GrossWeightUp;
                    label.LogisticRefer = this.txtLogisticRefer.Text.Trim();
                    list.Add(label);
                }
                dic.Add(filePath, list);
            }
            return dic;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveProductForm removeForm = new RemoveProductForm();
            removeForm.Products = this.Products;
            removeForm.MainForm = this;
            removeForm.ShowDialog();
        }

        private void Main_Shown(object sender, EventArgs e)
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
            }
        }

        private void softwareVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Version 3.0 --- Modify the font size", @"Software Version");
        }

        private void contactMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"1035168505@qq.com", @"Contact Information");
        }

        private void SettingConfig(string name, string value)
        {
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyConfigFile);
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
            appSettings.Settings.Remove(name);
            appSettings.Settings.Add(name, value);
            config.Save();
        }

        private string ReadConfig(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            string value = ConfigurationManager.AppSettings[key];
            return value;

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditProductForm editForm = new EditProductForm();
            editForm.Products = this.Products;
            editForm.MainForm = this;
            editForm.ShowDialog();
        }

        private int CountBatchNumber(int totalAmount, int up = 30, int down = 36)
        {
            int batchAmount = 0;
            bool singal = true;
            int countLoop = 1;
            while (singal)
            {
                if (countLoop % 2 == 1)
                {
                    if (totalAmount > up)
                    {
                        totalAmount = totalAmount - up;
                        batchAmount = batchAmount + 1;
                    }
                    else
                    {
                        batchAmount = batchAmount + 1;
                        singal = false;
                    }
                }
                else
                {
                    if (totalAmount > down)
                    {
                        totalAmount = totalAmount - down;
                        batchAmount = batchAmount + 1;
                    }
                    else
                    {
                        batchAmount = batchAmount + 1;
                        singal = false;
                    }
                }
                countLoop++;
            }
            return batchAmount;
        }
    }
}
