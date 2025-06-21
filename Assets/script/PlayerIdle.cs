using UnityEngine;

namespace Wanyi
{
    /// <summary>
    /// 玩家待機
    /// </summary>
    /// 玩家待機類別 繼承 狀態類別
    /// 建構子也要實作
    public class PlayerIdle : State
    {
        public PlayerIdle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
       
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            float h = Input.GetAxis("Horizontal");

            if (Mathf.Abs(h) > 0) stateMachine.SwitchState(player.playerWalk);
        }
    }

}
