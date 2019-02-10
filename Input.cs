using System;

namespace AvengersSkillsUSA {
    public struct Input {

        public enum WarMode {
            CivilWar = 1,
            InfinityWar = 2
        }
        public WarMode GetWarMode() {
            Console.WriteLine("1 Civil War");
            Console.WriteLine("2 Infinity War");
            return (WarMode)GetIntegerInput("Which war will you fight?", 1, 2, "1");
        }

        public int GetNumberOfBattles() {
            return GetIntegerInput("How many battles should the teams fight?", 1, int.MaxValue, "5");
        }

        public int GetNumberOfSelectedCombatants(int maxPossible) {
            return GetIntegerInput("How many Avengers per team should fight?", 1, maxPossible, "4");
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

        private bool IsValidIntegerInRange(string input, int min, int max) {
            int i;
            if (int.TryParse(input, out i)) {
                return i >= min && i <= max;
            }
            return false;
        }
    }
}