using System;

namespace Tema_Lab_8_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in FibonacciArray())
            {
                Console.Write(i.ToString() + " ");
            };

            Console.ReadLine();
        }

        static int[] FibonacciArray ()
        {
            int[] FirstArr, FibArr;
            // i = 2 si j = 2 se initiaza cu 2 din cauza ca primele doua elemente se aloca inainte de iteratii mai jos
            int raspInt, i = 2, j = 2, numarIncercari = 1;

            string raspStr;

            Console.Write("Introduceti dimensiunea colectiei pentru extragerea sirului Fibonnaci: ");

            raspStr = Console.ReadLine();

            // se verifica ca numarul introdus sa fie numar intreg cu adevarat
            raspInt = numarElemenArrFib(raspStr, false, numarIncercari);

            raspInt = (raspInt == 0) ? 1 : raspInt;

            FirstArr = new int[raspInt];

            FirstArr[1] = 1; //al doilea element al colectiei, primul fiind 0 pentru ca toate elemetele sunt initial zero

            do
            {

                if (FirstArr[i - 1] > raspInt)
                {
                    FirstArr[i - 1] = 0;
                    j = j - 1;
                    break;
                }

                FirstArr[i] = FirstArr[i - 1] + FirstArr[i - 2];

                j = j + 1;
               
                i++;

            } while ( i < FirstArr.Length );

            FibArr = new int[j];

            for ( int x = 0; x <= j - 1; x++ )
            {
                FibArr[x] = FirstArr[x];
            }

            Console.Write("Sirul Fibonacci: ");

            return FibArr;
        }

        static int numarElemenArrFib (string raspStr, bool esteRaspCorect, int numarIncercari)
        {
            int rezultat = 0;

            while (!esteRaspCorect && numarIncercari < 3)
            {

                esteRaspCorect = int.TryParse(raspStr, out int numar);

                if ( !esteRaspCorect)
                {
                    Console.WriteLine($"Nu ati introdus un numar corect. Mai aveti { 3 - numarIncercari } incercari");
                    raspStr = Console.ReadLine();
                }

                rezultat = numar;
                numarIncercari++;
                
            }

            return rezultat;
        }
    }
}
