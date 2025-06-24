using UnityEngine;

    namespace Wanyi
{
    /// <summary>
    /// 玩家走路
    /// </summary>
    public class PlayerFall : State
    {
        public PlayerFall(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetFloat("地心引力", -1);
        }

        public override void Exit()
        {
            base.Exit();
            player.ani.SetBool("開關跳躍", false);
        }
        public override void Update()
        {
            base.Update();
            float h = Input.GetAxis("Horizontal");
            player.rig.linearVelocity = new Vector2(player.moveSpeed * h, player.rig.linearVelocityY);
            player.Flip(h);

            if (player.IsGround()) stateMachine.SwitchState(player.playerIdle);
        }
    }
}
