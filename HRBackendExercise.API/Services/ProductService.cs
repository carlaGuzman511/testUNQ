using HRBackendExercise.API.Abstractions;
using HRBackendExercise.API.Models;
using System.ComponentModel.DataAnnotations;

namespace HRBackendExercise.API.Services
{
	public class ProductService : IProductsService
	{
		private List<Product> _products = new List<Product>();

		// DO NOT MODIFY THE SIGNATURES, JUST THE BODIES

		public Product Create(Product entity)
		{
            entity.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            this._products.Add(entity);
            return entity;
        }

		public Product? GetById(int id)
		{
			return _products.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Product> GetAll()
		{
			return _products;
		}

        public void Update(Product entity)
        {
            Product? product = _products.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null) 
            {
                product.Description = entity.Description;
                product.Price = entity.Price;
                product.SKU = entity.SKU;
            }

            throw new Exception($"Invalid entity. Product ID: {entity.Id} not found.");
        }

        public void Delete(Product entity)
        {
            _products.Remove(entity);
        }
    }
}
