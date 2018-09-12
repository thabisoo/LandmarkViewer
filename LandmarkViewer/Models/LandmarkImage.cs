using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Models
{
    public class LandmarkImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string PathAlias { get; set; }
        public string Published { get; set; }
        public int Views { get; set; }
        public string MediumImageUrl { get; set; }
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public ImageOwner Owner { get; set; }
    }
}