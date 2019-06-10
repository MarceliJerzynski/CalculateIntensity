using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Phase               //klasa fazy, zawiera w sobie obwody
    {
        List<Socket> socket_list = new List<Socket>();          //lista obwodow gniazdowych
        List<Lighting> lighting_list = new List<Lighting>();    //lista obwodow oswietlacjacych
        private float Ib;                                       //obciazenie calej fazy
        private float x;                                          //różnicówka
        public float[] tab = { 16, 25, 40, 63 };                  //rodzaje różnicówek
        public void set_Ib()                                    //funkcja obliczajaca to obciazenie
        {
            Ib = 0;
            for(int i = 0; i < socket_list.Count(); i++)
            {
                Ib += socket_list[i].get_I();                   //sumuj obciazenia z obwodow gniazdowych
            }
            for (int i = 0; i < lighting_list.Count(); i++)
            {
                Ib += lighting_list[i].get_I();                 //sumuj obciazenia z obwodow oswietlajacych
            }
        }
        public float get_Ib()                                   //funkcja zwracająca I, ponieważ I jest prywatne ( hermetyzacja)
        {
            return Ib/4;
        }
        public List<Socket> get_socket()
        {
            return socket_list;
        }
        public List<Lighting> get_lighting()
        {
            return lighting_list;
        }

        public void calculate_x()
        {
            x = 0;
            float pom = 0;
            for(int i = 3; i >= 0; i--)
            {
                if (x < tab[i]*4)
                {
                    pom = tab[i];
                }
            }
            x = pom;
        }

        public float get_x()
        {
            return x;
        }
    }
}
