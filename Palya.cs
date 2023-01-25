using System;

namespace nagyhf1
{
    class Palya
    {
        public int[] palya;

        public Palya()
        {
            palya = new int[12];
            for(int i = 0; i<palya.Length;i++)
            {
                palya[i] = 4;
            }
        }

        public void Kiir()
        {
            Console.Clear();
            Console.Write("Gép:\t\t");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(palya[i]);
                Console.Write("\t");
            }
            Console.Write("\n" + "Játékos:\t");
            for (int j = 11; j >= 6; j--)
            {
                Console.Write(palya[j]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }

        public int LepesVegrehajtasJatekos(int n)
        {
            int index = 11 - (n - 1);
            int eredeti = index;
            int magok = palya[index];
            palya[index] = 0;

            if (index != 0)
            {
                index--;
            }

            while (magok != 0 && index != 0)
            {
                palya[index] += 1;
                index--;
                magok--;
            }
            if (magok != 0)
            {
                if (eredeti != 0)
                {
                    palya[0] += 1;
                }
                magok--; // ennek lehet inkabb az ifben kellene lennie

                if (magok != 0)
                {
                    if ((n - 1) == 0)
                    {
                        index = 10;
                    }
                    else
                    {
                        index = 11;
                    }
                    while (magok != 0 && index >= 0)
                    {
                        if(index == eredeti)//ez az ifet utolag irtam be a valasztott hely ellenorzesere
                        {
                            index--;
                        }
                        palya[index] += 1;
                        magok--;
                        index--;
                        if (index == 11 - (n - 1))
                        {
                            index--;
                        }
                    }
                }
            }
            return index;
        }

        public int PontellenorzesJatekos(int n)
        {
            int pontok = 0;
            n++;
            if (n > 5)
            {
                return pontok;
            }
            else
            {

                while (n <= 5)
                {

                    if (palya[n] == 2)
                    {
                        pontok += 2;
                        palya[n] = 0;
                        n++;
                    }
                    else if (palya[n] == 3)
                    {
                        pontok += 3;
                        palya[n] = 0;
                        n++;
                    }
                    else
                    {
                        n = 6;
                    }
                }
            }
            return pontok;
        }

        public int LepesVegrehajtasGep(int n) //pontos utolsohellyel ter vissza
        {
            int index = n;
            int eredeti = index;
            int magok = palya[index];
            palya[index] = 0;
            if (index != 0)
            {
                index--;
            }
            else
            {
                index = 11;
            }


            while (magok != 0 && index != 0)
            {
                if(index == eredeti && eredeti != 0) //eredeti hely ellenorzes
                {
                    index--;
                }
                palya[index] += 1;
                magok--;

                index--;
            }
            if (magok != 0)
            {
                if(eredeti != 0)
                {
                    palya[0] += 1;
                    magok--;
                }
                //palya[0] += 1; ezt irtam bele az ujjonan keszult if-be az eredeti hely ellenorzes miatt
                //magok--;
                
                index = 11;
            }
            while (index != 0 && magok != 0)
            {
                palya[index] += 1;
                magok--;
                index--;
            }
            if (magok != 0)
            {
                palya[0] += 1;
                magok--;
                index = 11;
            }
            while (index != 0 && magok != 0)
            {
                palya[index] += 1;
                magok--;
                index--;
            }
            return index + 1;


        }

        public Palya ProbaLepesVegrehajtasGep(int n) // pontos indexet ker, és visszater egy lelepett palyaval
        {

            
            Palya tomb = new Palya();
            for(int i = 0; i < palya.Length;i++)
            {
                tomb.palya[i] = palya[i];
            }

            int index = n;
            int magok = tomb.palya[index];
            tomb.palya[index] = 0;
            if (index != 0)
            {
                index--;
            }


            while (magok != 0 && index != 0)
            {
                tomb.palya[index] += 1;
                magok--;

                index--;
            }
            if (magok != 0)
            {
                tomb.palya[0] += 1;
                index = 11;
            }
            while (index != 0 && magok != 0)
            {
                tomb.palya[index] += 1;
                magok--;
                index--;
            }
            return tomb;
        }
        
        public int ProbaLepesVegrehajtasIndexGep(int n)//az utolso lepett tomb indexet adja vissza
        {
            
            Palya tomb = new Palya();
            for (int i = 0; i < palya.Length; i++)
            {
                tomb.palya[i] = palya[i];
            }

            int index = n;
            int magok = tomb.palya[index];
            tomb.palya[index] = 0;
            if (index != 0)
            {
                index--;
            }
            else
            {
                index = 11;
            }


            while (magok != 0 && index != 0)
            {
                tomb.palya[index] += 1;
                magok--;

                index--;
            }
            if (magok != 0)
            {
                tomb.palya[0] += 1;
                magok--;
                index = 11;
            }
            while (index != 0 && magok != 0)
            {
                tomb.palya[index] += 1;
                magok--;
                index--;
            }


            return index + 1;
        }

        public int PontEllenorzesGepi(int n)//valoban leellnorzi a pontokat, es a megfelelo helyeken 0-ra allit
        {
            int pontok = 0;

            if (n < 6)
            {
                return pontok;
            }
            else
            {

                while (n <= 11)
                {


                    if (palya[n] == 2)
                    {
                        pontok += 2;
                        palya[n] = 0;
                        n++;
                    }
                    else if (palya[n] == 3)
                    {
                        pontok += 3;
                        palya[n] = 0;
                        n++;
                    }
                    else
                    {
                        n = 12;
                    }
                }
            }
            return pontok;
        }

        public int GepiProba(int n,Palya eredeti)//kap egy palyat ahol mar probaszeruen volt lépés végrehajtva., visszater a ponttal.
        {
            
            Palya probapalya = new Palya();
            for (int i = 0; i < palya.Length; i++)
            {
                probapalya.palya[i] = eredeti.palya[i];
            }

            int pontok = 0;

            if (n < 6)
            {
                return pontok;
            }
            else
            {

                while (n <= 11)
                {

                    if (probapalya.palya[n] == 2)
                    {
                        pontok += 2;
                        probapalya.palya[n] = 0;
                        n++;
                    }
                    else if (probapalya.palya[n] == 3)
                    {
                        pontok += 3;
                        probapalya.palya[n] = 0;
                        n++;
                    }
                    else
                    {
                        n = 12;
                    }
                }
            }
            return pontok;
        }

        public int GepiJatekos()
        {
            /*
             * A gépi játékos megkapja az eredeti pályát, ahol egy ciklusban végig ellenörzi az összes lehetséges
             * a próba pályával, az utolsó lépés helyével, és leellenörzi a kapott pontokat.
             * A kapott pontokat egy maxkereséssel eltárolja a hozzátartozó ház-számmal.
             * Ha nem talált olyan lépést amivel pontot tudna szerezni akkor random választ egy házat, és azzal fog játszani.
             * Ha van olyan ház ahol pontot tud szerezni akkor azzal fog lépni.
             * Ha több olyan ház van ahol tud pontot szerezni akkor a legtöbb pontot érő lépést használja, ha több 
             * ilyen van akkor, az utolsó ilyen házat fogja használni a gép.
             */
            Random rnd = new Random();
            int legjobbpont = 0;
            int legjobbidx = 0;
            for (int i = 0; i < 6; i++)
            {             
                int probautolsohely = ProbaLepesVegrehajtasIndexGep(i);
                Palya probapalya = ProbaLepesVegrehajtasGep(i);

                int temp = GepiProba(probautolsohely, probapalya);
                if (temp > legjobbpont)
                {
                    legjobbpont = temp;
                    legjobbidx = i;
                }
            }
            if (legjobbpont == 0)
            {
                legjobbidx = rnd.Next(0, 6);
                while (palya[legjobbidx] == 0)
                {
                    legjobbidx = rnd.Next(0, 6);
                }
            }
            return legjobbidx;
        }

    }    
}
