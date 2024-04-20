using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=3,ModelYear=2021,DailyPrice=750000,Description="2021 Temiz"},
                new Car {Id=2,BrandId=2,ColorId=3,ModelYear=2018,DailyPrice=600000,Description="2018 Temiz"},
                new Car {Id=3,BrandId=1,ColorId=3,ModelYear=2002,DailyPrice=250000,Description="2002 Ama 2024 Gibi"},
                new Car {Id=4,BrandId=3,ColorId=3,ModelYear=2016,DailyPrice=500000,Description="2016 Model Kazalı"},
                new Car {Id=5,BrandId=2,ColorId=3,ModelYear=2024,DailyPrice=1000000,Description="0 Kilometre"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c=> c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id == car.Id);
            if(carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }
    }
}
