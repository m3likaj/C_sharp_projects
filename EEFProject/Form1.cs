using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEFProject
{
    public partial class GuideProcessForm : Form
    {
        public GuideProcessForm()
        {
            InitializeComponent();
        }
        EFTravelDbEntities1 db = new EFTravelDbEntities1();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Guide added successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removedValue = db.Guides.Find(id);
            db.Guides.Remove(removedValue);
            db.SaveChanges();
            MessageBox.Show("Guide deleted successfully!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.Guides.Find(id);
            updatedValue.GuideName = txtName.Text;
            updatedValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Guide updated successfully!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guides.Where(x=> x.GuideId == id).ToList();
            dataGridView1.DataSource = values;

        }
    }
}
