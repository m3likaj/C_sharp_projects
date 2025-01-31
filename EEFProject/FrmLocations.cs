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
    public partial class FrmLocations : Form
    {
        public FrmLocations()
        {
            InitializeComponent();
        }
        EFTravelDbEntities1 db = new EFTravelDbEntities1();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocations_Load(object sender, EventArgs e)
        {
            var values = db.Guides.Select(x=> new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            location.DayNight = textDayNight.Text;
            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Record successfully added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removed = db.Locations.Find(id);
            db.Locations.Remove(removed);
            db.SaveChanges();
            MessageBox.Show("Record successfully deleted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updated = db.Locations.Find(id);
            updated.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updated.City = txtCity.Text;
            updated.Country = txtCountry.Text;
            updated.Price = decimal.Parse(txtPrice.Text);
            updated.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            updated.DayNight = textDayNight.Text;
            db.SaveChanges();
            MessageBox.Show("Record updated successfully");
        }
    }
}
