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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Color Add(Color color)
        {
            using (CarRecapProjectContext context = new CarRecapProjectContext())
            {
                var addedColor = context.Entry(color);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }

            if (color.ColorName.Length >= 2)
            {
                Console.WriteLine("Renk Eklendi!");
            }
            else
            {
                Console.WriteLine("Renk ismi en az 2 karakter uzunluğunda olmalıdır!");
            }
            return color;
        }

        public Color Delete(Color color)
        {
            if (color == null)
            {
                Console.WriteLine("Silinecek renk bilgisi bulunamadı!");
                return null;
            }

            Color colorToDelete = _colorDal.Get(c=> c.ColorId == color.ColorId);

            if (colorToDelete == null)
            {
                Console.WriteLine("Silinecek renk bilgisi bulunamadı!");
            }

            _colorDal.Delete(colorToDelete);
            Console.WriteLine(color.ColorName + " adlı renk silindi!");
            return colorToDelete;
        }

        public Color Get(Color color)
        {
            using (CarRecapProjectContext context = new CarRecapProjectContext())
            {
                Color getColor = context.Colors.FirstOrDefault(c => c.ColorId == color.ColorId);

                if (getColor!=null)
                {
                    Console.WriteLine("Renk : " + getColor.ColorName);
                }else
                {
                    Console.WriteLine("Renk bulunamadı!");
                    return null;
                }

                return getColor;
            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color Update(Color color)
        {
            if (color == null)
            {
                Console.WriteLine("Güncellenecek renk bilgisi bulunamadı!");
                return null;
            }

            Color colorToUpdate = _colorDal.Get(c=>c.ColorId == color.ColorId);

            if (colorToUpdate == null)
            {
                Console.WriteLine("Güncellenecek renk bilgisi bulunamadı!");
            }
            //güncelleme 
            colorToUpdate.ColorName = color.ColorName;
            //kaydetme
            _colorDal.Update(colorToUpdate);
            Console.WriteLine(color.ColorId + " idsine sahip renk ismi güncellendi!");
            return colorToUpdate;
        }
    }
}
