using UnityEngine;

namespace Wanyi

{
    public class Character : MonoBehaviour
    {

        [SerializeField, Range(0, 5000)]
        private float hpMax = 100;

        [SerializeField, Tooltip("會造成傷害的標籤名稱")]
        private string damageObjectTag;

        protected float hp;
        public Rigidbody2D rig { get; private set; }
        public Animator ani { get; private set; }

        protected virtual void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();

            hp = hpMax;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (hp <= 0)return;

            if(collision.CompareTag(damageObjectTag))
            {
                Damge(collision.GetComponent<AttackArea>().attack);
            }
        }

        /// <summary>
        /// 設定速度
        /// </summary>
        /// <param name="x">X 軸速度</param>
        /// <param name="y">Y 軸速度</param>
        public void SetVelocity(float x, float y)
        {
            rig.linearVelocity = new Vector2(x, y);
        }

        /// <summary>
        /// 翻面
        /// </summary>
        /// <param name="h">水平值</param>
        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        ///<summary>
        ///受傷
        /// </summary>
        /// <param name="damage">受傷值</param>
        protected virtual void Damge(float damage)
        {
            hp -= damage;
            Debug.Log($"<color=#f96>{name} 受傷，血量 : {hp}</color>");
        }
    }
}