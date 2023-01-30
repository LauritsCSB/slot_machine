namespace slot_machine
{
    class Program
    {
        const int PLAYMONEY = 100;
        static void Main(string[] args)
        {
            int[] slotRow1 = RandomNumbers();
            int[] slotRow2 = RandomNumbers();
            int[] slotRow3 = RandomNumbers();

            int prizeMoney = PLAYMONEY + 10;
            string wantToPlay = string.Empty;
            string lockOrNo;
            string lockRowNumber;
            string pullAgain;

            do
            {
                prizeMoney -= 10;
                Console.WriteLine($"{slotRow1[0]} {slotRow1[1]} {slotRow1[2]}");
                Console.WriteLine($"{slotRow2[0]} {slotRow2[1]} {slotRow2[2]}");
                Console.WriteLine($"{slotRow3[0]} {slotRow3[1]} {slotRow3[2]}");
                Console.WriteLine($"Prizemoney: ${prizeMoney}");

                if (TwoRowsSame(slotRow1, slotRow2) || TwoRowsSame(slotRow1, slotRow3) || TwoRowsSame(slotRow2, slotRow3))
                {
                    prizeMoney += 50;
                    Console.WriteLine("Two rows same!");

                    if (AllRowsSame(slotRow1, slotRow2, slotRow3))
                    {
                        prizeMoney += 100;
                        Console.WriteLine("All rows same!");
                    }
                }

                if (CrossRows(slotRow1, slotRow2, slotRow3))
                {
                    prizeMoney += 35;
                    Console.WriteLine("Cross rows!");
                }

                if (SlashRow(slotRow1, slotRow2, slotRow3))
                {
                    prizeMoney += 25;
                    Console.WriteLine("Slash row!");
                }

                if (OneRow(slotRow1) || OneRow(slotRow2) || OneRow(slotRow3))
                {
                    prizeMoney += 15;
                    Console.WriteLine("One row same!");
                }

                lockOrNo = UserInput("Do you want to lock a row? Type y for yes and press enter.");
                if (lockOrNo.Equals("y"))
                {
                    Console.WriteLine("Type 1 to lock first row, type 2 for second and 3 for third.");
                    lockRowNumber = Console.ReadLine();
                    switch (Int32.Parse(lockRowNumber))
                    {
                        case 1:
                            slotRow2 = RandomNumbers();
                            slotRow3 = RandomNumbers();
                            prizeMoney -= 10;
                            break;
                        case 2:
                            slotRow1 = RandomNumbers();
                            slotRow3 = RandomNumbers();
                            prizeMoney -= 10;
                            break;
                        case 3:
                            slotRow2 = RandomNumbers();
                            slotRow3 = RandomNumbers();
                            prizeMoney -= 10;
                            break;
                        default:
                            break;
                    }
                }
                
                pullAgain = UserInput("Refresh all rows? Press y for yes, type anything else for no and press enter.");
                if (pullAgain.Equals("y"))
                {
                    slotRow1 = RandomNumbers();
                    slotRow2 = RandomNumbers();
                    slotRow3 = RandomNumbers();
                }
                
                wantToPlay = UserInput("Run again? type y for yes, type anything else for no and press enter");
                Console.Clear();

            } while (wantToPlay.Equals("y") && prizeMoney > 0);

            Console.WriteLine(prizeMoney > 0 ? $"Congratulations, you won ${prizeMoney}!" : "Sorry you lost.. everything!");

            //TODO Fix game locking row loop to check for rewards and decrease playmoney every time lock mehtod is used. Figure out when
            // all slotrows should be reset
        }

        static string UserInput(string decision)
        {
            Console.WriteLine(decision);
            string answer = Console.ReadLine().ToLower();
            return answer;
        }

        static int[] RandomNumbers()
        {
            var rand = new Random();
            return new[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
        }

        static bool TwoRowsSame(int[] firstArray, int[] secondArray)
        {
            return Enumerable.SequenceEqual(firstArray, secondArray);
        }

        static bool AllRowsSame(int[] firstArray, int[] secondArray, int[] thirdArray)
        {
            bool everyRowSame = false;
            if (Enumerable.SequenceEqual(firstArray, secondArray) && Enumerable.SequenceEqual(secondArray, thirdArray))
            {
                everyRowSame = true;
            }
            return everyRowSame;
        }

        static bool CrossRows(int[] firstArray, int[] secondArray, int[] thirdArray)
        {
            bool slotsCross = false;
            int boolCounter = 0;
            if (firstArray[0] == firstArray[2])
            {
                boolCounter++;

                if (secondArray[1] == thirdArray[0])
                {
                    boolCounter++;

                    if (thirdArray[0] == thirdArray[2])
                    {
                        boolCounter++;
                    }
                }
            }

            if (boolCounter == 3)
            {
                slotsCross = true;
            }

            return slotsCross;
        }

        static bool SlashRow(int[] firstArray, int[] secondArray, int[] thirdArray)
        {
            bool slashRow = false;

            if (firstArray[0] == secondArray[1] && secondArray[1] == thirdArray[2])
            {
                slashRow = true;
            }

            if (firstArray[2] == secondArray[1] && secondArray[1] == thirdArray[0])
            {
                slashRow = true;
            }

            return slashRow;
        }

        static bool OneRow(int[] array)
        {
            bool oneRow = false;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[0])
                {
                    oneRow = true;
                }
                else
                {
                    oneRow = false;
                }
            }

            return oneRow;
        }
    }
}

