namespace ProviderQuality.Console.Awards
{
    public class BlueCompare : Award
    {
        public BlueCompare(int expiresIn, int quality) : base(expiresIn, quality)
        {
        }

        public override void ProcessDailyQuality()
        {
            if (Expired)
            {
                Quality = 0;
                return;
            }
                 
            if (Quality == 50) return;

            if (ExpiresIn > 10)
            {
                Quality++;
            }

            if (ExpiresIn <= 10 && ExpiresIn > 5)
            {
                Quality = Quality + 2;
            }

            if (ExpiresIn <= 5)
            {
                Quality = Quality + 3;
            }
            
            if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}
