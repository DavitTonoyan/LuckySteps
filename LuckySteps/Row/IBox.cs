using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Row
{
    interface IBox
    {
        double FirstBoxMoney { get; set; }
        double SecondBoxMoney { get; set; }
        void Passed();
    }
}
