namespace Tic_tac_toe
{
    public class CrossesAndZeros
    {
        /// Conditionals of game:
        /// 1. Crosses signify X and zeros signify O
        /// 2. Desk size is 3x3 and cells numerate from 0 to 8
        /// 3. First step is done by crosses (X)

        //Example declaration:
        //  X   O   X
        //  X   #   O
        //  #   #   O

        public double Step { get; private set; } = 1;
        public readonly string FirstPlayer;
        public readonly string SecondPlayer;
        private char[] _desk = new char[9]; //0 1 2 3 ...

        public CrossesAndZeros(string firstPlayer, string secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
        public void StartGame()
        {
            bool firstPlayerWins = false;
            bool secondPlayerWins = false;
            while (Step < 10)
            {
                if (Step % 2 == 1)
                {
                    int place;
                    do
                    {
                        Console.Write($"Write place for X, {FirstPlayer}: ");
                        place = int.Parse(Console.ReadLine());
                    }
                    while (_desk[place] != '\0');
                    _desk[place] = 'X';
                    Console.WriteLine();
                    ShowDesk();
                    Step++;
                }
                else if (Step % 2 == 0)

                {
                    int place;
                    do
                    {
                        Console.Write($"Write place for O, {SecondPlayer}: ");
                        place = int.Parse(Console.ReadLine());
                    }
                    while (_desk[place] != '\0');
                    _desk[place] = 'O';
                    Console.WriteLine();
                    ShowDesk();
                    Step++;
                }
                else
                {
                    throw new ArgumentException("Broken number steps");
                }
                //Win combination checker:
                if (Step > 4)
                {
                    for (int y = 0; y < Math.Sqrt(_desk.Length); y++)
                    {
                        int temp = 0 + (int)Math.Sqrt(_desk.Length) * y;
                        if (_desk[temp] == 'X' && _desk[temp + 1] == 'X' && _desk[temp + 2] == 'X'
                            || _desk[y] == 'X' && _desk[y + (int)Math.Sqrt(_desk.Length)] == 'X' && _desk[y + (int)Math.Sqrt(_desk.Length) * 2] == 'X'
                            || _desk[y] == 'X' && _desk[4] == 'X' && _desk[4 - y + 4] == 'X')
                        {
                            firstPlayerWins = true;
                            Console.WriteLine($"{FirstPlayer} won");
                            break;
                        }
                        else if (_desk[temp] == 'O' && _desk[temp + 1] == 'O' && _desk[temp + 2] == 'O'
                            || _desk[y] == 'O' && _desk[y + (int)Math.Sqrt(_desk.Length)] == 'O' && _desk[y + (int)Math.Sqrt(_desk.Length) * 2] == 'O'
                            || _desk[y] == 'O' && _desk[4] == 'O' && _desk[4 - y + 4] == 'O')
                        {
                            secondPlayerWins = true;
                            Console.WriteLine($"{SecondPlayer} won");
                            break;
                        }
                    }

                    if (firstPlayerWins || secondPlayerWins)
                    {
                        break;
                    }
                    else
                    {
                    }
                }
            }
        }
        private void ShowDesk()
        {
            for (int y = 0; y < Math.Sqrt(_desk.Length); y++)
            {
                for (int x = 0; x < Math.Sqrt(_desk.Length); x++)
                {
                    if (_desk[x + (int)Math.Sqrt(_desk.Length) * y] == '\0')
                    {
                        Console.Write(x + (int)Math.Sqrt(_desk.Length) * y + "\t");
                    }
                    else
                    {
                        Console.Write(_desk[x + (int)Math.Sqrt(_desk.Length) * y] + "\t");
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
