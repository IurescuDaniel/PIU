using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public interface IStocareData
    {
        void AddMaterie(Materie m);
        List<Materie> GetMaterii();
        Materie GetMaterie(string nume); 
        bool UpdateMaterie(Materie m);  
    }
}
