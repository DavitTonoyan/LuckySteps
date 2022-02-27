using LuckySteps.Row;
using LuckySteps.Users;
using System.Text;

namespace LuckySteps.Logic
{
    class GameLogic
    {
        private List<IBox> _boxes = new List<IBox>();
        private int _currentPosition = -1;
        private User _user;

        public GameLogic(User user)
        {
            _user = user;
            InitializeBoxes();
        }

        public string LeftColumn()
        {
            _currentPosition++;

            if (_boxes[_currentPosition].FirstBoxMoney == 0)
            {
                throw new Exception(" there are not money on left collumn you loose the game ");
            }
            _user.Money += _boxes[_currentPosition].FirstBoxMoney;
            return $" u won {_boxes[_currentPosition].FirstBoxMoney} money";
        }

        public string RightColumn()
        {
            _currentPosition++;

            if (_boxes[_currentPosition].SecondBoxMoney == 0)
            {
                throw new Exception(" there are not money on right collumn you loose the game ");
            }
            _user.Money += _boxes[_currentPosition].FirstBoxMoney;
            _boxes[_currentPosition].Passed();
            return $" u won {_boxes[_currentPosition].FirstBoxMoney} money";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = _boxes.Count - 1; i >= 0; i--)
            {
                sb.AppendLine($"{i}: {_boxes[i]}");

            }

            return sb.ToString();
        }
        private void InitializeBoxes()
        {
            for (int countBoxes = 0; countBoxes < 10; countBoxes++)
            {
                _boxes.Add(new Box());
            }
        }


    }
}
