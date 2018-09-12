using System;
using System.Collections.Generic;
using LandmarkViewer.Models;
using System.Linq;
using System.Web;

namespace LandmarkViewer.ViewModels
{
    public class LandmarkViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string PathAlias { get; set; }
        public string Published { get; set; }
        public int Views { get; set; }
        public Location Location { get; set; }
        public ImageOwner Owner { get; set; }
        public IEnumerable<LandmarkImage> Landmarks { get; set; }
    }
}