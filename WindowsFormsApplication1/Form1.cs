using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void add_element_to_socket(ref Phases phases, int i)    //dodaj element do fazy i oblicz jego I, "i" to indeks fazy
        {
            phases.get_phase()[i].get_socket().Add(new Socket());
            phases.get_phase()[i].get_socket()[phases.get_phase()[i].get_socket().Count()-1].calculate_I();
            Console.WriteLine("dodano obwod gniazdowy do fazy " + i.ToString());
        }
        private void add_element_to_lighting(ref Phases phases, int i)
        {
            phases.get_phase()[i].get_lighting().Add(new Lighting());   //dodaje do kazdej fazy number_socket/3 obwodow gniazd
            phases.get_phase()[i].get_lighting()[phases.get_phase()[i].get_lighting().Count()-1].calculate_I();
            Console.WriteLine("dodano obwod oświetleniowy do fazy " + i.ToString());
        }

        private void show_results(ref Phases phases)
        {
            //pokaż obciążenia
            label4.Text = phases.get_phase()[0].get_Ib().ToString();    
            label5.Text = phases.get_phase()[1].get_Ib().ToString();
            label6.Text = phases.get_phase()[2].get_Ib().ToString();
            //pokaż różnicówki
            label10.Text = phases.get_phase()[0].get_x().ToString();
            label9.Text = phases.get_phase()[1].get_x().ToString();
            label8.Text = phases.get_phase()[2].get_x().ToString();
            //pokaz ilosc obw gniazdowych
            label17.Text = phases.get_phase()[0].get_socket().Count().ToString();
            label16.Text = phases.get_phase()[1].get_socket().Count().ToString();
            label15.Text = phases.get_phase()[2].get_socket().Count().ToString();
            //pokaz ilosc obw oswietleniowych
            label13.Text = phases.get_phase()[0].get_lighting().Count().ToString();
            label12.Text = phases.get_phase()[1].get_lighting().Count().ToString();
            label11.Text = phases.get_phase()[2].get_lighting().Count().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number_socket;
            int number_lighting;
            if (Int32.TryParse(textBox1.Text, out number_socket))  //sprawdzenie poprawnosci wczytanej liczby
            {
                if (Int32.TryParse(textBox2.Text, out number_lighting))    //sprawdzenie poprawnosci wczytanej liczby
                {
                    //tutaj mamy poprawne dane
                    Phases phases = new Phases();
                    for (int i = 0; i < Constants.number_of_phases; i++)
                    {
                        phases.get_phase().Add(new Phase());    //utworzone zostaly 3 fazy, narazie nie mają w srodku nic 
                        Console.WriteLine("dodano fazę");
                    }
                    
                    for(int j = 0; j < number_socket/3; j++)
                    {
                        for (int i = 0; i < Constants.number_of_phases; i++)
                        {
                               //dodaje do kazdej fazy number_socket/3 obwodow gniazd
                            
                            add_element_to_socket(ref phases, i);
                        }
                    } 

                    if (number_socket%3 == 1 )
                    {
                        //jesli liczba obw gniazd jest niepodzielna przez 3 i reszta wynosi 1, dodaje jeden obwod do pierwszej fazy
                        
                        add_element_to_socket(ref phases, 0);
                    }
                    if (number_socket % 3 == 2)
                    {
                        //jesli liczba obw gniazd jest niepodzielna przez 3 i reszta wynosi 2, dodaje po 1 obwodzie do 2 pierwszych faz
                        for (int i = 0; i < 2; i++)
                        {
                           
                            add_element_to_socket(ref phases, i);
                        }
                    }
                    //----koniec obwodow gniazdowych, czas na oswietleniowe
                    for (int j = 0; j < number_lighting / 3; j++)
                    {
                        for (int i = 0; i < Constants.number_of_phases; i++)
                        {
                            //dodaje do kazdej fazy number_socket/3 obwodow gniazd
                            
                            add_element_to_lighting(ref phases, i);
                        }
                    }
                
                    if (number_lighting % 3 == 1)
                    {
                        //jesli liczba obw osw jest niepodzielna przez 3 i reszta wynosi 1, dodaje jeden obwod do 3 fazy
                      
                        add_element_to_lighting(ref phases, 2);
                    }
                    if (number_lighting % 3 == 2)
                    {
                        //jesli liczba obw osw jest niepodzielna przez 3 i reszta wynosi 2, dodaje po 1 obwodzie do 2 ostatnich faz
                        for (int i = 1; i >= 0; i--)
                        {
                            //   phases.get_phase()[i].get_lighting().Add(new Lighting());
                            add_element_to_lighting(ref phases, i);
                        }
                    }
                    //w tym momencie w kazdej fazie mamy odpowiednia ilosc obwodow, taki sposob ich dodawania zapewnia nam odpowiednie
                    //obciazenia na kazdej fazie ( Najwieksza roznica obciazen moze wynies 2.5kW)

                    //oblicz obciazenia na calej fazie
                    for(int i = 0; i < Constants.number_of_phases;i++)
                    {
                        phases.get_phase()[i].set_Ib();
                        phases.get_phase()[i].calculate_x();
                    }
                    //wyswietl obciazenia

                    show_results(ref phases);

                }
                else
                {
                    //obsluga bledu
                    textBox2.Text = "Błędne dane";
                }
            }
            else
            {
                //obsluga bledu
                textBox1.Text = "Błędne dane";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string message = "Krzysztof Klak\nJakub Nowak";
            string caption = "Autorzy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string message = "Założeniami projektu było zaprezentowanie za pomocą programu sposób bilansowania obciążeń na fazach . Zagadnienie zostało zrealizowane na podstawie przy pomocy programu Visual Studio . Główną funkcją, którą wykonywać na program było na podstawie obliczonego prądu wraz z uwzględnieniem współczynnika jednoczesności , czyli prawdopodobieństwa równoczesnej pracy obwodów przypadających na daną fazę , wyrównywać obciążenia przerzucając obwody z jednej fazy na drugą . Program na podstawie zmiennej , czyli ilości i rodzaju obwodu oblicza prąd , a następnie dobiera odpowiedni wyłącznik różnicowo-prądowy. W branży elektrycznej bilansowanie obciążenia na fazach jest ważnym zagadnieniem, z którym projektanci instalacji mają do czynienia . Niedostosowanie obciążeń może skutkować przepalaniem przewodów ( w przypadku gdy przekrój dostosowany na mniejsze obciążenie) lub większymi kosztami materiału potrzebnego do wykonania instalacji ( w przypadku dostosowania do większych niż potrzeba wartości) , dlatego przy odpowiednim uszeregowaniu obwodów można w łatwy i ekonomiczny sposób zoptymalizować koszty instalacji i ryzyko wystąpienia niepożądanych efektów takich jak przepalenie przewodów.";
            string caption = "Informacje o programie";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }
    }
}
