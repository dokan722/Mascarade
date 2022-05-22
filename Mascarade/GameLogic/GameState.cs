namespace Mascarade.GameLogic
{
    public class GameState
    {
        enum State
        {
            WAITING_FOR_LEADER,
            WAITING_FOR_PLAYERS,
            IN_GAME
        }

        Dictionary<int, Role> _roles;
        int[] _playersMoney;
        int _bank;
        State _actualState;

    }
}
