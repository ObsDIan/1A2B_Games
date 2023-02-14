using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _try
{
    internal class Program
    {
    static void Main(string[] args)
    {
        while (true)
        {
            int A = 0;
            int B = 0;
            Console.WriteLine("歡迎來到1A2B的遊戲！");

            //讓電腦選出4個不同的數字
            Random random = new Random();

            int[] roll = new int[4];
            roll[0] = random.Next(0, 10);
            while (true)
            {
                for (int i = 1; i < 4; i++)
                {
                    roll[i] = random.Next(0, 10);
                    if (roll[i] == roll[i - 1])
                    {
                        roll[i] = random.Next(0, 10);
                    }
                }
                if (roll[0] != roll[1] && roll[0] != roll[2] && roll[0] != roll[3]
                    && roll[1] != roll[2] && roll[1] != roll[3] && roll[2] != roll[3])
                {
                    break;
                }
            }

            foreach (int i in roll)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            //讓玩家開始猜



            while (true)
            {
                int[] input_array = new int[4];

                //重複讓玩家猜至4A
                Console.WriteLine("請輸入4個數字 : ");

                for (int i = 0; i < 4; i++)
                {
                    int a = Console.Read();
                    input_array[i] = a;
                }
                Console.ReadLine();
                A = 0;
                B = 0;
                //判斷幾A幾B
                for (int i = 0; i < 4; i++)
                {
                    if (input_array[i] == roll[i])
                    {
                        A++;
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (input_array[i] == roll[j])
                            {
                                B++;
                            }
                        }
                    }
                }
                Console.WriteLine($"你的答案是 {A}A{B}B");
                Console.WriteLine("-------");
                if (A == 4)
                {
                    break;
                }
            }
            Console.WriteLine("恭喜！你猜對了");
            Console.WriteLine("要繼續遊玩嗎(y/n) :");
            char answer = Convert.ToChar(Console.Read());
            if (answer != 'y')
            {
                break;
            }
        }
    }
}
}
