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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EFTravelDbEntities1 db = new EFTravelDbEntities1();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
     
            lblLocationCount.Text = db.Locations.Count().ToString();
            lblCapacityCount.Text = db.Locations.Sum(x=> x.Capacity).ToString();
            lblGuideCount.Text = db.Guides.Count().ToString();
            lblAvgCapacity.Text = db.Locations.Average(x=> x.Capacity).ToString();
            lblAvgPrice.Text = db.Locations.Average(x => x.Price)?.ToString("0.00") + "₺";
            int lastCountryId = db.Locations.Max(x => x.LocationId);
            lblLastCountryAdded.Text = db.Locations.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lblCapadocciaCapacity.Text = db.Locations.Where(x => x.City == "Capadoccia").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblAvgTurkiyeCapacity.Text = db.Locations.Where(x=> x.Country == "Turkiye").Average(y => y.Capacity).ToString();
            var guideId= db.Locations.Where(x=> x.City=="Rome").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuide.Text = db.Guides.Where(x=> x.GuideId == guideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            var maxCapacity = db.Locations.Max(x => x.Capacity);
            lblMaximumCapacityTour.Text = db.Locations.Where(x=> x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault();
            var highestPrice = db.Locations.Max(x => x.Price);
            lblMostExpensiveTour.Text = db.Locations.Where(x=> x.Price == highestPrice).Select(y=>y.City).FirstOrDefault();
            var aysegulId = db.Guides.Where(x => x.GuideName == "Aysegul").Select(y => y.GuideId).First();
            lblNoAysegulTours.Text = db.Locations.Where(x=> x.GuideId == aysegulId).Count().ToString();




        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}