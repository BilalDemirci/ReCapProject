using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public Brand Add(Brand brand)
        {
            using (CarRecapProjectContext context = new CarRecapProjectContext())
            {
                var addedBrand = context.Entry(brand);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();

                if(brand.BrandName.Length >= 2)
                {
                    Console.WriteLine("Marka Eklendi!");
                }else
                {
                    Console.WriteLine("Marka ismi en az 2 karakter uzunluğunda olmalıdır");
                }
                return brand;
            }
        }

        public Brand Delete(Brand brand)
        {
            if (brand==null)
            {
                Console.WriteLine("Silinecek marka bilgisi bulunamadı!");
                return null;
            }

            Brand brandToDelete = _brandDal.Get(b => b.BrandId == brand.BrandId);

            if (brandToDelete==null)
            {
                Console.WriteLine("Silinecek marka bilgisi bulunamadı!");
                return null;
            }

            _brandDal.Delete(brandToDelete);
            Console.WriteLine(brand.BrandName + " adlı marka silindi");
            return brandToDelete;
        }

        public Brand Get(Brand brand)
        {
            using (CarRecapProjectContext context = new CarRecapProjectContext())
            {
                Brand getBrand = context.Brands.FirstOrDefault(b => b.BrandId == brand.BrandId);

                if (getBrand != null)
                {
                    Console.WriteLine("Marka : " + getBrand.BrandName);
                }
                else
                {
                    Console.WriteLine("Marka Bulunamadı");
                    return null;
                }

                return getBrand;
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand Update(Brand brand)
        {
            if (brand == null) 
            {
                Console.WriteLine("Güncellenecek marka bilgisi bulunamadı!");
                return null;
            }

            Brand brandToUpdate = _brandDal.Get(b => b.BrandId == brand.BrandId);

            if (brandToUpdate == null)
            {
                Console.WriteLine("Güncellenecek marka bilgisi bulunamadı!");
            }
            //güncelleme
            brandToUpdate.BrandName = brand.BrandName;
            //kaydetme
            _brandDal.Update(brandToUpdate);
            Console.WriteLine(brand.BrandId + " idsine sahip marka bilgileri güncellendi!");
            return brandToUpdate;

        }
    }
}
