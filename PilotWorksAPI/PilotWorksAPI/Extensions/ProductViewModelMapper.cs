using PilotWorksAPI.Core.EntityLayer;
using PilotWorksAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilotWorksAPI.Extensions
{
    public static class ProductViewModelMapper
    {
        public static ProductViewModel ToViewModel(this Product entity)
        {
            return new ProductViewModel
            {
                ProductID = entity.ProductID,
                ProductName = entity.Name,
                ProductNumber = entity.ProductNumber
            };
        }

        public static Product ToEntity(this ProductViewModel viewModel)
        {
            return new Product
            {
                ProductID = viewModel.ProductID,
                Name = viewModel.ProductName,
                ProductNumber = viewModel.ProductNumber
            };
        }
    }
}
