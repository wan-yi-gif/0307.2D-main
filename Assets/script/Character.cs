using UnityEngine;

namespace Wanyi

{
    public class Character : MonoBehaviour
    {
        public Rigidbody2D rig { get; private set; }
        public Animator ani { get; private set; }

        protected virtual void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            // 取得此物件身上的2D剛體存放到rig變數
            ani = GetComponent<Animator>();
        }

        /// <summary>
        /// 設定加速度
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="x">X 軸加速度</param>
        /// <param name="y">Y 軸加速度</param>
        public void SetVelocity(Vector3 direction)
        {
            rig.linearVelocity = direction;
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
    }
}