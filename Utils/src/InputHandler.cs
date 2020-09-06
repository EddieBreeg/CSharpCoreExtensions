using System;
using System.Linq;
using System.Collections.Generic;

namespace System
{
    /// <name>InputHandler</name>
    /// <summary>
    /// A static class which contains useful methods to handle user inputs
    /// </summary>
    public static class InputHandler
    {
        /// <name>KeyInput</name>
        /// <code>KeyInput(string str, char defaultValue)</code>
        /// <summary>
        /// Prompts the user to press a key
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">Defines what will be returned if the user presses Enter</param>
        /// <returns>A char object representing the key</returns>
        public static char KeyInput(string str, char defaultValue='\0')
        {
            Console.Write(str);
            var input = Console.ReadKey().KeyChar;
            return input != 13 ? input : defaultValue;
        }
        /// <name>KeyInput</name>
        /// <code>KeyInput(string str, char[] choices, char defaultValue='\0')</code>
        /// Lets the user choose a key between some default values
        /// <param name="str">The string to print out</param>
        /// <param name="choices">The different options the user can choose from</param>
        public static char KeyInput(string str, char[] choices, char defaultValue='\0')
        {
            var value = KeyInput(str, defaultValue);
            while(!choices.Contains(value) && value != '\r')
            {
                Console.WriteLine("Invalid choice! Please try again.");
                value = KeyInput(str, defaultValue);
            }
            return value != 13 ? value : defaultValue;
        }
        /// <name>LineInput</name>
        /// <code>LineInput(string str, string defaultValue = "")</code>
        /// <summary>
        /// Prompts the user to enter a string of text
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">The value to return if the user hits enter</param>
        /// <returns>The string entered by the user</returns>
        public static string LineInput(string str, string defaultValue = "")
        {
            Console.Write(str);
            var input = Console.ReadLine();
            return input != "" ? input : defaultValue;
        }
        /// <name>LineInput</name>
        /// <code>LineInput(string str, string[] choices, string defaultValue)</code>
        /// <summary>Lets the user choose a string from a set of default values</summary>
        /// <param name="str">The string to print out</param>
        /// <param name="choices">An array containing the options the user can choose from</param>
        /// <param name="defaultValue">The value to return if the user hits Enter</param>
        /// <returns>The string entered by the user</returns>
        public static string LineInput(string str, string[] choices, string defaultValue)
        {
            Console.Write(str);
            var value = Console.ReadLine();
            while (!choices.Contains(value) && value != string.Empty)
            {
                Console.WriteLine("Invalid choice! Please try again.");
                Console.Write(str);
                value = Console.ReadLine();
            }
            if (value == string.Empty)
                return defaultValue;
            return value;
        }
        /// <name>IntInput</name>
        /// <code>IntInput(string str, int defaultValue = 0)</code>
        /// <summary>
        /// Prompts the user to enter an integer
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">What the function returns if the user hits Enter</param>
        /// <returns>The integer the user entered</returns>
        public static int IntInput(string str, int? defaultValue = null) => Convert.ToInt32(DoubleInput(str, defaultValue));
        /// <name>DoubleInput</name>
        /// <code>IntInput(string str, int defaultValue = 0)</code>
        /// <summary>
        /// Prompts the user to enter a double
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">What the function returns if the user hits Enter</param>
        /// <returns>The double the user entered</returns>
        public static double DoubleInput(string str, double? defaultValue = null)
        {
            Console.Write(str);
            var input = Console.ReadLine();
            if (input == string.Empty && defaultValue != null) return (double)defaultValue;
            try
            {
                return Convert.ToDouble(input);
            }
            catch(FormatException)
            {
                Console.WriteLine("Format error, please enter a numerical value");
                return DoubleInput(str, defaultValue);
            }
        }
        /// <name>ListInput</name>
        /// <code>ListInput(string str, List defaultValue = null, Func condition = null)</code>
        /// <summary>
        /// Prompts the user to enter a list of text strings
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">The list to return if the user hits Enter</param>
        /// <param name="condition">The condition the resulting list must satisfy</param>
        /// <returns>The user input as a List object</returns>
        /// <remarks>The values entered by the user should be separated by a ' '</remarks>
        public static List<string> ListInput(string str, List<string> defaultValue = null, Func<List<string>, bool> condition = null)
        {
            Console.Write(str);
            if (condition == null) condition = x => true;
            string input = Console.ReadLine().TrimEnd();
            List<string> result;
            try
            {
                result = input.Length > 0 ? input.Split(' ').ToList() : defaultValue;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice!");
                return ListInput(str, defaultValue, condition);
            }
            if (!condition(result) || result == null)
            {
                Console.WriteLine("Invalid choice!");
                return ListInput(str, defaultValue, condition);
            }
            return result;
        }
        /// <name>IntListInput</name>
        /// <code>IntListInput(string str, List defaultValue = null, Func condition = null)</code>
        /// <summary>
        /// Prompts the user to enter a list of integers
        /// </summary>
        /// <param name="str">The string to print out</param>
        /// <param name="defaultValue">The list to return if the user hits Enter</param>
        /// <param name="condition">The condition the resulting list must satisfy</param>
        /// <returns>The user input as a List object</returns>
        /// <remarks>The values entered by the user should be separated by a ' '</remarks>
        public static List<int> IntListInput(string str, List<int> defaultValue = null, Func<List<int>, bool> condition = null)
        {
            Console.Write(str);
            if (condition == null) condition = x => true;
            string input = Console.ReadLine().TrimEnd();
            List<int> result;
            try
            {
                result = input.Length > 0 ? input.Split(' ').Select(x => Convert.ToInt32(x)).ToList() : defaultValue;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice!");
                return IntListInput(str, defaultValue, condition);
            }
            if (!condition(result) || result == null)
            {
                Console.WriteLine("Invalid choice!");
                return IntListInput(str, defaultValue, condition);
            }
            return result;
        }
    }
}