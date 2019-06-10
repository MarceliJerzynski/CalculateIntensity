using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Phases    //klasa zawierająca w sobie 3 fazy
    {
        List<Phase> phase = new List<Phase>();      //lista zawierajaca fazy, dzieki temu ze fazy sa w kolekcji List, będzie mozna latwo
                                                    //rozbudowac program na wieksza ilosc faz 
        public List<Phase> get_phase()               //funkcja zwracaja listę faz  
        {
            return phase;
        }
    }
}
