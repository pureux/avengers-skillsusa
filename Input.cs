using System;
using System.Collections.Generic;

namespace AvengersSkillsUSA {
    public struct Input {

        public enum WarMode {
            CivilWar = 1,
            InfinityWar = 2
        }
        public WarMode GetWarMode() {
            Console.WriteLine();
            Console.WriteLine("1 Civil War");
            Console.WriteLine("2 Infinity War");
            return (WarMode)GetIntegerInput("Which war will you fight?", 1, 2, "1");
        }

        public int GetNumberOfBattles() {
            Console.WriteLine();
            return GetIntegerInput("How many battles should the teams fight?", 1, int.MaxValue, "5");
        }

        public int GetNumberOfSelectedCombatants(int maxPossible) {
            Console.WriteLine();
            return GetIntegerInput("How many Avengers per team should fight?", 1, maxPossible, "4");
        }

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

        public string AskAvengerName(List<String> existingAvengers) {
            return GetTextInput("What is their name?", existingAvengers);
        }

        public string AskAvengerTeam() {
            return GetTextInput("What team are they on?");
        }

        public int AskAvengerPowerLevel() {
            return GetIntegerInput("What is their power level? [1-200]", 1, 200, "30");
        }

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

        private bool IsFoundInChoices(string input, List<string> choices) {
            for (int i = 0; i < choices.Count; i++) {
                if (choices[i].ToUpper() == input.ToUpper()) {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidIntegerInRange(string input, int min, int max) {
            int i;
            if (int.TryParse(input, out i)) {
                return i >= min && i <= max;
            }
            return false;
        }
    }
}