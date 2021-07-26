// Le carte di pagamento sono lunghe 16 cifre.
// Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
// Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
// Le cifre da 9 a 15 sono il numero di serie della carta
// L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

// Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido

// Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari
// Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
// Step 3 : Vengono sommante tutte le cifre ottenute
// Step 4 : Vengono aggiunte le cifre nelle posizioni dispari
// Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.

// Esempi
// Carta di pagamento : 4 5 5 6 7 3 7 5 8 6 8 9 9 8 5 5
// Step 1 : 8 5 10 6 14 3 14 5 16 6 16 9 18 8 10 5
// Step 2 : 8 5 1 6 5 3 5 5 7 6 7 9 9 8 1 5
// Step 3 : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
// Step 4 : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
// Step 5 : 90/10 = 9 resto 0 -> Numero della carta valido

// Esempi
// Carta di pagamento : 4 0 2 4 0 0 7 1 0 9 0 2 2 1 4 3
// Step 1 : 8 0 4 4 0 0 14 1 0 9 0 2 4 1 8 3
// Step 2 : 8 0 4 4 0 0 5 1 0 9 0 2 4 1 8 3
// Step 3 : 8 + 4 + 0 + 5 + 0 + 0 + 4 + 8 = 29
// Step 4 : 29 + (0+4+0+1+9+2+1+3) = 29 + 20 = 49
// Step 5 : 49/10 = 4 resto 9 -> Numero della carta non valido


using System;

namespace Esercizio13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeroDiCarta = new int[16];
            int somma = 0;

            InserisciNumero(ref numeroDiCarta);

            Console.WriteLine("Il tuo numero di carta è: \n");

            StampaNumero(ref numeroDiCarta);

            RaddoppiaCifre(ref numeroDiCarta);

            StampaNumero(ref numeroDiCarta);

            SommaCifreDispari(ref numeroDiCarta, ref somma);

            SommaCifrePari(ref numeroDiCarta, ref somma);

            VerificaValidita(ref somma);
        }

        private static void VerificaValidita(ref int somma)
        {
            if (somma % 10 == 0)
            {
                Console.WriteLine("\nNumero di carta valido.");
            }
            else
            {
                Console.WriteLine("\nNumero di carta non valido.");
            }
        }

        private static void SommaCifrePari(ref int[] numeroDiCarta, ref int somma)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    somma += numeroDiCarta[i + 1];

                }
            }

            Console.WriteLine($"\nLa somma di tutte le cifre è: {somma}");
        }



        private static void SommaCifreDispari(ref int[] numeroDiCarta, ref int somma)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 1)
                {
                    somma += numeroDiCarta[i - 1];

                }
            }

            Console.WriteLine($"\nLa somma delle cifre dispari è: {somma}");
        }

        private static void RaddoppiaCifre(ref int[] numeroDiCarta)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 1)
                {
                    numeroDiCarta[i - 1] = numeroDiCarta[i - 1] * 2;

                    if (numeroDiCarta[i - 1] > 9)
                    {
                        numeroDiCarta[i - 1] = ((numeroDiCarta[i - 1]) - 9);
                    }
                }
            }
        }

        private static void StampaNumero(ref int[] numeroDiCarta)
        {
            for (int i = 0; i < 16; i++)
            {
                Console.Write($"{numeroDiCarta[i]}\t");
            }
        }

        private static void InserisciNumero(ref int[] numeroDiCarta)
        {
            int cifra;

            Console.WriteLine("Inserire numero di carta:");
            for (int i = 0; i < 16; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out cifra) || cifra < 0 || cifra > 10)
                {

                    Console.WriteLine("Puoi inserire solo interi maggiori di 0 e minori di 10:");

                }
                numeroDiCarta[i] = cifra;
            }
        }
    }
}
