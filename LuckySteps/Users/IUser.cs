namespace LuckySteps.Users
{
    interface IUser
    {
        string UserName { get; set; }
        double Money { get; set; }
        void BlockUser();
    }
}
