using System;

public class ConsoleApp1
{
    public static void Main(string[] args)
    {
        ComputerGame game = new ComputerGame("Игра", PegiAgeRating.P12, 60, 4096, 50, 8, 4, 3.5);
        PCGame pcGame = new ComputerGameAdapter(game);

        Console.WriteLine($"Название игры: {pcGame.getTitle()}");
        Console.WriteLine($"Возрастное ограничение: {pcGame.getPegiAllowedAge()}");
        Console.WriteLine($"Triple-A: {pcGame.isTripleAGame()}");
        Console.WriteLine($"Требования: {pcGame.getRequirements()}");
    }
    public class ComputerGameAdapter : PCGame
    {
        private ComputerGame computerGame;

        public ComputerGameAdapter(ComputerGame computerGame)
        {
            this.computerGame = computerGame;
        }

        public string getTitle()
        {
            return computerGame.getName();
        }

        public int getPegiAllowedAge()
        {
            switch (computerGame.getPegiAgeRating())
            {
                case PegiAgeRating.P3:
                    return 3;
                case PegiAgeRating.P7:
                    return 7;
                case PegiAgeRating.P12:
                    return 12;
                case PegiAgeRating.P16:
                    return 16;
                case PegiAgeRating.P18:
                    return 18;
                default:
                    return 0;
            }
        }

        public bool isTripleAGame()
        {
            return computerGame.getBudgetInMillionsOfDollars() > 50;
        }

        public Requirements getRequirements()
        {
            return new Requirements(
                computerGame.getMinimumGpuMemoryInMegabytes() / 1024,
                computerGame.getDiskSpaceNeededInGB(),
                computerGame.getRamNeededInGb(),
                computerGame.getCoreSpeedInGhz(),
                computerGame.getCoresNeeded()
            );
        }
    }
}