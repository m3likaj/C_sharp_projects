using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP.BusinessLayer.Abstract;
using OOP.BusinessLayer.Concrete;
using OOP.DataAccessLayer.EntityFramework;
using OOP.EntityLayer.Concrete;

namespace OOP.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var productValues = _productService.TGetAll();
            dataGridView1.DataSource = productValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ProductName = txtName.Text,
                ProductPrice = decimal.Parse(txtPrice.Text),
                ProductStock = int.Parse(txtStock.Text),
                ProductDescription = txtDetails.Text,
                CategoryId = int.Parse(cmbCategory.SelectedValue.ToString())
            };
            _productService.TInsert(product);
            MessageBox.Show("Record added successfully");
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource=values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            MessageBox.Show("Record deleted successfully!");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = _productService.TGetById(id);
            dataGridView1.DataSource = new List<object> { values };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updatedValues = _productService.TGetById(id);
            updatedValues.ProductName = txtName.Text;
            updatedValues.ProductPrice = decimal.Parse(txtPrice.Text);
            updatedValues.ProductStock = int.Parse(txtStock.Text);
            updatedValues.ProductDescription = txtDetails.Text;
            updatedValues.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            _productService.TUpdate(updatedValues);
            MessageBox.Show("Record updated successfully");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource= values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
    }
}
