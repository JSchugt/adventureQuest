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
            while (!endGame)
            {

                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4, 20
                );

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle
            };

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