using System;
using UnityEngine;

namespace Wanyi
{
    /// <summary>
    /// 玩家腳本：玩家的基本資料與行為
    /// </summary>
    public class Player : MonoBehaviour
    {
        private StateMachine stateMachine;
        // 唯獨屬性 : 允許外部取得但不能修改
        // 設為公開 public 並添加 { get; private set; }
        public PlayerIdle playerIdle { get; private set; }
        public PlayerWalk playerWalk { get; private set; }
        public PlayerJump playerJump { get; private set; }
        public PlayerFall playerFall { get; private set; }
        public PlayerAttack playerAttack { get; private set; }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
        }

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            // 取得此物件身上的2D剛體存放到rig變數
            ani = GetComponent<Animator>();

            stateMachine = new StateMachine();
            playerIdle = new PlayerIdle(this, stateMachine, "玩家待機");
            playerWalk = new PlayerWalk(this, stateMachine, "玩家走路");
            playerJump = new PlayerJump(this, stateMachine, "玩家跳躍");
            playerFall = new PlayerFall(this, stateMachine, "玩家落下");
            playerAttack = new PlayerAttack(this, stateMachine, "玩家攻擊");

            stateMachine.Initialize(playerIdle);
            
        }

        private void Update()
        {
            stateMachine.UpdateState();

        }

        /// <summary>
        /// 翻面
        /// </summary>
        /// <param name="h">玩家的水平值 (移動)</param>
        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        public bool IsGround()
        {
            return Physics2D.OverlapBox(transform.position + checkGroundOffset, checkGroundSize, 0, LayerGround);
        }

        #region 變數
        [Header("基本數值")]

        [field: SerializeField, Range(0, 10)]
        public float moveSpeed { get; private set; } = 3.5f;

        [field: SerializeField, Range(0, 10)]
        public float jump { get; private set; } = 5;

        [field: SerializeField, Range(0, 5)]
        public float attackBreakTime { get; private set; } = 1;

        // [Header("元件")]
        // [SerializeField]
        public Rigidbody2D rig { get; private set; }

        // [SerializeField]
        public Animator ani { get; private set; }
        public int h { get; private set; }

        [Header("檢查地板資料")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;

        [SerializeField]
        private Vector3 checkGroundOffset;

        [SerializeField]
        private LayerMask LayerGround = 1 << 3;
        #endregion
    }
}
