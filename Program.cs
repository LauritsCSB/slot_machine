namespace slot_machine
{
    class Program
    {
        const int PLAYMONEY = 100;
        static void Main(string[] args)
        {
            int prizeMoney = PLAYMONEY + 10;
            string wantToPlay = string.Empty;
            string lockOrNo;
            string lockRowNumber;

            do
            {
                prizeMoney -= 10;
                int[] slotRow1 = randomNumbers();
                int[] slotRow2 = randomNumbers();
                int[] slotRow3 = randomNumbers();
                Console.WriteLine($"{slotRow1[0]} {slotRow1[1]} {slotRow1[2]}");
                Console.WriteLine($"{slotRow2[0]} {slotRow2[1]} {slotRow2[2]}");
                Console.WriteLine($"{slotRow3[0]} {slotRow3[1]} {slotRow3[2]}");
                Console.WriteLine($"Prizemoney: ${prizeMoney}");

                if (twoRowsSame(slotRow1, slotRow2) || twoRowsSame(slotRow1, slotRow3) || twoRowsSame(slotRow2, slotRow3))
                {
                    prizeMoney += 50;

                    if (allRowsSame(slotRow1, slotRow2, slotRow3))
                    {
                        prizeMoney += 100;
                    }
                }

                if (crossRows(slotRow1, slotRow2, slotRow3))
                {
                    prizeMoney += 35;
                }

                if (slashRow(slotRow1, slotRow2, slotRow3))
                {
                    prizeMoney += 25;
                }

                if (oneRow(slotRow1) || oneRow(slotRow2) || oneRow(slotRow3))
                {
                    prizeMoney += 15;
                }

                Console.WriteLine("Do you want to lock a row? Type y for yes and press enter.");
                lockOrNo = Console.ReadLine().ToLower();
                if (lockOrNo.Equals("y"))
                {
                    Console.WriteLine("Type 1 to lock first row, type 2 for second and 3 for third.");
                    lockRowNumber = Console.ReadLine();
                    switch (Int32.Parse(lockRowNumber))
                    {
                        case 1:
                            slotRow2 = randomNumbers();
                            slotRow3 = randomNumbers();
                            prizeMoney -= 10;
                            break;
                        case 2:
                            slotRow1 = randomNumbers();
                            slotRow3 = randomNumbers();
                            prizeMoney -= 10;
                            break;
                        case 3:
                            slotRow2 = randomNumbers();
                            slotRow3 = randomNumbers();
                            prizeMoney -= 10;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("Pull again? Press y for yes, type anything else for no and press enter.");
                wantToPlay = Console.ReadLine().ToLower();
                Console.Clear();

            } while (wantToPlay.Equals("y") && prizeMoney > 0);

            Console.WriteLine(prizeMoney > 0 ? $"Congratulations, you won ${prizeMoney}!" : "Sorry you lost.. everything!");

            //TODO Fix game locking row loop to check for rewards and decrease playmoney every time lock mehtod is used. Figure out when
            // all slotrows should be reset
        }

        static int[] randomNumbers()
        {
            var rand = new Random();
            return new[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
        }

        static bool twoRowsSame(int[] firstArray, int[] secondArray)
        {
            return Enumerable.SequenceEqual(firstArray, secondArray);
        }

        static bool allRowsSame(int[] firstArray, int[] secondArray, int[] thirdArray)
        {
            bool everyRowSame = false;
            if (Enumerable.SequenceEqual(firstArray, secondArray) && Enumerable.SequenceEqual(secondArray, thirdArray))
            {
                everyRowSame = true;
            }
            return everyRowSame;
        }

        static bool crossRows(int[] firstArray, int[] secondArray, int[] thirdArray)
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

        static bool slashRow(int[] firstArray, int[] secondArray, int[] thirdArray)
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

        static bool oneRow(int[] array)
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

