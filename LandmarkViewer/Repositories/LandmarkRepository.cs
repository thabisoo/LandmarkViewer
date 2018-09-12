using LandmarkViewer.Models;
using LandmarkViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Repositories
{
    public class LandmarkRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ImageOwnerRepository _imageOwnerRepository;

        public LandmarkRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _imageOwnerRepository = new ImageOwnerRepository(_dbContext);
        }

        public LandmarkViewModel GetLocationLandmarks(int location)
        {
            var viewModel = new LandmarkViewModel();
            viewModel.Landmarks = _dbContext.LandmarkImages.Where(l => l.LocationId == location);

            return viewModel;
        }

        public LandmarkViewModel GetLandmarkDetails(int Id)
        {
            var landmark = _dbContext.LandmarkImages.Where(l => l.Id == Id).SingleOrDefault();

            var viewModel = new LandmarkViewModel()
            {
                Title = landmark.Title,
                Description = landmark.Description,
                Views = landmark.Views,
                Path = landmark.MediumImageUrl
            };

            return viewModel;
        }

        public void AddLandmark(IEnumerable<LandmarkImage> images, string location)
        {
            foreach (var image in images)
            {
                var imageFound = new LandmarkImage();
                var owner = _imageOwnerRepository.AddOwner(_imageOwnerRepository.GetOwner(image));

                if(!_dbContext.LandmarkImages.Any())
                    imageFound = _dbContext.LandmarkImages.SingleOrDefault(i => i.MediumImageUrl == image.MediumImageUrl);

                if(imageFound == null || imageFound.MediumImageUrl == null)
                { 
                    var landmarkImage = new LandmarkImage()
                    {
                        Title = image.Title,
                        Description = image.Description,
                        Path = image.Path,
                        PathAlias = image.PathAlias,
                        Published = image.Published,
                        Views = image.Views,
                        MediumImageUrl = image.MediumImageUrl,
                        LocationId = _dbContext.Locations.First(l => l.Name == location).Id,
                        OwnerId = _dbContext.ImageOwners.First(o => o.OwnerName == owner.OwnerName).Id
                    };

                    _dbContext.LandmarkImages.Add(landmarkImage);
                    _dbContext.SaveChanges();
                }
                
            }

            
        }

    }
}