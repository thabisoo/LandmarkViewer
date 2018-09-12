using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public string Latitude { get; set; }
        public string Logitude { get; set; }
    }
}