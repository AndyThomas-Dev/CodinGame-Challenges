using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TestEnv
{
        // ~~ The Goal ~~
        //Binary with 0 and 1 is good, but binary with only 0, or almost, is even better! Originally, this is a concept designed by Chuck Norris to send so called unary messages.

        //Write a program that takes an incoming message as input and displays as output the message encoded using Chuck Norris’ method.

        //Rules
        //Here is the encoding principle:

        //The input message consists of ASCII characters(7-bit)
        //The encoded output message consists of blocks of 0
        //A block is separated from another block by a space
        //Two consecutive blocks are used to produce a series of same value bits(only1 or0 values):
        //- First block: it is always 0 or 00. If it is 0, then the series contains 1, if not, it contains 0
        //- Second block: the number of 0 in this block is the number of bits in the series
        //Example
        //Let’s take a simple example with a message which consists of only one character: Capital C. C in binary is represented as 1000011, so with Chuck Norris’ technique this gives:

        //0 0 (the first series consists of only a single 1)
        //00 0000 (the second series consists of four 0)
        //0 00 (the third consists of two 1)
        //So C is coded as: 0 0 00 0000 0 00

 
        //Second example, we want to encode the message CC (i.e. the 14 bits 10000111000011) :

        //0 0 (one single 1)
        //00 0000 (four 0)
        //0 000 (three 1)
        //00 0000 (four 0)
        //0 00 (two 1)
        //So CC is coded as: 0 0 00 0000 0 000 00 0000 0 00
    
    class Program
    {
        public int counterInput = 0;
        public int counterOutput = 0;

        // Chuck Norris game
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();
            Program x = new Program();
            string binary = "";

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            // Console.WriteLine(ToBinary(MESSAGE));

            foreach(char c in MESSAGE)
            {
                binary += ToBinary(Char.ToString(c)).Remove(0, 1);
            }

            string result = x.Loop(binary);

             // System.Diagnostics.Trace.WriteLine("Binary " + binary);
             // Return result
             Console.WriteLine(result);
            
        }

        public string Loop(string input)
        {
            string result = "";

            while (counterInput < input.Length)
            {
                if (input[counterInput] == '1')
                {
                    result += "0 ";

                    if (counterInput < input.Length - 1)
                    {

                        // Only one 1
                        if (input[counterInput + 1] != '1')
                        {
                            result += "0 ";
                        }

                        // Multiple 1s
                        if (input[counterInput + 1] == '1')
                        {
                            result += "0";
                            result += Amend(input, '1');
                        }

                    }
                    else{

                        result += "0";

                    }

                }

                if (input[counterInput] == '0')
                {
                    result += "00 ";

                    if (counterInput < input.Length - 1)
                    {

                        // Only one 1
                        if (input[counterInput + 1] != '0')
                        {
                            result += "0 ";
                        }

            
                        // Multiple 1s
                        if (input[counterInput + 1] == '0')
                        {
                            result += "0";
                            result += Amend(input, '0');
                        }

                    }
                    
                    else{

                        result += "0";

                    }
                    

                }



                counterInput++;
            }

            return result;
        }

        public string Amend(string input, char bin)
        {
            string output = "";
            counterOutput = counterInput + 1;

            if (counterOutput < input.Length)
            {
                while (input[counterOutput] == bin)
                {

                    output += "0";

                    counterOutput++;
                    counterInput++;

                    if (counterOutput >= input.Length)
                    {
                        return output;
                    }
                }

            }

            output += " ";
            return output;
        }

        // Convert to Binary string
        public static string ToBinary(string data, bool formatBits = false)
        {
            char[] buffer = new char[(((data.Length * 8) + (formatBits ? (data.Length - 1) : 0)))];
            int index = 0;

            for (int i = 0; i < data.Length; i++)
            {
                string binary = Convert.ToString(data[i], 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++)
                {
                    buffer[index] = binary[j];
                    index++;
                }
                if (formatBits && i < (data.Length - 1))
                {
                    buffer[index] = ' ';
                    index++;
                }
            }
            return new string(buffer);
        }
    }
}
