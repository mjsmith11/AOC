using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: "+ part1());
            // for part 2, use the additional input from part 1 to manually
            // apply process of elimination and alphabetize them.
        }

        static int part1() {
            string[] input = getInput();
            string regex = @"^(?<ingredients>([a-z]+ )+)\(contains (?<allergens>.+)\)$";
            Dictionary<string,List<string>> allergenChart = new Dictionary<string,List<string>>();
            foreach(string s in input) {
                Match m = Regex.Match(s.Trim(), regex);
                string allergens = m.Groups["allergens"].Value;
                string ingredients = " " + m.Groups["ingredients"].Value;
                string[] allergenSplits = allergens.Split(", ");
                foreach (String a in allergenSplits) {
                    if (!allergenChart.ContainsKey(a)) {
                        allergenChart[a] = new List<string>();
                    }
                    allergenChart[a].Add(ingredients);
                }
            }

            List<string> dangerousIngredients = new List<string>();
            foreach(KeyValuePair<string,List<string>> entry in allergenChart)
            {
                List<string> potentialAllergens = new List<string>();
                // take everything in the first ingredient list to prime the loop
                string[] splitIngreedients = entry.Value[0].Split(" ");
                foreach(string i in splitIngreedients) {
                    if (i != "") { potentialAllergens.Add(i); }
                }

                //now intersect potentialAllergens with the remaining lists
                for(int i=1; i<entry.Value.Count; i++) {
                    List<string> thisLineIngreedients = new List<string>();
                    splitIngreedients = entry.Value[i].Split(" ");
                    foreach(string ing in splitIngreedients) {
                        if (ing != "") { thisLineIngreedients.Add(ing); }
                    }
                    potentialAllergens = potentialAllergens.Intersect(thisLineIngreedients).ToList();
                }
                Console.WriteLine(entry.Key);
                foreach(string allergen in potentialAllergens) {
                    Console.WriteLine("    " + allergen);
                }
                dangerousIngredients = dangerousIngredients.Union(potentialAllergens).ToList();
            }

            // now count the uses of stuff that's not dangerous
            int count = 0;
            foreach(string s in input) {
                Match m = Regex.Match(s.Trim(), regex);
                string ingredients = " " + m.Groups["ingredients"].Value;
                string[] splitIngreedients = ingredients.Split(" ");
                foreach(string i in splitIngreedients) {
                    if (i != "") { 
                        if(!dangerousIngredients.Contains(i)) {
                            count++;
                        } 
                    }
                }
            }

            return count;
        }

        static string[] getInput() {
            string input = System.IO.File.ReadAllText(@"input.txt");
            return input.Split('\n');
        }
    }
}
