using Microsoft.AspNetCore.SignalR;

namespace Mascarade.GameLogic
{
    public class Role
    {
        GameState _state;
        public string Name;

        public int getTargetsCount()
        { 
        }

        public Role(GameState state)
        {
            _state = state;
        }
        public virtual void usePower(int playerId) { }
    }

    public class RoleSpy : Role
    {
        public RoleSpy(GameState state) : base(state)
        {
            Name = "Szpieg";
        }

        public override void usePower(int playerId) { }
    }

    public class RoleBishop : Role
    {
        public RoleBishop(GameState state) : base(state)
        {
            Name = "Biskup";
        }

        public override void usePower(int playerId) { }
    }

}
