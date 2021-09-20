using System;
using System.Collections.Generic;
using System.Linq;

namespace NumBaseballGameAI
{
    class Program
    {
        static List<int> mainlist = new List<int>();
        static readonly bool enable_posiblityshow = true;

        static void Main(string[] args)
        {
            MakeList();
            List<int> list = mainlist;
            int count = 0;

            while (true)
            {
                count++;
                Random r = new Random();
                int randnum = list[r.Next(0, list.ToArray().Length)];
                Console.WriteLine(count+"회차 =======================================================");
                Console.WriteLine("답은... " + randnum+"!");
                Console.WriteLine("볼은 B[숫자], 스트라이크는 S[숫자], 아웃은 O를 입력해 주세요.");
                Console.WriteLine("ex) B2 S1 / B0 S2 / O / B1 S1");
                string s = Console.ReadLine();
                if (s == "O")
                {
                    for (int i = 0; i < list.ToArray().Length; i++)
                    {
                        if (list[i].ToString() == randnum.ToString() || list[i].ToString().Contains(randnum.ToString()[0]) || list[i].ToString().Contains(randnum.ToString()[1]) || list[i].ToString().Contains(randnum.ToString()[2]))
                        {
                            list.RemoveAt(i);
                        }
                    }
                    if (enable_posiblityshow)
                        Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                }
                else if (s.Contains("B") && s.Contains("S"))
                {
                    int ball = int.Parse(s.Split(' ')[0].ToString()[1]+ "");
                    int strike = int.Parse(s.Split(' ')[1].ToString()[1]+ "");
                    //Console.WriteLine(ball + " " + strike);

                    // strike 제외
                    if (strike == 3)
                    {
                        // 3 스트라이크 = 다맞음.
                        Console.WriteLine("와! 제가 맞았어요!");
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        break;
                    }
                    else if (strike == 2)
                    {
                        // 2 스트라이크. 아래 경우중 하나임.
                        // OOX
                        // OXO
                        // XOO
                        List<int> vs = new List<int>();

                        for (int i = 0; i < list.ToArray().Length; i++)
                        {
                            string str = list[i].ToString();
                            if ((str[0] == randnum.ToString()[0] && str[1] == randnum.ToString()[1]) || (str[0] == randnum.ToString()[0] && str[2] == randnum.ToString()[2])  || (str[1] == randnum.ToString()[1] && str[2] == randnum.ToString()[2]))
                            {
                                if (str != randnum.ToString())
                                    vs.Add(list[i]);
                            }
                        }
                        list = vs;
                        if (enable_posiblityshow)
                            Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                        //Console.WriteLine(list);
                    }
                    else if (strike == 1)
                    {
                        // 1 스트라이크. 아래 경우중 하나.
                        // OXX
                        // XOX
                        // XXO
                        List<int> vs = new List<int>();

                        for (int i = 0; i < list.ToArray().Length; i++)
                        {
                            string str = list[i].ToString();
                            if ((str[0] == randnum.ToString()[0]) || (str[1] == randnum.ToString()[1]) || (str[2] == randnum.ToString()[2]))
                            {
                                if (str != randnum.ToString())
                                    vs.Add(list[i]);
                            }
                        }
                        list = vs;
                        if (enable_posiblityshow)
                            if (enable_posiblityshow)
                                Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                    }

                    // ball 제외
                    if (ball == 3)
                    {
                        // 3볼 -> 숫자 3개다 포함하는것만 남기면 됨
                        List<int> vs = new List<int>();

                        for (int i = 0; i < list.ToArray().Length; i++)
                        {
                            string str = list[i].ToString();
                            if ((WordCheck(str,randnum.ToString()[0].ToString()) + WordCheck(str, randnum.ToString()[1].ToString()) + WordCheck(str, randnum.ToString()[2].ToString())) == 3)
                            {
                                if (str != randnum.ToString())
                                    vs.Add(list[i]);
                            }
                        }
                        list = vs;
                        if (enable_posiblityshow)
                            if (enable_posiblityshow)
                                Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                        //Console.WriteLine(list);
                    }
                    else if (ball == 2)
                    {
                        // 2볼 -> 숫자 2개 포함하는것만 남기면 됨
                        // OOX
                        // XOO
                        // OXO
                        List<int> vs = new List<int>();

                        for (int i = 0; i < list.ToArray().Length; i++)
                        {
                            string str = list[i].ToString();
                            if (((WordCheck(str, randnum.ToString()[0]+"") + WordCheck(str, randnum.ToString()[1].ToString())) == 2) || ((WordCheck(str, randnum.ToString()[0] + "") + WordCheck(str, randnum.ToString()[2].ToString())) == 2) || ((WordCheck(str, randnum.ToString()[1] + "") + WordCheck(str, randnum.ToString()[2].ToString())) == 2))
                            {
                                if (str != randnum.ToString())
                                    vs.Add(list[i]);
                            }
                        }
                        list = vs;
                        if (enable_posiblityshow)
                            Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                        //Console.WriteLine(list);
                    }
                    else if (ball == 1)
                    {
                        // 1볼 -> 숫자 1개 포함하는것만 남기면 됨
                        // OXX
                        // XOX
                        // XXO
                        List<int> vs = new List<int>();

                        for (int i = 0; i < list.ToArray().Length; i++)
                        {
                            string str = list[i].ToString();
                            if ((WordCheck(str, randnum.ToString()[0] + "") == 1) || (WordCheck(str, randnum.ToString()[1] + "") == 1) || (WordCheck(str, randnum.ToString()[2] + "") == 1))
                            {
                                if (str != randnum.ToString())
                                    vs.Add(list[i]);
                            }
                        }
                        list = vs;
                        if (enable_posiblityshow)
                            Console.WriteLine("남은 경우의 수 : " + list.ToArray().Length);
                        //Console.WriteLine(list);
                    }
                }
            }

            
        }

        static private int WordCheck(string String, string Word)
        {
            string[] StringArray = String.Split(new string[] { Word }, StringSplitOptions.None);

            return StringArray.Length - 1;
        }

        static private void MakeList()
        {
            for (int i = 1; i <= 999; i++)
            {
                char[] array = i.ToString().ToCharArray();
                array = DupCheck(array);
                if (array.Length == 3)
                {
                    mainlist.Add(i);
                    //Console.WriteLine(i);
                }
            }
            Console.WriteLine(mainlist.ToArray().Length);
        }

        private static T[] DupCheck<T>(T[] dupArray)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < dupArray.Length; i++)
            {
                if (result.Contains(dupArray[i])) continue;
                result.Add(dupArray[i]);
            }
            return result.ToArray();
        }
    }
}
