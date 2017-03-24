namespace ProviderQuality.Console.Awards
{
    public abstract class Award
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expiresIn"></param>
        /// <param name="quality"></param>
        protected Award(int expiresIn, int quality)
        {
            ExpiresIn = expiresIn;
            Quality = quality;
        }

        /// <summary>
        /// Updates the Quanity And Expires values for a day
        /// </summary>
        public void UpdateAward()
        {
            ProcessDailyQuality();
            ProcessDailyExpiresIn();
        }

        /// <summary>
        /// # Of Days before a awars expires
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Quality value of the award
        /// </summary>
        public int Quality { get; set; }

        /// <summary>
        /// Calculates the daily quality change rate
        /// </summary>
        public virtual void ProcessDailyQuality()
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
                    Quality = Quality - 2;
                }
            }
            else
            {
                Quality--;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }

        /// <summary>
        /// Calculates the daily expires in change rate
        /// </summary>
        public virtual void ProcessDailyExpiresIn()
        {
            if (Expired) return;

            ExpiresIn--;

        }

        /// <summary>
        /// Is the Award expired?
        /// </summary>
        public bool Expired => ExpiresIn == 0;

    }
}
