using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.BusinessLayer.Abstract;
using OOP.DataAccessLayer.Abstract;
using OOP.EntityLayer.Concrete;

namespace OOP.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName!="" && entity.CustomerSurname.Length>=3 &&
                entity.CustomerCity != null && entity.CustomerSurname!=""  && entity.CustomerName.Length<=30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                //show error message
            }
        }

        public void TUpdate(Customer entity)
        {
            if (entity.CustomerId!=0)
            {
                _customerDal.Update(entity);
            }
            

        }
    }
}
