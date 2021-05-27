using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Prize prize = new Prize("Golden Goose");
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Console.Write("What's your name traveler? ");
            string aName = Console.ReadLine();
            Console.Write("What colors are you robes? ");
            List<string> robes = new List<string>() { };
            string robeRes = Console.ReadLine();
            while (robeRes.ToLower() != "n")
            {
                robes.Add(robeRes);
                Console.Write("Next color of the robe or 'n' to quit?: ");
                robeRes = Console.ReadLine();
            }
            Console.Write("How long in inches is your robe? ");
            int Length = 0;
            while (!int.TryParse(Console.ReadLine(), out Length))
            {
                Console.Write("I need a whole number!");
            }
            Robe ColorFulRobe = new Robe();
            ColorFulRobe.Length = Length;
            ColorFulRobe.Colors = robes;
            Hat hat = new Hat();
            hat.ShininessLevel = 20;
            Adventurer theAdventurer = new Adventurer(aName, ColorFulRobe, hat);
            bool endGame = false;
            theAdventurer.getDescription();
            List<Challenge> theQuest = new List<Challenge>(){
                new Challenge("2 + 2?", 4, 10),
                new Challenge("What's the answer to life, the universe and everything?", 42, 25),
                new Challenge(
                "What is the current second?", DateTime.Now.Second, 50),
                new Challenge("What number am I thinking of?", new Random().Next() % 10, 25),
                new Challenge(
                @"Who's your favorite Beatle?
                1) John
                2) Paul
                3) George
                4) Ringo", 4, 20),
            new Challenge("What's the first prime number?", 2, 23),
            new Challenge("How many planets are in the Sol system?",9,1000),
            new Challenge(@"What can you put in a box to make it lighter?
            1) Helium
            2) Elevator
            3) Hole
            4) Dilitium Crystals",3,50),
            new Challenge("When you evaluate the integral x^2 from 0 to 3 what number do you get?",27,44)
            };
            while (!endGame)
            {
                theAdventurer.Awesomeness += 10 * theAdventurer.correctNum;
                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                // theQuest.AddRange(Enumerable.Range(1, 48)
                //                                .OrderBy(i => rand.Next())
                //                                .Take(6))
                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = Challenge.GetRadomQuestions(theQuest);

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in challenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                prize.ShowPrize(theAdventurer);
                Console.Write("Want to play again (y/n)? ");
                string resposne = "";
                resposne = Console.ReadLine();
                while (resposne.ToLower() != "y" && resposne.ToLower() != "n")
                {
                    Console.Write("I really need only a y or n!: ");
                    resposne = Console.ReadLine();
                }

                endGame = resposne == "n" ? true : false;
            }
            Console.WriteLine("enfriga");
        }
    }
}