using UnityEngine;
using Wanyi;

public class EnemyIdle
{
    private Enemy enemy;
    private StateMachine stateMachine;
    private string v;

    public EnemyIdle(Enemy enemy, StateMachine stateMachine, string v)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.v = v;
    }
}
