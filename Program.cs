namespace Tic_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrossesAndZeros cz = new CrossesAndZeros("Player 1", "Player 2");
            cz.StartGame();
            Console.ReadKey();
        }
    }
}