using UnityEngine;
using Wanyi;

public class EnemyTrack : EnemyState
{
    private new Enemy enemy;
    private new StateMachine stateMachine;

    public EnemyTrack(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetVelocity(0, 0);
        enemy.ani.SetFloat("移動數值", 0);
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.transform.right * enemy.trackSpeed);

        float angle = enemy.traPlayer.position.x < enemy.transform.position.x ? -1 : +1;
        enemy.Flip(angle);

        float dis = Vector2.Distance(enemy.transform.position, enemy.traPlayer.position);
        // Debug.Log($"<color=#7f7>距離:{dis}</color>");

        if (dis <= enemy.attackDistance) stateMachine.SwitchState(enemy.enemyAttack);

        if(enemy.IsWallInFront() || !enemy.IsGroundInFront()) 
            stateMachine.SwitchState(enemy.enemyIdle);
    }
}
