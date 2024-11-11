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
            // ����� ������������ ����� �������������� � ������������ � ������� 3.14 (� �� 3,14 ��� � ������� Culture)
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

            Console.WriteLine($"���������� ���� ��������������� = {iddsSum.Count}\n" +
                $"������� ����� ���� ��������������� = {sum/iddsSum.Count}\n" +
                $"����������� ����� �������������� = {min}\n" +
                $"������������ ����� �������������� = {max}");
            Console.WriteLine($"����� ���� ����� �����  = {integerSum}\n" +
                $"����� ���� ������������ ����� = {floatSum}");

            Console.ReadKey();
        }
    }
}
