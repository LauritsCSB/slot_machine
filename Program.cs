namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] slotRow = randomNumbers();
            int[] slotRow2 = randomNumbers();
            int[] slotRow3 = randomNumbers();

            //TODO Create game loop asking if user wants to play

            //TODO Output slot machine rows to user

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

