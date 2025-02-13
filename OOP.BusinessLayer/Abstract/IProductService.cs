﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.EntityLayer.Concrete;

namespace OOP.BusinessLayer.Abstract
{
    public interface IProductService: IGenericService<Product>
    {
        List<object> TGetProductsWithCategory();
    }
}
