using static System.Console;

namespace HissiSimulaatio
{
    class Hissi : IHissi
    {
        //STAATTISET ELEMENTIT
        private static int SIIRTYMAODOTUS = 250;

        //TILA: KENTTÄMUUTTUJAT
        private int _minimi = -2;
        private int _maksimi = 10;
        private int _sijainti = 1;
        private int _kerrokseen;

        public Hissi(int maksimi, int kerrokseen)
        {
            _maksimi = maksimi;
            _kerrokseen = kerrokseen;

            if (_maksimi <= 1)
            {
                _maksimi = 1;
            }
        }

        public void NaytaKerrokset(int kerrokseen)
        {
            _sijainti = kerrokseen;

            Write("Kerrokset:");

            for (int kerros = _minimi; kerros < _maksimi; kerros++)
            {
                if (kerros != _sijainti)
                {
                    Write($" {kerros} ");
                }
                if (kerros == _sijainti)
                {
                    System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                    Write($" [{kerros}] ");
                    System.Console.ResetColor();
                }
            } 

            if (_maksimi != _sijainti)
            {
                WriteLine($" {_maksimi} ");
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                WriteLine($" [{_maksimi}] ");
                System.Console.ResetColor();
            }
        }

        public void Siirry(int kerrokseen)
        {
            _kerrokseen = kerrokseen;

            if (_sijainti <= _kerrokseen)
            {
                SiirryYlos(_kerrokseen);
            }
            else
            {
                SiirryAlas(_kerrokseen);
            }
        }

        private void SiirryYlos(int kerrokseen)
        {
            if (_kerrokseen > _maksimi)
            {
                _kerrokseen = _maksimi;
            }

            if (_sijainti <= _kerrokseen)
            {
                for (int siirry = _sijainti; siirry <= _kerrokseen; siirry++)
                {
                    NaytaKerrokset(_sijainti);
                    _sijainti++;
                    System.Threading.Thread.Sleep(SIIRTYMAODOTUS);
                }
            }

            if (_sijainti > _kerrokseen)
            {
                _sijainti--;
            }
        }

        private void SiirryAlas(int kerrokseen)
        {
            if (_kerrokseen < _minimi)
            {
                _kerrokseen = _minimi;
            }

            if (_sijainti >= _kerrokseen)
            {
                for (int siirry = _sijainti; siirry >= _kerrokseen; siirry--)
                {
                    NaytaKerrokset(_sijainti);
                    _sijainti--;
                    System.Threading.Thread.Sleep(SIIRTYMAODOTUS);
                }
            }

            if (_sijainti < _kerrokseen)
            {
                _sijainti++;
            }
        }
    }
}