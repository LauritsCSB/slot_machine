namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] slotRow = randomNumbers();
            int[] slotRow2 = randomNumbers();
            int[] slotRow3 = randomNumbers();
            int playMoney = 100;
            string wantToPlay = string.Empty;
            string lockOrNo;
            string lockRowNumber;

            do
            {
                Console.WriteLine($"{slotRow[0]} {slotRow[1]} {slotRow[2]}");
                Console.WriteLine($"{slotRow2[0]} {slotRow2[1]} {slotRow2[2]}");
                Console.WriteLine($"{slotRow3[0]} {slotRow3[1]} {slotRow3[2]}");

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
                            slotRow3 = randomNumbers()
                            continue;
                        case 2:
                            slotRow = randomNumbers();
                            slotRow3 = randomNumbers();
                            break;
                        case 3:
                            slotRow2 = randomNumbers();
                            slotRow3 = randomNumbers();
                            break;
                        default:
                            break;
                    }
                }


                Console.WriteLine("Pull again? Press y for yes, type anything else for no and press enter.");
                wantToPlay = Console.ReadLine().ToLower();
                Console.Clear();
            } while (wantToPlay.Equals("y") && playMoney > 0);

            Console.WriteLine(playMoney > 0 ? $"Congratulations, you won ${playMoney}!" : "Sorry you lost..");


            //TODO Create function to "lock" 1 or 2 rows (switch between methods)

            //TODO Create function to collect rewards (All numbers same, cross rows same, two rows same,
            //"slash row same", one row same

            //TODO Keep track of pricemoney, maybe withdraw amount for locking rows?

            //TODO Output pricemoney and message to user if game isn't continued or lost
        }

        static int[] randomNumbers()
        {
            var rand = new Random();
            return new[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
        }
    }
}

