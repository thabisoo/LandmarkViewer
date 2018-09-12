using System;
using System.Collections.Generic;
using LandmarkViewer.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LandmarkViewer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LandmarkImage> LandmarkImages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ImageOwner> ImageOwners { get; set; }
    }
}