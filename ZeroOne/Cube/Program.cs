using System;
using System.Collections.Generic;

namespace Cube
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * left  -> 0x1b
             * right -> 0x2d
             * step  -> 0x3c
             * back  -> 0x4f
             */

            var program1 = new List<string> { "0x1b", "0x2d", "0x1b", "0x3c", "0x3c", "0x4f", "0x4f" };

            program1.ForEach(s => {
                if (s == "0x1b") Console.WriteLine("left");
                else if (s == "0x2d") Console.WriteLine("right");
                else if (s == "0x3c") Console.WriteLine("step");
                else if (s == "0x4f") Console.WriteLine("back");
                else throw new InvalidOperationException("Invalid OpCode");
            });


            Console.WriteLine("////////////");


            /*
             * turn left | right  -> 0xef 0xe0 | 0xe1
             * step (-|+) -> 0xbf 0xb0 | 0xb1
             */

            var program2 = new List<string>
            {
                "0xef", "0xe0", "0xef", "0xe1", "0xef", "0xe0", "0xbf", "0xb1", "0xbf", "0xb1", "0xbf", "0xb0", "0xbf", "0xb0"
            };

            var opCode = new List<string> { "0xef", "0xbf" };

            for (int i = 0; i < program2.Count; i++)
            {
                if (i % 2 == 0 && opCode.Contains(program2[i]))
                {
                    if (program2[i] == "0xef") Console.Write("turn ");
                    else if (program2[i] == "0xbf") Console.Write("step ");
                    else throw new InvalidOperationException("Invalid OpCode");
                }
                else
                {
                    if (program2[i] == "0xe0") Console.WriteLine("left");
                    else if (program2[i] == "0xe1") Console.WriteLine("right");
                    else if (program2[i] == "0xb0") Console.WriteLine("-");
                    else if (program2[i] == "0xb1") Console.WriteLine("+");
                    else throw new InvalidOperationException("Invalid Operant");
                }
            }

        }
    }
}
