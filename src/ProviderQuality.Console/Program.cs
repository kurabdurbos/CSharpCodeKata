using System.Collections.Generic;
using ProviderQuality.Console.Awards;

namespace ProviderQuality.Console
{
    public class Program
    {
        public IList<Award> Awards;

        private static void Main()
        {
            System.Console.WriteLine("Updating award metrics...!");

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new GovQualityPlus(10,20),
                    new BlueFirst(2,0),
                    new AcmePartnerFacility(5, 7),
                    new BlueDistinctionPlus(0,80),
                    new BlueCompare(15,20),
                    new TopConnectedProviders(3,6),
                    new BlueStar(10,10)
                }
            };

            app.UpdateAwards();

            foreach (var appAward in app.Awards)
            {
                System.Console.WriteLine("{0,0}{1,15}{2,20}", $"Award: {string.Format(appAward.GetType().ToString()).Substring(31)}\n", $"ExpiresIn: {appAward.ExpiresIn}" , $"Quality: {appAward.Quality}" );
            }

            System.Console.ReadKey();
        }


        public void UpdateAwards()
        {
            foreach (var award in Awards)
            {
                award.UpdateAward();
            }
        }
    }

}
