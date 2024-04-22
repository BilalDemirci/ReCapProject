using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public Car Add(Car car)
        {
            using (CarRecapProjectContext context = new CarRecapProjectContext())
            {
                var addedCar = context.Entry(car);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }

            if (car.Description.Length >= 5 && car.DailyPrice > 0)
            {
                Console.WriteLine("Araba Eklendi");
            }
            else
            {
                Console.WriteLine("Araba açıklaması minimum 5 karakterden oluşmalıdır ve Fiyatı 0'dan büyük olmalıdır.");
            }
            return car;
        }

        public Car Delete(Car car)
        {
            if(car == null)
            {
                Console.WriteLine("Silinecek araba bilgisi bulunamadı!");
                return null;
            }
            //Araba nesnesinini idsini kullanarak veritabanından arabyı bulmak
            Car carToDelete = _carDal.Get(c => c.Id == car.Id);
            //arabayı bulamazsa null
            if(carToDelete == null)
            {
                Console.WriteLine("Silinecek araba sistemde kayıtlı değil!");
                return null;
            }

            //Araba silme işlemi
            _carDal.Delete(carToDelete);
            Console.WriteLine(car.Id + "-" + car.Description + " İd ve açıklamayla kayıtlı bulunana araba silindi");
            return carToDelete;
        }

        public List<Car> GetAll()
        {
            //iş kodları vs.
            return _carDal.GetAll();
        }

        public Car Update(Car car)
        {
            if (car == null)
            {
                Console.WriteLine("Güncellenecek araba bilgisi bulunamadı!");
                return null;
            }

            Car carToUpdate = _carDal.Get(c => c.Id == car.Id);

            if (carToUpdate == null)
            {
                Console.WriteLine("Güncellenecek araba bilgisi bulunamadı!");
                return null;
            }

            //Araba bilgisi güncelle
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

            //veritabanına kaydetme
            _carDal.Update(carToUpdate);
            Console.WriteLine(car.Id + " idsine sahip araba güncellendi!");
            return carToUpdate;
        }
    }
}
