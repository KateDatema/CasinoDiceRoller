
using System;

namespace CasinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)

    
        {
            bool goOn = true;
            while (goOn == true)
            {
                string input = GetUserInput("How many side would you like your pair of dice to have? (example 6)");

                
                try
                { int sidesOfDic = int.Parse(input);
                    if (sidesOfDic<2)
                    { throw new Exception("Sorry, That's too low of  a number, please choose something above 2"); }
                    Rolling(sidesOfDic);

                    GetContinue();
                }
                
                catch (FormatException)
                {
                    Console.WriteLine("That's not a vaild number, please try again");
                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                


               
            }

        }



        public static void Rolling(int sidesOfDic)
        {
            Random r = new Random();
            int roll1;
            int roll2;
            int total = 0;

            roll1 = r.Next(1, sidesOfDic + 1);
            roll2 = r.Next(1, sidesOfDic + 1);

            total += roll1 + roll2;
            Console.WriteLine($"Your first dice was {roll1} and your second dice was {roll2}");
               
            Console.WriteLine($"Total: {total}");
            if (sidesOfDic == 6)
            {
                if (roll1== 1 && roll2 ==1)
                { Console.WriteLine("YOU GOT SNAKE EYES!"); }
                else if (roll1==1 && roll2==2 || roll2==1 && roll1==2)
                { Console.WriteLine("You got Ace Deuce"); }
                else if (roll1== 6 && roll2 ==6)
                { Console.WriteLine("You got BOX CARS"); }
                else if (total == 7 || total == 11)
                { Console.WriteLine("Thats a win"); }
                else if (total == 2 || total == 3 || total == 12)
                { Console.WriteLine("CRAPS"); } 
            }
         
        }

      

        //functions for getting user data
        public static string GetUserInput(string desiredInput)
        {
            Console.WriteLine($"{desiredInput}");
            string input = Console.ReadLine();
            
            return input;
        }

        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to continue? y/n");
            string answer = Console.ReadLine();

            //There are 3 cases we care about 
            //1) y - we want to continue 
            //2) n - we want to stop 
            //3) anything else - we want to try again

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                //Calling a method inside itself is called recursion
                //Think of this as just trying again 
                return GetContinue();
            }
        }
    }
    
}