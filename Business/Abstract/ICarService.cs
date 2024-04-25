using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car  Add(Car car);
        Car Update(Car car);
        Car Delete(Car car);

        List<CarDetailDto> GetCarDetails();
    }
}
