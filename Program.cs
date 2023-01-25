namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] slotRow = randomNumbers();
            int[] slotRow2 = randomNumbers();
            int[] slotRow3 = randomNumbers();
            string wantToPlay;

            do
            {
                Console.WriteLine(slotRow);
                Console.WriteLine(slotRow2);
                Console.WriteLine(slotRow3);

                Console.WriteLine("Pull again? Press y for yes, type anything else for no");
                wantToPlay = Console.ReadLine().ToLower();
            } while (wantToPlay == "y");


            //TODO Create function to "lock" 1 or 2 rows (switch between methods)

            //TODO Create function to collect rewards (All numbers same, cross rows same, two rows same,
            //"slash row same", one row same

            //TODO Keep track of pricemoney, maybe withdraw amount for locking rows?
        }

        static int[] randomNumbers()
        {
            var rand = new Random();
            return new[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
        }
    }
}

