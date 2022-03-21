using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto 
                             {
                                 CarId = c.CarId, 
                                 CarName = c.CarName, 
                                 ColorName = col.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
