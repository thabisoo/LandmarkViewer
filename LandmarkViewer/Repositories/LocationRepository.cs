using LandmarkViewer.Models;
using LandmarkViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Repositories
{
    public class LocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void AddLocation(LocationViewModel viewModel)
        {
            var lat = viewModel.Latitude;
            var lon = viewModel.Logitude;

            var locationByName = _dbContext.Locations.Where(l => l.Name == viewModel.Location).FirstOrDefault();
            var locationByLatLon = _dbContext.Locations.Where(l => l.Name == viewModel.Location && l.Logitude == lon && l.Latitude == lat).FirstOrDefault();

            if (locationByName == null && locationByLatLon == null)
            {
                var location = new Location()
                {
                    Name = viewModel.Location,
                    Latitude = viewModel.Latitude,
                    Logitude = viewModel.Logitude
                };

                _dbContext.Locations.Add(location);
                _dbContext.SaveChanges();
            }
        }

        public int GetLocation(string location)
        {
            return _dbContext.Locations.FirstOrDefault(l => l.Name.Equals(location)).Id;
        }

        public LocationViewModel GetLocationsList()
        {
            var viewModel = new LocationViewModel();
            viewModel.Locations = _dbContext.Locations;
            return viewModel;
        }
    }
}