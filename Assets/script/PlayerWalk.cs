using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Wanyi
{
    /// <summary>
    /// 玩家走路
    /// </summary>
    public class PlayerWalk : PlayerGround
    {
        public PlayerWalk(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            float h = Input.GetAxis("Horizontal");

            // 修正：使用 Unity 正確的剛體 velocity 屬性
            player.rig.linearVelocity = new Vector2(player.moveSpeed * h, player.rig.linearVelocity.y);

            player.ani.SetFloat("移動數值", Mathf.Abs(h));

            player.Flip(h);

            if (Mathf.Abs(h) < 0.01f)
            {
                stateMachine.SwitchState(player.playerIdle);
            }
        }
    }
}

