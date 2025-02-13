using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.DataAccessLayer.Abstract;
using OOP.DataAccessLayer.Context;
using OOP.DataAccessLayer.Repositories;
using OOP.EntityLayer.Concrete;

namespace OOP.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<object> GetProductsWithCategory()
        {
            var context = new CampContext();
            var values = context.Products.Select(x=> new
            {
                ProductId = x.ProductId,
                ProductDescription = x.ProductDescription,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                CategoryName = x.Category.CategoryName
            }).ToList();
            return values.Cast<object>().ToList();
        }
    }
}
