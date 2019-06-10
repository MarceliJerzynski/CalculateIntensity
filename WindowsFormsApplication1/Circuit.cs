using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    abstract class Circuit  //abstrakcyjna klasa obwodu, dziedziczą po niej Socket i Lighting
    {
        protected float P;              //Moc obwodu
        protected float cos;            //Cosinus potrzebny do wzoru
        protected float I;              //Obciązenie z danego obwodu
        public abstract void calculate_I(); //abstrakcyjna klasa licząca obciążenie
        public float get_I()            //funkcja zwracająca I, ponieważ I jest prywatne ( hermetyzacja) 
        {
            return I;
        }
    }
}
