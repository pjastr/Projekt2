using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Biblioteka_kolos
{
    public abstract class Pozycja //brakuje oznaczenia abstrakcyjności
    {
        protected string tytul;
        protected int id;
        protected string wydawnictwo;
        protected int rokWydania;
        public Pozycja(string tytul,int id,string wydawnictwo,int rokWydania)
        {
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
        }
        public Pozycja()
        {

        }
        public abstract void WypiszInfo(); //ta metoda ma być abstrakcyjna

        public string PobierzTytul()
        {
            return this.tytul;
        }
        public int PobierzId()
        {
            return this.id;
        }

    }
    public class Czasopismo:Pozycja
    {
        private int numer;
        public Czasopismo()
        {

        }
        public Czasopismo(string tytul,int id,string wydawnictwo, int rokWydania,int numer):base(tytul,id,wydawnictwo,rokWydania)
        {
            this.numer = numer;
            //nie ma najmniejszego sensu dwa razy inicjować te same pola
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("TYTUL:" + this.tytul + "ID:" + this.id + "WYDAWNICTWO:" + this.wydawnictwo + "ROK WYDANIA:" + this.rokWydania + "NUMER:" + this.numer);
        }
    }
    public class Ksiazka:Pozycja
    {
        private int liczbaStron;
        private Autor autor;
        public Ksiazka()
        {

        }
        public Ksiazka(string tytul, int id, string wydawnictwo, int rokWydania,int liczbaStron, string imie, string nazwisko) :base(tytul,id,wydawnictwo,rokWydania)
        {
            autor = new Autor(imie, nazwisko);
            this.liczbaStron = liczbaStron;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine(this.tytul);
            Console.WriteLine(this.id);
            Console.WriteLine(this.wydawnictwo);
            Console.WriteLine(this.rokWydania);
            Console.WriteLine(this.autor);
        }


    }
    public class Autor
    {
        protected string imie;
        protected string nazwisko;
        public Autor()
        {

        }
        public Autor(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public override string ToString()
        {
            return this.imie + " " + this.nazwisko;
        }
    }
    public class Katalog:IZarzadzanie //lit
    {
        private string dzialTematyczny;
        private List<Pozycja> pozycje=new List<Pozycja>();
        public Katalog(string dzialTematyczny)
        {
            this.dzialTematyczny = dzialTematyczny;
        }
        public void DodajPozycje(string tytul,int id,string wydawnictwo,int rokWydania,int numer)
        {
           pozycje.Add(new Czasopismo(tytul, id, wydawnictwo, rokWydania,numer));
           
        }
        public void DodajPozycje(string tytul,int id,string wydawnictwo,int rokWydania,int liczbaStron,string imie,string nazwisko)
        {
            pozycje.Add(new Ksiazka(tytul,id,wydawnictwo,rokWydania,liczbaStron,imie,nazwisko));
        }

        public void WypiszWszystko()
        {
            foreach(Pozycja element in pozycje)
            {
                element.WypiszInfo();
            }
        }

        public void WyszukajPoId(int id)
        {
            pozycje.Find(x =>x.PobierzId()==id).WypiszInfo(); // błędna składnia
        }
        public void WyszukajPoTytule(string tytul)
        {
            pozycje.Find(x => x.PobierzTytul() == tytul).WypiszInfo(); // błędna składnia
        }

        public void Test()  //brakująca metoda Test
        {
            DodajPozycje("Gazeta Olsztyńska", 200, "Edytor", 1992, 7);
            DodajPozycje("Gazeta Wyborcza", 123, "Agora", 2010, 23);
            DodajPozycje("Krzyżacy", 220, "Znak", 2010, 300, "Henryk", "Sienkiewicz");
            DodajPozycje("Krzyżacy", 221, "Znak", 2011, 298, "Henryk", "Sienkiewicz"); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int wybor,numer,rokWydania,id,liczbaStron;
            string tytul, wydawnictwo,imie,nazwisko;
            Katalog nowy = new Katalog("lallala");
            nowy.Test();  //wywołanie metody test
            do
            {
                Console.WriteLine("Co chcesz zrobić ? Wpisz odpowiedni numer:");
                Console.WriteLine("1.DODAJ CZASOPISMO");
                Console.WriteLine("2.DODAJ KSIAZKE");
                Console.WriteLine("3.WYSZUKAJ PO TYTULE");
                Console.WriteLine("4.WYSZUKAJ PO ID");
                Console.WriteLine("5.POKAZ ZAWARTOSC");
                Console.WriteLine("6.WYJDZ");
                wybor = int.Parse(Console.ReadLine()); 
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Tytuł:");
                        tytul = Console.ReadLine();
                        Console.WriteLine("ID:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wydawnictwo:");
                        wydawnictwo = Console.ReadLine();
                        Console.WriteLine("rok wydania");
                        rokWydania = int.Parse(Console.ReadLine());
                        Console.WriteLine("numer");
                        numer = int.Parse(Console.ReadLine());
                        nowy.DodajPozycje(tytul, id, wydawnictwo, rokWydania, numer);
                        break;
                    case 2:
                        Console.WriteLine("Tytuł:");
                        tytul = Console.ReadLine();
                        Console.WriteLine("ID:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wydawnictwo:");
                        wydawnictwo = Console.ReadLine();
                        Console.WriteLine("rok wydania");
                        rokWydania = int.Parse(Console.ReadLine());
                        Console.WriteLine("Liczba stron:");
                        liczbaStron = int.Parse(Console.ReadLine());
                        Console.WriteLine("Imie");
                        imie = Console.ReadLine();
                        Console.WriteLine("Nazwisko");
                        nazwisko = Console.ReadLine();
                        nowy.DodajPozycje(tytul, id, wydawnictwo, rokWydania, liczbaStron, imie, nazwisko);
                        break;
                    case 3:
                        Console.WriteLine("Podaj tytul:");
                        tytul = Console.ReadLine();
                        nowy.WyszukajPoTytule(tytul);
                        break;
                    case 4:
                        Console.WriteLine("Podaj Id");
                        id = int.Parse(Console.ReadLine());
                        nowy.WyszukajPoId(id);
                        break;
                    case 5:
                        nowy.WypiszWszystko();
                        break;
                    case 6:
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("PODALES ZLA LICZBE !!!!!");
                        break;
                }

            } while (wybor != 6);
            Console.WriteLine("DO ZOBACZENIA !!!!");
        
            Console.ReadKey();
        }
    }
}
