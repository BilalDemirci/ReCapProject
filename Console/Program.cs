using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal());

Car car1 = new Car { Id = 11, BrandId = 2, ColorId = 5,ModelYear=2020,DailyPrice=1430000,Description="2020 Mustang"};
Car car2 = new Car { Id = 11, BrandId = 2, ColorId = 5, ModelYear = 2021, DailyPrice = 1500000, Description = "2021 Mustang" };
//carManager.Add(car1);
//carManager.Delete(car1);
//carManager.Update(car2);

Console.WriteLine("------------------------------------------------------");
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}
Console.WriteLine("------------------------------------------------------");

BrandManager brandManager = new BrandManager(new EfBrandDal());
Brand brand1 = new Brand {BrandId = 7, BrandName = "Aston Martin" };
Brand brand2 = new Brand { BrandId = 7, BrandName = "Chevrolet" };
//brandManager.Add(brand1);
//brandManager.Delete(brand1);
//brandManager.Update(brand2);
brandManager.Get(brand2);
Console.WriteLine("------------------------------------------------------");
foreach (var brand in brandManager.GetAll())
{
    Console.WriteLine(brand.BrandName);
}
Console.WriteLine("------------------------------------------------------");

ColorManager colorManager = new ColorManager(new EfColorDal());
Color color1 = new Color { ColorId = 11, ColorName = "Kahverengi" };
Color color2 = new Color { ColorId = 11, ColorName = "Pembe" };
Color color3 = new Color { ColorId = 12, ColorName = "Eflatun" };//Oluşturuldu fakat veri tabanında yok;

//colorManager.Add(color1);
//colorManager.Delete(color1);
//colorManager.Update(color2);
colorManager.Get(color2);
colorManager.Get(color3);

Console.WriteLine("------------------------------------------------------");

foreach (var color in colorManager.GetAll())
{
    Console.WriteLine(color.ColorName);
}

Console.WriteLine("------------------------------------------------------");

foreach(var car in carManager.GetCarDetails())
{
    Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
}

Console.ReadLine();