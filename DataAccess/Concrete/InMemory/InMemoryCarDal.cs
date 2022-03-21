using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                    new Car{CarId=1, BrandId=1, ColorId=1, CarName="", DailyPrice=1000, ModelYear="1999", Description="Mercedes"},
                    new Car{CarId=2, BrandId=1, ColorId=3, CarName="", DailyPrice=5000, ModelYear="2005", Description="BMW"},
                    new Car{CarId=3, BrandId=2, ColorId=4, CarName="", DailyPrice=10000, ModelYear="2019", Description="Opel"},
                    new Car{CarId=4, BrandId=3, ColorId=2, CarName="", DailyPrice=50000, ModelYear="2022", Description="Tesla"},
                    new Car{CarId=5, BrandId=2, ColorId=1, CarName="", DailyPrice=200000, ModelYear="2006", Description="Porsche"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetByCarId(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
