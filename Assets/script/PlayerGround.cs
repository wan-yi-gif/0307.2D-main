using UnityEngine;
using Wanyi;

namespace Wanyi
{

    public class PlayerGround : State
    {
        public PlayerGround(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            if (player.IsGround() && Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SwitchState(player.playerJump);
            }

            // 如果按下左鍵，切換到 攻擊狀態
            if (Input.GetKeyDown(KeyCode.Mouse0))
                stateMachine.SwitchState(player.playerAttack);
        }

        public override void Exit()
        {
            base.Exit();
        }

    }

}
