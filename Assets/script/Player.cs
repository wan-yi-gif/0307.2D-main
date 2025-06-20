using UnityEngine;

namespace Wanyi
{
    /// <summary>
    /// 玩家腳本：玩家的基本資料與行為
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region 變數
        [Header("基本數值")]
        [SerializeField, Range(0, 10)]
        private float moveSpeed = 3.5f;

        [SerializeField, Range(0, 10)]
        private float jump = 5;

        // [Header("元件")]
        // [SerializeField]
        private Rigidbody2D rig;

        // [SerializeField]
        private Animator ani;

        [Header("檢查地板資料")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;

        [SerializeField]
        private Vector3 checkGroundOffset;

        [SerializeField]
        private LayerMask LayerGround = 1 << 3;
        #endregion

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
        }
    }

}
