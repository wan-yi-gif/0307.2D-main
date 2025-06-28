using UnityEngine;
using Wanyi;

public class EnemyTrack
{
    private Enemy enemy;
    private StateMachine stateMachine;
    private string v;

    public EnemyTrack(Enemy enemy, StateMachine stateMachine, string v)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.v = v;
    }
}
