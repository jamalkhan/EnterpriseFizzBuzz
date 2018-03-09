using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please specify your ruleset:");
             var ruleSet = (FizzBuzzRuleSet)Enum.Parse(
                typeof(FizzBuzzRuleSet), Console.ReadLine());
            
            IFizzBuzzEngine engine = FizzBuzzEngineFactory.Create(ruleSet);

            Console.WriteLine("Please Enter a Value:");
            var number = int.Parse(Console.ReadLine());
            while (number > 0)
            {
                var value = engine.GetString(number);
                Console.WriteLine($"{number} = {value}" );
                Console.WriteLine("Please Enter a New Value:");
                number = int.Parse(Console.ReadLine());
            }
        }
    }


    /// <summary>
    /// Defines the interface for playing a Fizz Buzz game.
    /// </summary>
    public interface IFizzBuzzEngine
    {
        /// <summary>
        /// Gets the output from a single round in a Fizz Buzz game.
        /// </summary>
        string GetString(int number);
    }

    /// <summary>
    /// Defines various rule sets for Fizz Buzz games.
    /// </summary>
    public enum FizzBuzzRuleSet
    {
        /// <summary>
        /// The standard game - based on the divisibility of a number.
        /// </summary>
        FizzBuzzDivisible,

        /// <summary>
        /// The standard game with additional substitutions for divisibility.
        /// </summary>
        FizzBuzzBoomBangCrashDivisible,

        /// <summary>
        /// A game based on the digits contained in a number.
        /// </summary>
        FizzBuzzDigits,

        /// <summary>
        /// A combination of FizzBuzzDivisible and FizzBuzzDigits.
        /// </summary>
        FizzBuzzDivisibleOrDigits
    }

    public static class FizzBuzzEngineFactory
    {
        public static IFizzBuzzEngine Create(FizzBuzzRuleSet ruleSet)
        {
            switch (ruleSet)
            {
                case FizzBuzzRuleSet.FizzBuzzBoomBangCrashDivisible:
                    return new FizzBuzzBoomBangCrashDivisible();
                case FizzBuzzRuleSet.FizzBuzzDigits:
                    return new FizzBuzzDigits();
                case FizzBuzzRuleSet.FizzBuzzDivisible:
                    return new FizzBuzzDivisible();
                case FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits:
                    return new FizzBuzzDivisibleOrDigits();
            }
            throw new NotImplementedException("This ruleset has not been implemented");
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsDivisibleByAll(this int input, params int[] divisors)
        {
            foreach (var divisor in divisors)
            {
                if (input % divisor != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string ConvertDigitsToString(this int input, bool outputInput, params DigitString[] digitStrings)
        {
            var sb = new StringBuilder(input.ToString());

            if (digitStrings.Any(ds => ds.Digit >= 10 || ds.Digit < 0))
            {
                throw new ArgumentOutOfRangeException("digitStrings", "digitStrings must be have a Digit between 0 and 9, inclusive.");
            }

            var alldigits = new ushort[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var unusedDigits = alldigits.Where(d => !digitStrings.Any(ds => ds.Digit == d));

            // Remove all unused digits
            foreach (var unusedDigit in unusedDigits)
            {
                sb.Replace(unusedDigit.ToString(), "");
            }

            // Now replace all matched digits
            foreach (var digitString in digitStrings)
            {
                sb.Replace(digitString.Digit.ToString(), digitString.String);
            }

            var retval = sb.ToString();
            if (outputInput && string.IsNullOrEmpty(retval))
            {
                return input.ToString();
            }
            return retval;
        }
    }

    public class DigitString
    {
        public ushort Digit { get; set; }
        public string String { get; set; }
    }

    public class DivisibleConfig
    {
        public int[] Divisors { get; set; }
        public string Output { get; set; }
        public Func<int, int[], bool> Qualifies { get; set; }
    }


    public class FizzBuzzDigits : IFizzBuzzEngine
    {
        protected virtual List<DigitString> GetDigitStrings()
        {
            return new List<DigitString>()
            {
                new DigitString() { Digit=3, String="Fizz" },
                new DigitString() { Digit=5, String="Buzz" },
            };
        }

        public virtual string GetString(int number)
        {
            return number.ConvertDigitsToString(true, GetDigitStrings().ToArray());
        }
    }

    public class FizzBuzzDivisible : IFizzBuzzEngine
    {
        protected virtual List<DivisibleConfig> GetConfigurations()
        {
            return new List<DivisibleConfig>()
            {
                new DivisibleConfig() { Divisors = new int[]{ 3 }, Output = "Fizz", Qualifies = ExtensionMethods.IsDivisibleByAll },
                new DivisibleConfig() { Divisors = new int[]{ 5 }, Output = "Buzz", Qualifies = ExtensionMethods.IsDivisibleByAll },
            };
        }

        public virtual string GetString(int number)
        {
            var sb = new StringBuilder();
            foreach (var configuration in GetConfigurations())
            {
                if (configuration.Qualifies(number, configuration.Divisors))
                {
                    sb.Append(configuration.Output);
                }
            }
            var result = sb.ToString();
            if (string.IsNullOrEmpty(result))
            {
                return number.ToString();
            }
            return sb.ToString();
        }
    }

    public class FizzBuzzBoomBangCrashDivisible : FizzBuzzDivisible, IFizzBuzzEngine
    {
        protected override List<DivisibleConfig> GetConfigurations()
        {
            return new List<DivisibleConfig>()
            {
                new DivisibleConfig() { Divisors = new int[]{ 3 }, Output = "Fizz", Qualifies = ExtensionMethods.IsDivisibleByAll },
                new DivisibleConfig() { Divisors = new int[]{ 5 }, Output = "Buzz", Qualifies = ExtensionMethods.IsDivisibleByAll },
                new DivisibleConfig() { Divisors = new int[]{ 7 }, Output = "Boom", Qualifies = ExtensionMethods.IsDivisibleByAll },
                new DivisibleConfig() { Divisors = new int[]{ 11 }, Output = "Bang", Qualifies = ExtensionMethods.IsDivisibleByAll },
                new DivisibleConfig() { Divisors = new int[]{ 13 }, Output = "Crash", Qualifies = ExtensionMethods.IsDivisibleByAll },
            };
        }
    }

    public class FizzBuzzDivisibleOrDigits : FizzBuzzDivisible, IFizzBuzzEngine
    {
        protected virtual List<DigitString> GetDigitStrings()
        {
            return new List<DigitString>()
            {
                new DigitString() { Digit=3, String="Fizz" },
                new DigitString() { Digit=5, String="Buzz" },
            };
        }

		public override string GetString(int number)
		{
            var sb = new StringBuilder();
            foreach (var configuration in GetConfigurations())
            {
                if (configuration.Qualifies(number, configuration.Divisors))
                {
                    sb.Append(configuration.Output);
                }
            }

            sb.Append(number.ConvertDigitsToString(false, GetDigitStrings().ToArray()));
            var results = sb.ToString();
            if (!string.IsNullOrEmpty(results))
            {
                return results;
            }
            return number.ToString();
		}
	}

}
