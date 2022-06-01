using ShopBack.Interfaces.Repositories;
using ShopBack.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ShopBack.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            using (StreamReader r = new StreamReader(@"product.json"))
            {
                string json = r.ReadToEnd();
                _products = JsonConvert.DeserializeObject<List<Product>>(json)!;

                if (_products is null)
                {
                    _products = new List<Product>();
                }
            }
        }

        public bool Create(Product model)
        {
            var product = _products.FirstOrDefault(x => x.Name == model.Name);

            if (product != null)
            {
                return false;
            }

            _products.Add(model);

            return true;
        }

        public bool Delete(Product model)
        {
            var product = _products.FirstOrDefault(p => p.Name == model.Name);

            if (product != null && _products.Contains(product))
            {
                _products.Remove(product);

                return true;
            }

            return false;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _products;
        }

        public bool Update(Product oldModel, Product newModel)
        {
            if (Delete(oldModel))
            {
                Create(newModel);

                return true;
            }

            return false;
        }

        public void Save()
        {
            using (StreamWriter file = File.CreateText(@"product.json"))
            {
                var json = JsonConvert.SerializeObject(_products);
                file.Write(json);
            }
        }
    }
}
