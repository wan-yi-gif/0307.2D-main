using UnityEngine;
using Wanyi;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
        name = _name;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.ani.SetTrigger("觸發攻擊");
        enemy.ani.SetFloat("移動數值", 0);
        enemy.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer >= enemy.attackTime) stateMachine.SwitchState(enemy.enemyTrack);
    }
}
