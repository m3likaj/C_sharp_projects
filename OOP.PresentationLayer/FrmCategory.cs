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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
             Category category = new Category();
             category.CategoryName = txtName.Text;
             category.CategoryStatus = true;
             _categoryService.TInsert(category);
             MessageBox.Show("Record added successfully");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            MessageBox.Show("Record deleted successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtID.Text);
            var updatedValue = _categoryService.TGetById(updatedId);
            updatedValue.CategoryName = txtName.Text;
            if (rdbPassive.Checked)
            {
                updatedValue.CategoryStatus = false;
            }
            else
            {
                updatedValue.CategoryStatus = true;
            }
            _categoryService.TUpdate(updatedValue);
            
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = new List<object> { values };
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
