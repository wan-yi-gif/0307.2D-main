using UnityEngine;
using Wanyi;

public class PlayerGround : State
{
    public PlayerGround(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if(player.IsGround() && Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    public override void Exit()
    {
        base.Exit();
    }

   
}
