﻿namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] row1 = randomNumberArray();
            int[] row2 = randomNumberArray();
            int[] row3 = randomNumberArray();

            //var rand = new Random();

            /*
            for (int i = 0; i < row1.Length; i++)
            {
                row1[i] = rand.Next(1, 10);
            }

            for (int i = 0; i < row2.Length; i++)
            {
                row2[i] = rand.Next(1, 10);
            }

            for (int i = 0; i < row3.Length; i++)
            {
                row3[i] = rand.Next(1, 10);
            }
            */
        }

        static int[] randomNumberArray()
        {
            var rand = new Random();
            return new[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
        }
    }
}

