using System;
using System.Text.RegularExpressions;
using System.IO;

namespace passwordTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\gitRepos\CaesarCipherCS\password.txt";
            string password = File.ReadAllText(path);
            
            
            int score = 0;

            if (password.Length>=8)
                score++;
            
            if (password.Length >= 12)
                score++;

            if (Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))
                score++; 

            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript))
                score++;

            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript))
                score++;

            if(score == 0)
                Console.WriteLine("Nie podałeś hasła.");
            else if(score == 1)
                Console.WriteLine("Hasło jest bardzo słabe!");
            else if (score == 2)
                Console.WriteLine("Hasło jest słabe.");
            else if(score==3)
                Console.WriteLine("Hasło wymaga poprawy!");
            else if(score == 4)
                Console.WriteLine("Hasło jest silne.");
            else if(score==5)
                Console.WriteLine("Hasło jest bardzo silne.");
        }
    }
}
