using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Socket : Circuit  //klasa obwodu gniazdowoego
    {

        public Socket()     //konstruktor przypisujący mocy i cosinusowi odpowiednie wartosci
        {
            P = 2500F;
            cos = 0.9F;
        }
        public override void calculate_I()  //funkcja obliczająca obciążenie
        {
            I = P / (Constants.Unf * cos); 
        }
    }
}
