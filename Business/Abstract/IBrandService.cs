using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand Add(Brand brand);
        Brand Update(Brand brand);
        Brand Delete(Brand brand);
        Brand Get(Brand brand);
    }
}
