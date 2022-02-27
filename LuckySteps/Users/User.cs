using Newtonsoft.Json;

namespace LuckySteps.Users
{
    class User :IUser
    {
        [JsonProperty]
        private bool blocked;
        [JsonProperty]
        private DateTime blockedDate;

        public string UserName { get; set; }
        public double Money { get; set; }


        public void BlockUser()
        {
            blocked = true;
            blockedDate = DateTime.Now;
        }
        public void TryToUnblock()
        {
            long hour = 23 * TimeSpan.TicksPerHour;
            long minute = 59 * TimeSpan.TicksPerMinute;
            long second = 59 * TimeSpan.TicksPerSecond;

            TimeSpan ts = new TimeSpan(hour + minute + second);

            if (DateTime.Now - blockedDate > ts)
            {
                blocked = false;
            }
        }

        public User(string userName)
        {
            UserName = userName;
            Money = 0;
        }

        public override string ToString()
        {
            return $" Name: {UserName}  Money:  {Money}";
        }
    }
}
