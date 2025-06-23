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
        
        public virtual void Exit()
        {
            base.Exit();
        }
        public virtual void Update()
        {
            base.Update();

            float h = Input.GetAxis("Horizontal");
            // Unity API (Unity 倉庫，遊戲功能)
            // 剛體的加速度 = 二維向量
            // Horizontal 左、A ， 右、D
            // 左：-1
            // 右：+1
            // 沒按：0
            player.rig.linearVelocity = new Vector2(player.moveSpeed * h, player.rig.linearVelocityY);

            player.ani.SetFloat("移動數值", Mathf.Abs(h));

            player.Flip(h);

            if (h == 0) stateMachine.SwitchState(player.playerIdle);
        }

    }

}
