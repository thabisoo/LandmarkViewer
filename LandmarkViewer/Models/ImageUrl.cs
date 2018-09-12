using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Models
{
    public class ImageUrl
    {
        public int Id { get; set; }
        public string SmallImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string LargeImageUrl { get; set; }


        [Required]
        public int LandmarkImageId { get; set; }
        public LandmarkImage Image { get; set; }
    }
}