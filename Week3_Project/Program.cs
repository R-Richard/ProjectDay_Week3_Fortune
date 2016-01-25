using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part I: user input and convert data to uppercase to make later comparisons easy - Clear screen after each input to keep console clean
            int restart = 0;
            string restartAsString;
            while (true)
            {
                // FIRST AND LAST NAME
                Console.WriteLine("User, please enter your first name:");
                String firstNameAsString = Console.ReadLine();
                string firstNameUpper = firstNameAsString.ToUpper();
                Console.Clear();

                Console.WriteLine(firstNameAsString + ", please enter your last name:");
                String lastNameAsString = Console.ReadLine();
                string lastNameUpper = lastNameAsString.ToUpper();
                Console.Clear();


                // Age - Test for valid nbr entry; loop until valid nbr is entered

                Console.WriteLine("Please enter your age:");

                int ageAsInt;

                do
                {

                    string age = Console.ReadLine();


                    bool numVer = int.TryParse(age, out ageAsInt);
                    if ((age == "0") || (ageAsInt != 0))
                    {
                        break;
                    }
                    if (ageAsInt == 0)
                    {
                        Console.WriteLine("Please enter a number charachter greater than or equal to 0:");
                    }
                }
                while (ageAsInt == 0);

                Console.Clear();


                // Birth Month - user input and convert name to uppercase.  Test for a valid entry
                

                Console.WriteLine("What month were you born in?");
                string[] monthArray = { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
                string birthMonthUpper;
                int monthVer;
                int monthSum = 0;

                do
                {
                    string birthMonth = Console.ReadLine();
                    birthMonthUpper = birthMonth.ToUpper();


                    for (monthVer = 0; monthVer < monthArray.Length; monthVer++)
                    {
                        if (birthMonthUpper != monthArray[monthVer])
                        {
                            continue;
                        }
                        else
                            monthSum++;
                    }
                    if (monthSum == 0)
                    {
                        Console.WriteLine("That is not a valid entry, type in the name of the month:");
                    }

                }
                while (monthSum == 0);
                Console.Clear();

                // Color & 'Help' on ROYGBIV
 

                Console.WriteLine("What is your favorite ROYGBIV color?" + "\n\nIf you need a reminder of what ROYGBIV stands for, type \"help\".");

                string colorResponse = Console.ReadLine();
                string[] colorArray = { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET" };
                int colorLength = colorArray.Length;
                string colorResponseUpper;
                int colorSum = 0;

                // Convert color to uppercase & compare to make sure color entered is ROYGBIV

                colorResponseUpper = colorResponse.ToUpper();

                do
                {
                    if (colorResponse.Equals("HELP", StringComparison.CurrentCultureIgnoreCase))

                    {
                        Console.WriteLine("\nYour ROYGBIV color options are:\n");
                        foreach (string color in colorArray)
                        {
                            Console.WriteLine(color);

                        }
                        Console.WriteLine("\nEnter your favorite color from the options listed above.");
                        colorResponse = Console.ReadLine();
                        colorResponseUpper = colorResponse.ToUpper();
                    }

                    for (int colorInt = 0; colorInt < colorLength; colorInt++)
                    {
                        if (colorResponseUpper != colorArray[colorInt])
                        {
                            continue;
                        }
                        else
                            colorSum++;
                    }
                    if (colorSum == 0)
                    {
                        Console.WriteLine("That is not a valid entry, try again:");
                        colorResponse = Console.ReadLine();
                        colorResponseUpper = colorResponse.ToUpper();
                    }
                    if (colorSum != 0)
                    {
                        break;
                    }

                }
                while (colorSum == 0);

                Console.Clear();


                // Siblings - verify entry is number

                Console.WriteLine("How many siblings do you have:");

                int siblingsAsInt;

                do
                {

                    string siblingsAsString = Console.ReadLine();


                    bool numVer = int.TryParse(siblingsAsString, out siblingsAsInt);
                    if ((siblingsAsString == "0") || (siblingsAsInt != 0))
                    {
                        break;
                    }
                    if (siblingsAsInt == 0)
                    {
                        Console.WriteLine("That is an invalid entry, please enter the number of siblings using a charachter greater than or equal to 0:");
                    }
                }
                while (siblingsAsInt == 0);

                Console.Clear();

                // Part 2


                // Age determines # of years till retirement
                int yearsTillRetire;
                string yearsTillRetireString;
                if (ageAsInt % 2 == 0)
                {
                    yearsTillRetire = 44;
                    yearsTillRetireString = Convert.ToString(yearsTillRetire);
                }
                else
                {
                    yearsTillRetire = 6;
                    yearsTillRetireString = Convert.ToString(yearsTillRetire);
                }
                string yearsTillRetireFinal = (yearsTillRetireString + " years");


                // Siblings determines location
                string locationAsString;
                switch (siblingsAsInt)
                {
                    case 0:
                        locationAsString = "Cleveland, Ohio";
                        break;
                    case 1:
                        locationAsString = "Anchorage, Alaska";
                        break;
                    case 2:
                        locationAsString = "London, England";
                        break;
                    case 3:
                        locationAsString = "the Andromeda galaxy";
                        break;
                    default:
                        locationAsString = "Hawaii";
                        break;
                }

           

                // Color - determines mode of transport
                string modeOfTransport;
                switch (colorResponseUpper)
                {
                    case "RED":
                        modeOfTransport = "car";
                        break;
                    case "ORANGE":
                        modeOfTransport = "jet";
                        break;
                    case "YELLOW":
                        modeOfTransport = "uBoat";
                        break;
                    case "GREEN":
                        modeOfTransport = "pair of tired feet";
                        break;
                    case "BLUE":
                        modeOfTransport = "bicycle";
                        break;
                    case "INDIGO":
                        modeOfTransport = "bus";
                        break;
                    case "VIOLET":
                        modeOfTransport = "a pair of stilts";
                        break;
                    default:
                        modeOfTransport = "Segway";
                        break;
                }
              


                // Letters in birth month in last name = money in bank
                // NOTE = in cases where 1st, 2nd and 3rd letter is in first or last name -  bank amount is added together
                // NOTE = in cases where no letters are in first or last name - bank amount is $0 
                double bankAmt1;
                double bankAmt2;
                double bankAmt3;
                int sum = 0;

                // First letter of month in first or last name:
                for (int i = 0; i < firstNameUpper.Length; i++)
                {
                    if (birthMonthUpper[0] != firstNameUpper[i])
                    {
                        continue;
                    }
                    sum += 1;

                }
                for (int i = 0; i < lastNameUpper.Length; i++)
                {
                    if (birthMonthUpper[0] != lastNameUpper[i])
                    {
                        continue;

                    }
                    sum += 1;
                }

                if (sum > 0)
                {

                    bankAmt1 = 100000000.35;
                }
                else
                {
                    bankAmt1 = 0.00;
                }

                // Second letter of month in first or last name:
                sum = 0;
                for (int i = 0; i < firstNameUpper.Length; i++)
                {
                    if (birthMonthUpper[1] != firstNameUpper[i])
                    {
                        continue;
                    }
                    sum += 1;

                }
                for (int i = 0; i < lastNameUpper.Length; i++)
                {
                    if (birthMonthUpper[1] != lastNameUpper[i])
                    {
                        continue;

                    }
                    sum += 1;
                }

                if (sum > 0)
                {

                    bankAmt2 = 2.75;
                }
                else
                {
                    bankAmt2 = 0.00;
                }

                // Third letter of month in first or last name:
                sum = 0;
                for (int i = 0; i < firstNameUpper.Length; i++)
                {
                    if (birthMonthUpper[2] != firstNameUpper[i])
                    {
                        continue;
                    }
                    sum += 1;

                }
                for (int i = 0; i < lastNameUpper.Length; i++)
                {
                    if (birthMonthUpper[2] != lastNameUpper[i])
                    {
                        continue;

                    }
                    sum += 1;
                }

                if (sum > 0)
                {

                    bankAmt3 = 300000.99;
                }
                else
                {
                    bankAmt3 = 0.00;
                }


                double bankTotal = (bankAmt1 + bankAmt2 + bankAmt3);
                string bankTotalAsCurrency = string.Format("${0:n}", bankTotal);

                Console.WriteLine(firstNameAsString + " " + lastNameAsString + " will retire in " + yearsTillRetireFinal + " with " + bankTotalAsCurrency + " in the bank, a vacation home in " + locationAsString + " and a " + modeOfTransport + ".");

                Console.WriteLine("\n\nEnter \"Y\" If You Would Like To Try Again.\nEnter any other charachter to end.");
                restartAsString = Console.ReadLine();
                

                Console.Clear();

                if (restartAsString.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    restart = 0;
                }
                else
                {
                    Environment.Exit(0);
                }
            }

        }
    }
}
