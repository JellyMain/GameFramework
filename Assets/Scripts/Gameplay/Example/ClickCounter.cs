namespace Gameplay.Example
{
    public class ClickCounter
    {
        public int ClicksCount { get; private set; }


        public void AddClick()
        {
            ClicksCount++;
        }


        public void Reset()
        {
            ClicksCount = 0;
        }
    }
}
