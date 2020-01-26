// HissiSimulaatio
// 2020 (C) Teemu Pienimäki

using static System.Console;

namespace HissiSimulaatio
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxkerros = PyydaKokonaisluku("Anna hissin suurin kerrosnumero:");

            Hissi h;
            h = new Hissi(maxkerros, 1);

            h.NaytaKerrokset(1);

            do
            {
                int syote = (PyydaKokonaisluku("Anna kerros (-3 = lopetus):"));

                h.Siirry(syote);

                if (syote == -3)
                {
                    Write("Paina Enter lopettaaksesi...");
                    ReadLine();
                    break;
                }
            } while (true);
            
        }

        static int PyydaKokonaisluku(string kehote)
        {
            int paluu;
            string syote;

            Write($"{kehote} ");

            do
            {
                try
                {
                    syote = ReadLine();

                    // MacOS Pääte-ohjelmalla negatiiviset luvut ei
                    // toimi oikein, joten ne pitää tarkistaa stringinä.

                    if (syote == "-1")
                    {
                        paluu = -1;
                        break;
                    }
                    if (syote == "-2")
                    {
                        paluu = -2;
                        break;
                    }
                    if (syote == "-3")
                    {
                        paluu = -3;
                        break;
                    }
                    paluu = System.Convert.ToInt32(syote);
                    break;
                }
                catch
                {
                    Write("Syöte ei ole kokonaisluku. Anna kerros (-3 = lopetus): ");
                }
            } while (true);

            return paluu;
        }
    }
}