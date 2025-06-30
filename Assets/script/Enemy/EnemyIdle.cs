using UnityEngine;
using Wanyi;

public class EnemyIdle : EnemyState
{
    private float idleTime;


    public EnemyIdle(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ani.SetFloat("移動數值", 0);
        enemy.SetVelocity(0, 0);

        idleTime = Random.Range(enemy.idleTimeRange.x, enemy.idleTimeRange.y);
        // Debug.Log($"隨機待機時間 : {idleTime}");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer >= idleTime) stateMachine.SwitchState(enemy.enemyTravel);
    }
}
