using System;

namespace QualifyCarInsurance
{
    class Program
    {
        private static uint GetUIntNumericValue(int attempts = 3, uint valueIfParseFails = 0)
        {
            Console.Write("Enter any whole number:  ");
            string temp = "";
            uint uintNum = valueIfParseFails;
            int n = 0; //the number of times the user has entered unrecognized values
            bool validEntry = false; //used to repeat opportunities to enter valid data
            while (!validEntry & n < attempts)
            {
                temp = Console.ReadLine();
                validEntry = uint.TryParse(temp, out uintNum);
                if (!validEntry)
                {
                    n++;
                    if (n < attempts)
                    {
                        Console.Write("Sorry, we had trouble recognizing that as a whole number. Please try again:  ");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, for demonstration purposes, we'll record that as the number {0}.", valueIfParseFails);
                        uintNum = valueIfParseFails; //set again because TryParse() converts "" to 0 even though it returns a false value
                    }
                }
            }
            return uintNum;
        }

        private static bool GetBooleanValue(int attempts = 3, bool valueIfParseFails = false)
        {
            Console.Write("Enter \"yes\" or \"no\":  ");
            string temp = "";
            bool result = valueIfParseFails;
            int n = 0; //the number of times the user has entered unrecognized values
            bool validEntry = false; //used to repeat opportunities to enter valid data
            while (!validEntry & n < attempts)
            {
                temp = Console.ReadLine();
                temp = temp.ToLower();
                switch (temp)
                {
                    case "yes":
                        result = true;
                        validEntry = true;
                        break;
                    case "no":
                        result = false;
                        validEntry = true;
                        break;
                    default:
                        validEntry = false;
                        n++;
                        if (n < attempts)
                        {
                            Console.Write("Sorry, we had trouble recognizing that response. Please try again:  ");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, for demonstration purposes, we'll record that as a \"{0}\".",
                                valueIfParseFails == true ? "yes" : "no");
                            result = valueIfParseFails;
                        }
                        break;
                }
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("ACME Insurance Qualifier");
            Console.WriteLine();
            Console.Write("What is your age? ");
            uint age = GetUIntNumericValue(3, 15);
            Console.WriteLine("Have you ever had a DUI? ");
            bool hadDUI = GetBooleanValue(3, false);
            Console.WriteLine("How many speeding tickets have you had? ");
            uint numTickets = GetUIntNumericValue(3, 0);
            Console.WriteLine();
            if (age >= 16 && !hadDUI && numTickets <= 3)
            {
                Console.WriteLine("Congratulations! You qualify for car insurance with ACME.");
            }
            else
            {
                Console.WriteLine("Oh, we're sorry. Unfortunately, you do not qualify for car insurance with ACME.");
            }
        }
    }
}
