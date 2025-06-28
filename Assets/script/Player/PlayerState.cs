using UnityEngine;
namespace Wanyi
{
    public class PlayerState : State
    {

        protected Player player;
        public PlayerState(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
            player = _player;
            stateMachine = _stateMachine;
            name = _name;
        }

    }

}
