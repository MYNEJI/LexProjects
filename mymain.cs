using System;
using System.IO;
using SimpleScanner;
using ScannerHelper;
using System.Collections.Generic;

namespace Main
{
    class mymain
    {
        static void Main(string[] args)
        {
            // Чтобы вещественные числа распознавались и отображались в формате 3.14 (а не 3,14 как в русской Culture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var fname = @"..\..\a.txt";
            Console.WriteLine(File.ReadAllText(fname));
            Console.WriteLine("-------------------------");

            Scanner scanner = new Scanner(new FileStream(fname, FileMode.Open));
            List<int> iddsSum = new List<int>();
            int sum = 0;
            int tok = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            int integerSum = 0;
            double floatSum = 0;
            do
            {
                tok = scanner.yylex();
                if (tok == (int)Tok.EOF)
                    break;
                if (tok == (int)Tok.ID)
                {
                    iddsSum.Add(scanner.yytext.Length);
                    sum += scanner.yytext.Length;
                    if (scanner.yytext.Length < min)
                    {
                        min = scanner.yytext.Length;
                    }
                    if (scanner.yytext.Length > max)
                    {
                        max = scanner.yytext.Length;
                    }
                }

                if(tok== (int)Tok.INUM)
                {
                    int temp;
                    int.TryParse(scanner.yytext,out temp);
                    integerSum += temp;
                }

                if (tok == (int)Tok.RNUM)
                {
                    double temp;
                    double.TryParse(scanner.yytext, out temp);
                    floatSum += temp;
                }
                Console.WriteLine(scanner.TokToString((Tok)tok));
            } while (true);

            Console.WriteLine($"Количество всех идентификаторов = {iddsSum.Count}\n" +
                $"Средняя длина всех идентификаторов = {sum/iddsSum.Count}\n" +
                $"Минимальная длина идентификатора = {min}\n" +
                $"Максимальная длина идентификатора = {max}");
            Console.WriteLine($"Сумма всех целых чисел  = {integerSum}\n" +
                $"Сумма всех вещественных чисел = {floatSum}");

            Console.ReadKey();
        }
    }
}
