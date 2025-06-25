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

            player.ani.SetBool("開關跳躍", true);
            player.ani.SetFloat("地心引力", 1);

            player.rig.linearVelocity = new Vector2(player.rig.linearVelocityX, player.jump);
        }

        public override void Exit()
        {
            base.Exit();
        }
        public override void Update()
        {
            base.Update();

            float h = Input.GetAxis("Horizontal");
            player.rig.linearVelocity = new Vector2(player.moveSpeed * h, player.rig.linearVelocityY);
            player.Flip(h);
            
            if (player.rig.linearVelocityY < 0) stateMachine.SwitchState(player.playerFall);
        }
    }
}

