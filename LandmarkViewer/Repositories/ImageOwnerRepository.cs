using LandmarkViewer.Models;
using LandmarkViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandmarkViewer.Repositories
{
    public class ImageOwnerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageOwnerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public ImageOwnerViewModel AddOwner(ImageOwnerViewModel viewModel)
        {
            var owner = new ImageOwner()
            {
                OwnerName = viewModel.OwnerName,
                OwnerImageUrl = viewModel.OwnerImageUrl
            };

            _dbContext.ImageOwners.Add(owner);
            _dbContext.SaveChanges();

            return viewModel;
        }

        public ImageOwnerViewModel GetOwner(LandmarkImage image)
        {
            var owner = new ImageOwnerViewModel()
            {
                OwnerName = image.Owner.OwnerName,
                OwnerImageUrl = image.Owner.OwnerImageUrl
            };

            return owner;
        }
    }
}