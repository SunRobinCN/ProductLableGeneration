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
    public partial class RemoveProductForm : Form
    {
        public List<Product> Products { get; set; }
        public TextUtil _textUtil = new TextUtil();
        public string _path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "products.dat";
        public Main MainForm { get; set; }

        public RemoveProductForm()
        {
            InitializeComponent();
        }

        private void RemoveProductForm_Load(object sender, EventArgs e)
        {
            var list = new BindingList<Product>(Products);
            this.dataGridView.DataSource = list;
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Product> newList = new List<Product>();
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                Product item = new Product();
                item.STWPN = dr.Cells[1].Value.ToString();
                newList.Add(item);
            }
            List<Product> updatedList = new List<Product>();
            foreach (var product in Products)
            {
                var p = GetProductByPN(product.STWPN, newList);
                if (p != null)
                {
                    updatedList.Add(product);
                }
            }

            _textUtil.ArchiveProducts(_path, updatedList);
            this.MainForm.ChangeDataSource(updatedList);
            this.Close();
        }

        private Product GetProductByPN(string pn, List<Product> list)
        {
            return list.FirstOrDefault(product => product.STWPN == pn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(item.Index);
            }
        }
    }
}
