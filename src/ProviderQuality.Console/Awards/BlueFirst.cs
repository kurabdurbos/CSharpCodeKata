using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console.Awards
{
    public class BlueFirst : Award
    {
        public BlueFirst(int expiresIn, int quality) : base(expiresIn, quality)
        {
        }

        public override void ProcessDailyQuality()
        {
            if (Quality == 50) return;

            if (Expired)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 2;
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality++;
                }
            }

            if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}
