using System;
namespace Quest
{
    public class Prize
    {
        private string _text = "Golden Goose";
        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer someone)
        {
            for (int i = 0; i < someone.Awesomeness; i++)
            {
                Console.WriteLine(_text);
            }
            if (someone.Awesomeness < 0)
            {
                Console.WriteLine("Are you even allowed out of the house?");
            }
        }
    }
}