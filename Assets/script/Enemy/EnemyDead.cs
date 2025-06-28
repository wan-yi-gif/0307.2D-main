using UnityEngine;
using Wanyi;

public class EnemyDead
{
    private Enemy enemy;
    private StateMachine stateMachine;
    private string v;

    public EnemyDead(Enemy enemy, StateMachine stateMachine, string v)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.v = v;
    }
}
