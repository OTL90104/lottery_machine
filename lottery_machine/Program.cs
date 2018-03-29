using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            while (start == 1)
            {
                Console.WriteLine("歡迎來到樂透兌獎機!!!");
                Console.WriteLine("請輸入六個數字並以,隔開(1~49)：");
                string input = Console.ReadLine();
                bool inputOK = false;
                int[] tempNum;
                int[] user = { -1, -1, -1, -1, -1, -1 };

                //切割成數字同時檢查有無輸入錯誤，若無誤即存入使用者的陣列中
                while (inputOK == false)
                {
                    tempNum = SplitNum(input);
                    for (int i = 0; i < tempNum.Length; i++)
                    {
                        if (tempNum[i] == -1 || Array.IndexOf(tempNum, tempNum[i]) != Array.LastIndexOf(tempNum, tempNum[i]))
                        {
                            Console.WriteLine("母湯喔!輸入錯誤!請輸入六個數字並以,隔開：");
                            input = Console.ReadLine();
                            inputOK = false;
                            break;
                        }
                        else
                        {
                            user[i] = tempNum[i];
                            inputOK = true;
                        }
                    }
                }

                //電腦產生六個不重複的數字
                int[] com = GiveLottery();

                //輸出結果
                Console.WriteLine("======公布結果======");
                Console.WriteLine("你輸入的數字：");
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        Console.Write(user[i]);
                    }
                    else
                    {
                        Console.Write(user[i] + ",");
                    }
                }
                Console.WriteLine("\n=====================");
                Console.WriteLine("電腦輸入的數字：");
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        Console.Write(com[i]);
                    }
                    else
                    {
                        Console.Write(com[i] + ",");
                    }
                }

                //比對結果
                int counter = 0;
                Console.WriteLine("\n=====================");
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (user[i] == com[j])
                        {
                            counter++;
                        }
                    }
                }
                Console.WriteLine($"共猜對{counter}個數字!!");

                if (counter > 0)
                {
                    counter = 0;
                    Console.WriteLine("你猜中的數字有：");
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (user[i] == com[j])
                            {
                                counter++;
                                Console.Write(user[i] + " ");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("槓龜啦~~~~~~~~~哈哈哈");
                }
                string conti = "0";
                while (conti == "0")
                {
                    Console.WriteLine("\n=====================");
                    Console.WriteLine("要重新玩嗎?? (1 : YES/2 : NO)");
                    conti = Console.ReadLine();

                    if (conti == "1")
                    {
                        Console.Clear();
                        start = 1;
                    }
                    else if (conti == "2")
                    {
                        start = 2;
                    }
                    else
                    {
                        Console.WriteLine("\n母湯喔!! (1 : YES/2 : NO)");
                        conti = "0";
                    }
                }
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
        //main的外面

        /// <summary>
        /// 一個字串輸入後，先以逗點切成小字串，再去除空白並判斷是否可轉成數字，最後裝入一個數字陣列中輸出。
        /// </summary>
        /// <param name="input">一個字串</param>
        /// <returns>一個數字的陣列</returns>
        public static int[] SplitNum(string input)
        {
            string[] arrayString = input.Split(',');
            int[] arrayError = { -1, -1, -1 };
            if (arrayString.Length == 6)
            {
                int[] arrayNum = { -1, -1, -1, -1, -1, -1 };
                for (int i = 0; i < 6; i++)
                {
                    arrayNum[i] = CheckNum(arrayString[i].Trim());
                }
                return arrayNum;
            }
            return arrayError;
        }
        /// <summary>
        /// 判斷字串能不能被轉成int，正確的話回傳int數字，錯的話回傳-1
        /// </summary>
        /// <param name="splitedString">輸入裁減過的字串</param>
        /// <returns>回傳int</returns>
        public static int CheckNum(string splitedString)
        {
            int numOK;
            if (int.TryParse(splitedString, out numOK) && numOK > 0 && numOK < 50)
            {
                return numOK;
            }
            return -1;
        }
        /// <summary>
        /// 電腦產生六個不重複的數字
        /// </summary>
        /// <returns>int陣列</returns>
        public static int[] GiveLottery()
        {
            Random rnd = new Random();
            int[] com = new int[6];
            for (int i = 0; i < 6; i++)
            {
                com[i] = rnd.Next(1, 50);
                while (Array.IndexOf(com, com[i]) != Array.LastIndexOf(com, com[i]))
                {
                    com[i] = rnd.Next(1, 50);
                }
            }
            return com;
        }












    }
}
