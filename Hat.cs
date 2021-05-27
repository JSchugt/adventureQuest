namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription()
        {
            string level = "";
            if (ShininessLevel < 2)
            {
                level = "dull";
            }
            else if (ShininessLevel <= 5)
            {
                level = "noticeable";
            }
            else if (ShininessLevel <= 9)
            {
                level = "bright";
            }
            else
            {
                level = "blinding";
            }
            return level;
        }
    }
}