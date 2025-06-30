using UnityEngine;

namespace Wanyi

{
    public class EnemyState : State
    {

        protected Enemy enemy;
        public EnemyState(Enemy _enemy, StateMachine _stateMachine, string _name)
     : base(_stateMachine, _name)
        {
            enemy = _enemy;
            stateMachine = _stateMachine;
        }
        public override void Enter()
        {
            base.Enter();
            Debug.Log($"<color=#ff3>進入 <{name}> 狀態</color>");
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

