using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color Add(Color color);
        Color Update(Color color);
        Color Delete(Color color);
        Color Get(Color color);
    }
}
