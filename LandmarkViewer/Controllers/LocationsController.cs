using LandmarkViewer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmarkViewer.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly LocationRepository _locationRepository;

        public LocationsController()
        {
            _dbContext = new ApplicationDbContext();
            _locationRepository = new LocationRepository(_dbContext);
        }
        // GET: Locations
        public ActionResult Index()
        {
            var results = _locationRepository.GetLocationsList();
            return View("_List",results);
        }
    }
}