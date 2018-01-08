using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka_kolos
{
    public class Pozycja
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
        public virtual void WypiszInfo()
        {
            Console.WriteLine("TYTUL:"+ this.tytul + "ID:"+ this.id + "WYDAWNICTWO:" + this.wydawnictwo + "ROK WYDANIA:" + this.rokWydania);
        }
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
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
            this.numer = numer;
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
    }
    public class Katalog:Izarzadzanie
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
            foreach(var element in pozycje)
            {
                Console.WriteLine(element.ToString());
            }
        }

        public void WyszukajPoId(int id)
        {
            Console.WriteLine(pozycje.Find(x =>x.PobierzId()==id));
        }

        public void WyszukajPoTytule(string tytul)
        {
            Console.WriteLine(pozycje.Find(x => x.PobierzTytul() == tytul));
        }
        public void Tes()
        {
            DodajPozycje("Gazeta Olsztyńska", 200, "Edytor", 1992, 7);
            DodajPozycje("Gazeta Wyborcza", 123, "Agora", 2010, 23);
            DodajPozycje( "Krzyżacy", 220, "Znak", 2010, 300, "Henryk", "Sienkiewicz");
            DodajPozycje( "Krzyżacy", 221, "Znak", 2011, 298, "Henryk", "Sienkiewicz"); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int wybor;
            Console.WriteLine("Co chcesz zrobić ? Wpisz odpowiedni numer:");
            Console.WriteLine("1.DODAJ CZASOPISMO");
            Console.WriteLine("2.DODAJ KSIAZKE");
            Console.WriteLine("3.WYSZUKAJ PO TYTULE");
            Console.WriteLine("4.WYSZUKAJ PO ID");
            Console.WriteLine("5.POKAZ ZAWARTOSC");
            Console.WriteLine("6.WYJDZ");
            Katalog nowy = new Katalog("lallala");
            nowy.Tes();
            nowy.WypiszWszystko();
            Console.ReadKey();
        }
    }
}
