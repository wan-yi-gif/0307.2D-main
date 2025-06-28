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
            name = _name;
        }

    }
}

