using LandmarkViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmarkViewer.ViewModels
{
    public class LocationViewModel
    {
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public IEnumerable<Location> Locations {get;set;}
    }
}