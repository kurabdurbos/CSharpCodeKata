
namespace ProviderQuality.Console.Awards
{
    public class BlueDistinctionPlus : Award
    {
        public BlueDistinctionPlus(int expiresIn, int quality) : base(expiresIn, quality)
        {
        }

        public override void ProcessDailyQuality()
        {
            Quality = 80;
        }
    }
}
