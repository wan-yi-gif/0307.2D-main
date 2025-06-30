using UnityEngine;

namespace Wanyi
{
    public class PlayerDead : PlayerState
    {
        public PlayerDead(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetTrigger("觸發死亡");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }

}
