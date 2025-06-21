using UnityEngine;

namespace Wanyi
{
    /// <summary>
    /// 玩家走路
    /// </summary>
    public class PlayerJump : State
    {
        public PlayerJump(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public virtual void Exit()
        {
            base.Exit();
        }
        public virtual void Update()
        {
            base.Update();
        }
    }
}

