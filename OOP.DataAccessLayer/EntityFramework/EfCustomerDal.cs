﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.DataAccessLayer.Abstract;
using OOP.DataAccessLayer.Repositories;
using OOP.EntityLayer.Concrete;

namespace OOP.DataAccessLayer.EntityFramework
{
    internal class EfCustomerDal: GenericRepository<Customer>, ICustomerDal
    {
    }
}
