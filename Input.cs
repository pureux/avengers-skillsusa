using System;
using System.Collections.Generic;

namespace AvengersSkillsUSA {

    /// <summary>
    /// The input utility for gathering input from the user
    /// </summary>
    public struct Input {

        /// <summary>
        /// An enumeration of wars, to eliminate using magic integers
        /// </summary>
        public enum WarMode {
            CivilWar = 1,
            InfinityWar = 2
        }

        /// <summary>
        /// Ask the user which war mode they want to fight
        /// </summary>
        /// <returns></returns>
        public WarMode GetWarMode() {
            Console.WriteLine();
            Console.WriteLine("1 Civil War");
            Console.WriteLine("2 Infinity War");
            return (WarMode)GetIntegerInput("Which war will you fight?", 1, 2, "1");
        }

        /// <summary>
        /// Ask the user how many battles they want the teams to fight
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfBattles() {
            Console.WriteLine();
            return GetIntegerInput("How many battles should the teams fight?", 1, int.MaxValue, "5");
        }

        /// <summary>
        /// Ask the user how many combatants per team should fight
        /// </summary>
        /// <param name="maxPossible">The maximum possible number of combatants the user can choose</param>
        /// <returns></returns>
        public int GetNumberOfSelectedCombatants(int maxPossible) {
            Console.WriteLine();
            return GetIntegerInput("How many Avengers per team should fight?", 1, maxPossible, "4");
        }

        /// <summary>
        /// Ask the user if they want to add another Avenger
        /// </summary>
        /// <returns></returns>
        public bool AskAddAvenger() {
            const string yes = "yes";
            const string no = "no";

            var choices = new List<String>();
            choices.Add(yes);
            choices.Add(no);

            Console.WriteLine();

            string input = GetChoiceInput("Add another Avenger? [yes/no]", choices);

            return (input.ToUpper() == yes.ToUpper());
        }

        // Ask the user for the new Avenger's name
        public string AskAvengerName(List<String> existingAvengers) {
            return GetTextInput("What is their name?", existingAvengers);
        }

        // Ask the user for the new Avenger's team name
        public string AskAvengerTeam() {
            return GetTextInput("What team are they on?");
        }

        // Ask the user for the new Avenger's power level
        public int AskAvengerPowerLevel() {
            return GetIntegerInput("What is their power level? [1-200]", 1, 200, "30");
        }

        /// <summary>
        /// Get and validate input from the user that must be an integer inside a range
        /// </summary>
        /// <param name="text">The text to prompt the user for the value</param>
        /// <param name="min">The minimum valid value</param>
        /// <param name="max">The maximum valid value</param>
        /// <param name="defaultInput">An optional default value to use if they don't enter anything</param>
        /// <returns></returns>
        private int GetIntegerInput(string text, int min, int max, string defaultInput) {
            Console.WriteLine("{0} [{1}]", text, defaultInput);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) {
                input = defaultInput;
            }

            while (!IsValidIntegerInRange(input, min, max)) {
                Console.WriteLine("You must enter a whole number between {0} and {1}.", min, max);
                input = Console.ReadLine();
            }

            return int.Parse(input);
        }

        /// <summary>
        /// Get and validate input from the user that must be from a collection of choices
        /// </summary>
        /// <param name="text">The text to prompt the user for the value</param>
        /// <param name="choices">The list of valid choices</param>
        /// <returns></returns>
        private string GetChoiceInput(string text, List<string> choices) {
            Console.WriteLine(text);
            string input = Console.ReadLine();

            while (!IsFoundInChoices(input, choices)) {
                Console.Write("You must enter a valid choice. /");
                foreach (var choice in choices) {
                    Console.Write(String.Format(" {0} /", choice));
                }
                Console.Write("\n");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Get and validate input from the user that is generic text
        /// </summary>
        /// <param name="text">The text to prompt the user for the value</param>
        /// <param name="invalidValues">An optional list of invalid values</param>
        /// <returns></returns>
        private string GetTextInput(string text, List<string> invalidValues = null) {
            Console.WriteLine(text);
            string input = Console.ReadLine();

            while (String.IsNullOrEmpty(input) || (invalidValues != null && IsFoundInChoices(input, invalidValues))) {
                Console.Write("You must enter a value.");
                if (invalidValues != null) {
                    Console.Write(" It cannot be any of the following: /");
                    foreach (string value in invalidValues) {
                        Console.Write(String.Format(" {0} /", value));
                    }
                }
                Console.Write("\n");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Determine if a given value exists within a list of choices
        /// </summary>
        /// <param name="input">The value to look for</param>
        /// <param name="choices">The list of choices to look through</param>
        /// <returns></returns>
        private bool IsFoundInChoices(string input, List<string> choices) {
            for (int i = 0; i < choices.Count; i++) {
                if (choices[i].ToUpper() == input.ToUpper()) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determine if a given value is a valid integer within a particular range
        /// </summary>
        /// <param name="input">The value to validate</param>
        /// <param name="min">The minimum valid value of the range</param>
        /// <param name="max">THe maximum valid value of the range</param>
        /// <returns></returns>
        private bool IsValidIntegerInRange(string input, int min, int max) {
            int i;
            if (int.TryParse(input, out i)) {
                return i >= min && i <= max;
            }
            return false;
        }
    }
}