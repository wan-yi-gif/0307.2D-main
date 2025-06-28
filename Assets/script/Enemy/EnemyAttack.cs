using UnityEngine;
using Wanyi;

public class EnemyAttack
{
    private Enemy enemy;
    private StateMachine stateMachine;
    private string v;

    public EnemyAttack(Enemy enemy, StateMachine stateMachine, string v)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.v = v;
    }
}
