using UnityEngine;
using Wanyi;

namespace Wanyi
{
    public class PlayerAttack : State
    {

        private int attackIndex;
        private int attackMax = 3;
        private float attackFinishTime;
        public PlayerAttack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if(Time.time > attackFinishTime + player.attackBreakTime) 
                attackIndex = 0;

            attackIndex++;
            if (attackIndex > attackMax) attackIndex = 1;
            player.ani.SetFloat("攻擊連段", attackIndex);

            player.ani.SetTrigger("觸發攻擊");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log($"<color=f99>離開攻擊的時間 : {Time.time}</color>");
            attackFinishTime = Time.time;
        }

        public override void Update()
        {
            base.Update();
            // Debug.Log($"<color=#f96>計時器 : {timer}</color>");

            if(timer > 1) stateMachine.SwitchState(player.playerIdle);
        }
    }

}

