using LuckySteps.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Storage
{
    internal class UserStore:IUserStore
    {
        private const string Path = "users.txt";
        private JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
      
        public UserStore()
        {
            if( !File.Exists(Path))
            {
                File.Create(Path).Close();
            }
        }
        
        public void Save(Dictionary<string, User> users)
        {
            string json = JsonConvert.SerializeObject(users, jsonSerializerSettings);
            File.AppendAllText(Path, json);
        }
        public Dictionary<string, User> Read()
        {
            string json = File.ReadAllText(Path);
            
            
            var users = JsonConvert.DeserializeObject<Dictionary<string, User>>(json, jsonSerializerSettings);
            return users;
        }
    }
}
