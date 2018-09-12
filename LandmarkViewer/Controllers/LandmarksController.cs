using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LandmarkViewer.ViewModels;
using System.Threading.Tasks;
using LandmarkViewer.Services;


using LandmarkViewer.Models;
using LandmarkViewer.Repositories;

namespace LandmarkViewer.Controllers
{
    public class LandmarksController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly LandmarkGenerator _landmarkGenerator;
        private readonly LandmarkRepository _landmarkRepository;
        private readonly LocationRepository _locationRepository;

        public LandmarksController()
        {
            _dbContext = new ApplicationDbContext();
            _landmarkGenerator = new LandmarkGenerator();
            _landmarkRepository = new LandmarkRepository(_dbContext);
            _locationRepository = new LocationRepository(_dbContext);
        }

        [HttpGet]
        public ActionResult GetLandmarkDetails(int Id)
        {
            var results = _landmarkRepository.GetLandmarkDetails(Id);
            return View("Details", results);
        }

        public ActionResult List(int Id)
        {
            var results = _landmarkRepository.GetLocationLandmarks(Id);
            return View("List", results);
        }

        [HttpPost]
        public async Task<ActionResult> Create(LocationViewModel viewModel)
        { 
            _locationRepository.AddLocation(viewModel);

            if(viewModel.Location != null)
                _landmarkRepository.AddLandmark(await _landmarkGenerator.GetLandmarkDataByLocationAsync(viewModel), viewModel.Location);

            if(viewModel.Latitude != null && viewModel.Logitude != null)
                _landmarkRepository.AddLandmark(await _landmarkGenerator.GetLandmarkDataByLatLonAsync(viewModel), viewModel.Location);

            return RedirectToAction("List","Landmarks", new { Id = _locationRepository.GetLocation(viewModel.Location) });
        }
    }
}