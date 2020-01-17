using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic
{
    class Program
    {

        public static bool CheckResult(string[,] arr)
        {
            bool status = false;
            for (int i = 0,l=0; i <= 2; i++)
            {
                for (int j = 0,k=0; j <= 2; j++)
                {
                    if (arr[j, k].Equals("X") && arr[j, k+1].Equals("X") && arr[j, k+2].Equals("X"))
                    {
                        status = true;
                        return status;
                    }
                    else if (arr[j, k].Equals("O") && arr[j, k + 1].Equals("O") && arr[j, k + 2].Equals("O")) {
                        status = true;
                        return status;

                    }
                    if (arr[k,l].Equals("X") && arr[k + 1,l + 1].Equals("X") && arr[k + 2,l + 2].Equals("X"))
                    {
                        status = true;
                        return status;

                    }
                    else if (arr[k, l].Equals("O") && arr[k + 1, l + 1].Equals("O") && arr[k + 2, l + 2].Equals("O"))
                    {
                        status = true;
                        return status;
                    }

                    if (arr[k,l+2].Equals("X") && arr[k + 1, l + 1].Equals("X") && arr[k + 2, l].Equals("X"))
                    {
                        status = true;
                        return status;
                    }
                    else if(arr[k, l + 2].Equals("O") && arr[k + 1, l + 1].Equals("O") && arr[k + 2, l].Equals("O"))
                    {
                        status = true;
                        return status;
                    }
                  
                }
                if (arr[l, i].Equals("X") && arr[l + 1,i].Equals("X") && arr[l+2,i].Equals("X"))
                {
                    status = true;
                    return status;
                }
                else if (arr[l,i].Equals("O") && arr[l+1, i].Equals("O") && arr[l+2, i].Equals("O"))
                {
                    status = true;
                    return status;
                }
            }
            return status;
        }

        public static string[,] action(string[,] values, string num1, int k)
        {
            if (k % 2 != 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (values[i, j].Equals(num1))
                        {
                            values[i, j] = "X";
                        }
                    }
                }
            }
            else
            {
                for (int l = 0; l <= 2; l++)
                {
                    for (int m = 0; m <= 2; m++)
                    {
                        if (values[l, m].Equals(num1))
                        {
                            values[l, m] = "O";
                        }
                    }
                }
            }
            return values;
        }

      
        public static void Display(string[,] arr)
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0,0], arr[0,1], arr[0,2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1,0], arr[1,1], arr[1,2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[2,0], arr[2,1], arr[2,2]);

            Console.WriteLine("     |     |      ");

        }

        public static bool performAction(string[,] value,int i,List<string> addvalue)
        {
            string input1 = Console.ReadLine();

            if (addvalue.Contains(input1))
            {
                Console.WriteLine("Use Some Other Value");
                input1 = Console.ReadLine();
                addvalue.Add(input1);
            }
            else
            {
                addvalue.Add(input1);
            }
            string[,] result = action(value,input1, i);
            bool status = CheckResult(value);
            Display(result);
            return status;
        }


        static void Main(string[] args)
        {
            string[,] value = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            List<string> vs = new List<string>();
            int i = 1;
            bool status = false;
            Display(value);
            while (i <= 9)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("player 1 should start");
                    bool result = performAction(value, i,vs);
                    
                    if (result == true)
                    {
                        status = result;
                        Console.WriteLine("Player one Wins.....");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("player 2 should start");
                    bool result = performAction(value, i,vs);
                    if (result == true)
                    {
                        status = result;
                        Console.WriteLine("Player one Wins.....");
                        break;
                    }
                }
                i++;
            }
            if (status == false)
            {
                Console.WriteLine("Match seems to be tied");
            }
            Console.ReadLine(); 
        }
    }
}
