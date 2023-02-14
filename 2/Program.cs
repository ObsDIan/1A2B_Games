using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {
        static int chtoin(char n)
        {
            return (Convert.ToInt32(n)) - 48;
        }
         static void Main(string[] args)
        {
            int again = 0;

            Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");

            while (again == 0)
            {
                int[] math = { -1, -1, -1, -1 };
                char[] ans_ar = new char[4];

                int a = 0, b = 0;
                Random rnd = new Random();
                int check = 0;

                for (int i = 0; i < 4; i++)
                {
                    int temp = rnd.Next(0, 9);
                    while (temp == math[0] || temp == math[1] || temp == math[2] || temp == math[3])
                    {
                        temp= rnd.Next(0, 9);
                    }
                    //for (int j = 0; j < i; j++)
                    //{
                    //    if (temp == math[j])
                    //    {
                    //        temp = rnd.Next(0, 9);
                    //        j = 0;
                    //    }
                    //}
                    math[i] = temp;
                    Console.Write(math[i]);
                }

                while (check == 0)
                {
                    a = 0;
                    b = 0;
                er: Console.Write("------\r\n請輸入 4 個數字：");
                    string ans = Convert.ToString(Console.ReadLine());
                    ans_ar = ans.ToCharArray();

                    if (ans_ar.Length > 4 || ans_ar.Length < 4)
                    {
                        Console.WriteLine("輸入的答案數量錯誤");
                        goto er;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (chtoin(ans_ar[i]) > 9 || chtoin(ans_ar[i]) < 0)
                        {
                            Console.WriteLine("輸入格式錯誤");
                            goto er;
                        }
                        else if ( chtoin(ans_ar[i]) == math[i])
                        {
                            a++;
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (chtoin(ans_ar[j]) == chtoin(ans_ar[i]) && j != i)
                                {
                                    Console.WriteLine("請勿輸入重複數字");
                                    goto er;
                                }
                                if (chtoin(ans_ar[j]) == math[i])
                                {
                                    b++;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"判定結果是 {a}A{b}B");
                    if (a == 4)
                    {
                        Console.WriteLine("恭喜你！猜對了！！");
                        Console.WriteLine("------\r\n你要繼續玩嗎？(y/n):");
                        char yn = Convert.ToChar(Console.ReadLine());
                        if ((yn == 'N') || (yn == 'n'))
                        {
                            Console.WriteLine("遊戲結束，下次再來玩喔～");
                            again = 1;
                        }
                        check = 1;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
