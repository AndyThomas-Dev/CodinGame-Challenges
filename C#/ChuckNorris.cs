using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TestEnv
{
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
