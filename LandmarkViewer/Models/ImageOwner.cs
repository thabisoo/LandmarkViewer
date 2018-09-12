using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Models
{
    public class ImageOwner
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string OwnerImageUrl { get; set; }
    }
}