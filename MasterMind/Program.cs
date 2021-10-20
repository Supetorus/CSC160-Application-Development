using System;
using System.Collections.Generic;
using MasterMindLibrary;
using ConsoleLibrary;


namespace MasterMind
{
    class Program
    {
        static List<Peg> pegList = new List<Peg>()
        {
            new Peg(ConsoleColor.White, ConsoleColor.Red),
            new Peg(ConsoleColor.White, ConsoleColor.Blue),
            new Peg(ConsoleColor.Black, ConsoleColor.Green),
            new Peg(ConsoleColor.Black, ConsoleColor.Yellow),
            new Peg(ConsoleColor.Black, ConsoleColor.Cyan),
            new Peg(ConsoleColor.White, ConsoleColor.Magenta),
            new Peg(ConsoleColor.White, ConsoleColor.DarkGray),
            new Peg(ConsoleColor.White, ConsoleColor.DarkRed)
        };

        static void Main(string[] args)
        {
            List<Attempt> allAttempts = new List<Attempt>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Mastermind!");
            Console.ResetColor();

            //ask for difficulty
            IO.textColor = ConsoleColor.Yellow;
            int choice = IO.GetConsoleMenu(new string[] { "Easy - 4 Pegs", "Medium - 6 Pegs", "Hard - 8 Pegs" }) - 1;

            //ask for maxTurns of turns to guess it
            int maxTurns = IO.GetConsoleInt("How many turns are allowed? ", 0);

            //store the maxPegs based on difficulty
            int maxPegs = 4 + choice * 2;

            //Generate an answer
            List<int> answer = MMLib.GenerateAnswer(maxPegs);

            //show cheat? 
            //MMLib.Cheat(answer, pegList);

            //loop while !gameWon && maxTurns != 0
            bool gameWon = false;
            while (!gameWon && maxTurns > 0)
            {
                Console.Clear();
                //  get user attempt
                Attempt attempt = GetAttemptFromUser(maxPegs, allAttempts, maxTurns);
                //  Check the attempt for a correct guess
                CheckAttempt(attempt, answer);
                //  add the attempt to the attempt list
                allAttempts.Add(attempt);
                //  determine if the game has been won or not
                if (attempt.CorrectAnswerCount == maxPegs) gameWon = true;
                //  reduce the maxTurns
                maxTurns--;
            }

            //If won, display Game Won!
            if (gameWon)
            {
                IO.textColor = ConsoleColor.Cyan;
                IO.println("Game Won!");
            }
            //If lost, show game loss
            else
            {
                IO.textColor = ConsoleColor.DarkRed;
                IO.println("Game Lost.");
            }
            //show the correct answer
            MMLib.ShowAnswer(answer, pegList, "o");
        }

        static Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts, int maxTurns)
        {
            //Create a new Attempt
            Attempt attempt = new Attempt();
            //Get color options based on maxPegs
            //Loop of # of pegs they need to choose
            for (int i = 0; i < maxPegs; i++)
            {
                //      clear console
                Console.Clear();
                //      Display # of attempts left
                IO.println($"You have {maxTurns} attempts remaining.");
                //      Show all previous attempts
                MMLib.ShowAttempts(allAttempts, pegList, "o");
                //      Show pegs they have chosen already in this attempt
                MMLib.ShowChosenPegs(attempt, pegList);
                //      Ask them to pick a peg color from a menu of options
                //int chosenPeg = MMLib.GetConsoleMenu(MMLib.GetColorOptions(maxPegs, pegList));
                int chosenPeg = IO.GetConsoleMenu(MMLib.GetColorOptions(maxPegs, pegList));
                //      Add the chosen peg to the Attempt.AttemptList
                attempt.AttemptList.Add(chosenPeg-1);
            }
            //Return the attempt when done
            return attempt;
        }

        static void CheckAttempt(Attempt attempt, List<int> answer)
        {
            for (int i = 0; i < attempt.AttemptList.Count; i++)
            {
                if (attempt.AttemptList[i] == answer[i]) attempt.CorrectAnswerCount++;
            }
            //Check the attempt.AttemptList to see if they got a match to the answer
            //If a peg is correct, increment the attempt.CorrectAnswerCount
        }
    }
}
