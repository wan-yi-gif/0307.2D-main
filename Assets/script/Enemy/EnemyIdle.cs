using UnityEngine;
using Wanyi;

public class EnemyIdle : EnemyState
{
    private float idleTime;

    protected Enemy enemy;
    protected StateMachine stateMachine;
    public EnemyIdle(Enemy _enemy, StateMachine _stateMachine, string _name)
        : base(_enemy, _stateMachine, _name)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ani.SetFloat("移動數值", 0);
        enemy.SetVelocity(Vector3.zero);

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

        if(enemy.IsWallInFront () || !enemy.IsGroundInFront()) return;

        if (enemy.IsPlayerInFront()) stateMachine.SwitchState(enemy.enemyTrack);
    }


}
