using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class PlayerService
{
    private AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Player> GetPlayers()
    {
        var result = _context.Players.OrderBy(x => x.Name);
        return result;
    }

    public void Update(string name, int attempts, int seconds)
    {
        if (attempts < 1 || attempts > 6)
        {
            throw new ArgumentException("attempts not in proper range");
        }
        if (seconds < 0)
        {
            throw new ArgumentException("seconds not in proper range");
        }

        var player = _context.Players.First(x => x.Name.Equals(name));
        
        if (player == null)
        {
            _context.Players.Add(new Player()
            {
                Name = name,
                GameCount = 1,
                AverageAttempts = attempts,
                AverageSecondsPerGame = seconds
            });
        }
        else
        {
            player.AverageSecondsPerGame = (player.AverageSecondsPerGame * player.GameCount + seconds) / (player.GameCount + 1);
            player.AverageAttempts = (player.AverageAttempts * player.GameCount + attempts) / ++player.GameCount;

        }

        _context.SaveChanges();
    }

    public static void Seed(AppDbContext context)
    {
        if (!context.Players.Any())
        {

            context.Players.Add(new Player()
            {
                Name = "Meg",
                GameCount = 5,
                AverageAttempts = 2.2,
                AverageSecondsPerGame = 5
            });

            context.Players.Add(new Player()
            {
                Name = "David",
                GameCount = 8,
                AverageAttempts = 5,
                AverageSecondsPerGame = 60
            });

            context.Players.Add(new Player()
            {
                Name = "Harry",
                GameCount = 10,
                AverageAttempts = 5.2,
                AverageSecondsPerGame = 120
            });

            context.SaveChanges();
        }
    }
}
