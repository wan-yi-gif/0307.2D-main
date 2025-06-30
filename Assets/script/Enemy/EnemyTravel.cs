using UnityEngine;

namespace Wanyi

{
    public class EnemyTravel : EnemyState
    {

        private float travelTime;
        public EnemyTravel(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            travelTime = Random.Range(enemy.travelTimeRange.x, enemy.travelTimeRange.y);
            enemy.ani.SetFloat("移動數值", 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            enemy.SetVelocity(enemy.transform.right * enemy.travelSpeed);

            if (timer >= travelTime) stateMachine.SwitchState(enemy.enemyIdle);

            if (enemy.IsWallInFront() || !enemy.IsGroundInFront())
                enemy.Flip(enemy.transform.eulerAngles.y == 0 ? -1 : +1);

            if (enemy.IsWallInFront() || !enemy.IsGroundInFront()) return;

            if(enemy.IsPlayerInFront()) stateMachine.SwitchState(enemy.enemyTrack);
        }
    }
}


