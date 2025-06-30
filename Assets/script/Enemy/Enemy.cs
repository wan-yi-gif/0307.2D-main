using System;
using UnityEngine;

namespace Wanyi

{

    public class Enemy : Character
    {

        #region 資料
        [field: SerializeField, Header("敵人資料"), Tooltip("敵人待機的時間範圍")]
        public Vector2 idleTimeRange { get; private set; } = new Vector2(1, 3);

        [field: SerializeField, Tooltip("敵人待機的時間範圍")]
        public Vector2 travelTimeRange { get; private set; } = new Vector2(3, 7);

        [field: SerializeField, Range(0, 3), Tooltip("敵人遊走的速度")]
        public float travelSpeed = 1.5f;

        [field: SerializeField, Range(0, 5), Tooltip("敵人追蹤的速度")]
        public float trackSpeed = 2.5f;

        [field: SerializeField, Range(0, 6), Tooltip("敵人進入攻擊的距離")]
        public float attackDistance = 2.5f;

        [field: SerializeField, Range(0, 3), Tooltip("敵人攻擊時間")]
        public float attackTime = -1;




        [Header("檢查前方是否有地板與牆壁")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;

        [SerializeField]
        private Vector3 checkGroundOffset;

        [SerializeField]
        private LayerMask layerGround;

        [SerializeField]
        private Vector3 checkWallSize = Vector3.one;

        [SerializeField]
        private Vector3 checkWallOffset;

        [SerializeField]
        private LayerMask layerWall; 
        #endregion


        private StateMachine stateMachine;

        public EnemyIdle enemyIdle { get; private set; }
        public EnemyTravel enemyTravel { get; private set; }
        public EnemyTrack enemyTrack { get; private set; }
        public EnemyAttack enemyAttack { get; private set; }
        public EnemyDead enemyDead { get; private set; }


        [Header("檢查玩家區域")]
        [SerializeField]
        private Vector3 checkPlyerSize = Vector3.one;
        [SerializeField]
        private Vector3 checkPlyerOffset;
        [SerializeField]
        private LayerMask layerPlyer;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0.5f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundSize);

            Gizmos.color = new Color(1, 1, 0.5f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkWallOffset), checkWallSize);

            Gizmos.color = new Color(0.3f, 0.2f, 1f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkPlyerOffset), checkPlyerSize);
        }

        public Transform traPlayer {  get; private set; }

        protected override void Awake()
        {

            base.Awake();

            traPlayer = GameObject.Find("騎士").transform;
       
            stateMachine = new StateMachine();

            enemyIdle = new EnemyIdle(this, stateMachine, "敵人待機");
            enemyTravel = new EnemyTravel(this, stateMachine, "敵人遊走");
            enemyTrack = new EnemyTrack(this, stateMachine, "敵人追蹤");
            enemyAttack = new EnemyAttack(this, stateMachine, "敵人攻擊");
            enemyDead = new EnemyDead(this, stateMachine, "敵人死亡");

            stateMachine.Initialize(enemyIdle);
        }

        private void Update()
        {
            stateMachine.UpdateState();

            Debug.Log($"<color=#f33>是否有玩家 : {IsPlayerInFront()}</color>");
        }

        public bool IsGroundInFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundSize, 0, layerGround);
        }

        public bool IsWallInFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkWallOffset), checkWallSize, 0, layerWall);
        }

        public bool IsPlayerInFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkPlyerOffset), checkPlyerSize, 0, layerPlyer);
        }

        protected override void Damge(float damage)
        {
            base.Damge(damage);
        
            if (hp <= 0) stateMachine.SwitchState(enemyDead);
            
        }

        private Rigidbody2D rb;
        internal void SetVelocity(Vector3 direction)
        {
            rb.linearVelocity = new Vector2(direction.x, rb.linearVelocity.y);
        }
    }
}

