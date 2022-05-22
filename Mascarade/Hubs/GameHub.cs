using Microsoft.AspNetCore.SignalR;


class RPS
{
    public enum Move { NONE, ROCK, PAPER, SCISSORS };
    int round_number;
    int[] tally = new int[2];
    Move[] selected_moves = new Move[2];
    List<string>[] updates = new List<string>[2] { new List<string>(), new List<string>() };

    void make_move(int p, Move m)
    {
        if (selected_moves[p] != Move.NONE)
        {
            throw new Exception("moved twice");
        }
        selected_moves[p] = m;
        updates[p ^ 1].Append($"{{\"op\": \"HURRY\"}}");
        if (selected_moves[p ^ 1] != Move.NONE)
        {
            tally[p ^ 1]++;
            var update = $"{{\"op\": \"SCORE\", \"player1\": {tally[0]}, \"player2\": {tally[1]}}}";
            updates[0].Append(update);
            updates[1].Append(update);
        }
    }

    List<string> get_updates(int p)
    {
        var xd = updates[p];
        updates[p] = new List<string>();
        return xd;
    }
}


namespace Mascarade.Hubs
{
    public class GameHub : Hub
    {
        static int test = 0;
        public async Task SendMessage(string user, string message)
        {
            test++;
            await Clients.All.SendAsync("ReceiveMessage", user + $"({Context.ConnectionId})", $" numer {test}: " + message);
        }
    }
}