using System;
using System.Collections.Generic;
using System.IO;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj tekst, ktory chcesz zaszyfrowac: ");
            string input = Console.ReadLine();
            char[] inputArr = new char[input.Length];
            Console.WriteLine("Podaj skok z jakim ma być wykonane szyfrowanie: ");
            int shift = Convert.ToInt32(Console.ReadLine());

            for(int i =0; i<input.Length; i++)
            {
                inputArr[i] = input[i];
            }

            List<char> encryptedInput = new List<char>();

            if (shift > 26)
            {
                Console.WriteLine("Podany skok jest za duży!");  
            }
            else
            {
                foreach (int j in inputArr)
                {
                    int c = j;
                    if (j >= 65 && j <= 90 - shift)
                    {
                        c += shift;
                    }
                    else if (j >= 91 - shift && j <= 90)
                    {
                        c = c - 26 + shift;
                    }
                    else if (j >= 97 && j < 122 - shift)
                    {
                        c += shift;
                    }
                    else if (j >= 123 - shift && j <= 122)
                    {
                        c = c - 26 + shift;
                    }
                    encryptedInput.Add((char)c);
                }
            }
            string output = string.Join("",encryptedInput.ToArray());
            File.WriteAllText("encrypted.txt", output);
        }
    }
}
