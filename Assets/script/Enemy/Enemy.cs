using UnityEngine;

namespace Wanyi

{

    public class Enemy : MonoBehaviour
    {
        private StateMachine stateMachine;

        public EnemyIdle enemyIdle {  get; private set; }
        public EnemyTravel enemyTravel { get; private set; }
        public EnemyTrack enemyTrack { get; private set; }
        public EnemyAttack enemyAttack { get; private set; }
        public EnemyDead enemyDead { get; private set; }

        private void Awake()
        {
            stateMachine = new StateMachine();

            enemyIdle = new EnemyIdle(this,stateMachine, "敵人待機");
            enemyTravel = new EnemyTravel(this, stateMachine, "敵人遊走");
            enemyTrack = new EnemyTrack(this, stateMachine, "敵人追蹤");
            enemyAttack = new EnemyAttack(this, stateMachine, "敵人攻擊");
            enemyDead = new EnemyDead(this, stateMachine, "敵人死亡");

            stateMachine.Initialize(enemyIdle);
        }
    }

}
