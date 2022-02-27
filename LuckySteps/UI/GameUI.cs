using LuckySteps.Logic;
using LuckySteps.Logging;
using LuckySteps.Users;

namespace LuckySteps.UI
{
    class GameUI
    {
        private ILogger _logger = Logger.CreateInstance();

        private Game _game = new Game();
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add new account \n2. sign in account \n press any key to exit");


                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        AddAccount();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:

                        GetAccount();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
            }
        }


        private void GameStart(User user)
        {
            GameLogic logic = new GameLogic(user);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(logic);


                Console.WriteLine("1.Up left \n2.Up right \nEsc to take money  and log out ");


                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        string message = logic.LeftColumn();
                        _logger.Information(message);
                        Console.WriteLine(message);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:

                        string m = logic.RightColumn();
                        _logger.Information(m);
                        Console.WriteLine(m);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        return;

                        Console.WriteLine("Press any key to continue ");
                        Console.ReadKey();
                }
            }
        }


        private void AddAccount()
        {
            string username = ReadWithLabel(" ENter Username ");

            try
            {
                User user = new User(username);
                _game.AddUser(username);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }

        }
        private void GetAccount()
        {
            string username = ReadWithLabel("Enter Username: ");
            try
            {
                var user = _game.GetUser(username);
                GameStart(user);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }

        }


        private string ReadWithLabel(string text)
        {
            Console.WriteLine(text);
            string s = Console.ReadLine();

            return s;
        }
    }
}

