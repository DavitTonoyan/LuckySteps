using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Row
{
    class Box :IBox
    {
        private static Random _rand;
        private bool isPassed;
        public double FirstBoxMoney { get; set; }
        public double SecondBoxMoney { get; set; }
        


        static Box()
        {
            _rand = new Random();
        }
        public Box()
        {
            FirstBoxMoney = GetRandomMoney();
            SecondBoxMoney = GetRandomMoney();
        }

        public void Passed()
        {
            isPassed = true;
        }

        public override string ToString()
        {
            if(isPassed)
            {
                return $" { FirstBoxMoney}  :  {SecondBoxMoney}";
            }
            return " X  :  X ";
        }

        private double GetRandomMoney()
        {
            int isEmptyBox = _rand.Next(0, 3);
            double money=0;

            if (isEmptyBox == 0)
            {
               return money;
            }
            money = _rand.Next(100, 3000);
            return money;
        }

    }
}
