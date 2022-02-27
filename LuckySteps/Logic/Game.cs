using LuckySteps.Storage;
using LuckySteps.Users;
using Newtonsoft.Json;

namespace LuckySteps.Logic
{
    class Game
    {
        private IUserStore userStorage = new UserStore();
        [JsonProperty]
        private Dictionary<string, User> users;

        public Game()
        {
            InitializeUsers();
        }


        public User GetUser(string username)
        {
            if (users.ContainsKey(username))
            {
                return users[username];
            }

            throw new InvalidOperationException(" Username does not exist ");
        }

        public void AddUser(string username)
        {
            if (users.ContainsKey(username))
            {
                throw new InvalidOperationException(" the same  username is exist ");
            }

            User user = new User(username);
            users.Add(username, user);

            userStorage.Save(users);
        }



        private void InitializeUsers()
        {
            users = userStorage.Read() ?? new Dictionary<string, User>();
        }
    }
}
