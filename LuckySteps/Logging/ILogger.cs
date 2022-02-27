using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Logging
{
    interface ILogger
    {
        void Error(string error);
        void Information(string info);
        void Warning(string warning);
    }
}
