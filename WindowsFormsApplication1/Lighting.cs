using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Lighting : Circuit
    {
        public Lighting()   //konstruktor przypisujący mocy i cosinusowi odpowiednie wartosci
        {
            P = 1500F;
            cos = 1.0F;
        }
        public override void calculate_I() //funkcja obliczająca obciążenie
        {
            I = P / (Constants.Unf * cos);
        }
    }
}
