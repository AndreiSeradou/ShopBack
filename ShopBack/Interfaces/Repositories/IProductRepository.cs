using ShopBack.Models;
using System.Collections.Generic;

namespace ShopBack.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IReadOnlyCollection<Product> GetAll();
        bool Create(Product model);
        bool Update(Product oldModel, Product newModel);
        bool Delete(Product model);
        void Save();
    }
}
