namespace ProviderQuality.Console.Awards
{
    public class BlueStar : Award
    {
        public BlueStar(int expiresIn, int quality) : base(expiresIn, quality)
        {
        }

        public override void ProcessDailyQuality()
        {
            if (Quality == 0) return;

            if (Quality > 50)
            {
                Quality = 50;
            }

            if (Expired)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 4;
                }
            }
            else
            {
                Quality = Quality - 2;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }
    }
}
