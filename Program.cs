﻿namespace slot_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] row1 = new int[3];
            int[] row2 = new int[3];
            int[] row3 = new int[3];

            var rand = new Random();

            for (int i = 0; i < row1.Length; i++)
            {
                row1[i] = rand.Next(1, 10);
            }
        }
    }
}

