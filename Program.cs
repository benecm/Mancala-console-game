using System;

namespace nagyhf1
{
    class Program
    {
        static int HazValasztas()
        {
            Console.WriteLine("Melyik házat választod?");
            int temp = int.Parse(Console.ReadLine());
            return temp;
        } // kivalasztja a hazat

        static void Main()
        {
            
            Palya map = new Palya();
            map.Kiir();
            int JatekosPont = 0;
            int GepiPont = 0;
            bool egyenlo = false;
            while (GepiPont != 25 && JatekosPont != 25)
            {
                //A játékos vélasztja ki a házat.
                int haz = HazValasztas();
                if (haz > 6)
                {
                    while (haz > 6)
                    {
                        Console.WriteLine("Kérlek a saját házadat válaszd! (1-től 6-ig)");
                        haz = HazValasztas();
                    }
                    
                }
                
                //játékos lépésének a végrehajtása, majd a pontok leellenőrzése.
                int utolsohely = map.LepesVegrehajtasJatekos(haz);
                JatekosPont += map.PontellenorzesJatekos(utolsohely);
                
                // a gépi játékosnak átadom a pályát, amivel kiválasztja a megfelelő lépést.
                int gepivalasztott = map.GepiJatekos();

                // a lépést végrehajta a program, és eltárolja az utolsó házat, ahova került mag.
                int gepiutolsohely = map.LepesVegrehajtasGep(gepivalasztott);

                //az utolsó lépett ház helyétől visszaszámolja a program a pontokat.
                GepiPont += map.PontEllenorzesGepi(gepiutolsohely);
                map.Kiir();
                Console.WriteLine("A gép által választott ház: " + (gepivalasztott+1));

                Console.WriteLine("Az eredmény:");
                Console.WriteLine("Játékos: " + JatekosPont);
                Console.WriteLine("Gép: " + GepiPont);
                
                //itt ellenőrzi a program ha egyenlő, azaz döntetlen eredményre jutott a játék.
                if(GepiPont == 24 && JatekosPont == 24)
                {
                    egyenlo = true;
                    GepiPont = 25;
                }
            }
            Console.Clear();

            if(egyenlo)
            {
                Console.WriteLine("A játék véget ért! Az eredmény: Döntetlen.");
            }
            else if(GepiPont == 25)
            {
                Console.WriteLine("A játék végetért! A gépijátékos nyert!");
            }
            else
            {
                Console.WriteLine("Gratulálok, megnyerted a játékot!");
            }
            Console.ReadKey();           
        }
    }
}


