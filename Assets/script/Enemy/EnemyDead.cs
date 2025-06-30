using UnityEngine;
using Wanyi;

public class EnemyDead : EnemyState
{
    private Enemy enemy;
    private StateMachine stateMachine;
    private string v;

    public EnemyDead(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.ani.SetTrigger("觸發死亡");
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
