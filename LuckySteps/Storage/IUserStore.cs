using LuckySteps.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Storage
{
    interface IUserStore
    {
        void Save(Dictionary<string, User> users);
        Dictionary<string, User> Read();
    }
}
