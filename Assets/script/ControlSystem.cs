using System;
using UnityEngine;

internal class ControlSystem : MonoBehaviour

{

    [Header("基本數值")]
    [SerializeField , Range(0 , 10)]
    private float moveSpeed = 3.5f;

    [SerializeField , Range(0 , 10)]
    private float jump = 5;

    [Header("元件")]
    [SerializeField]
    private Rigidbody2D rig;

    [SerializeField]
    private Animator ani;

    [Header("檢查地板資料")]
    [SerializeField]
    private Vector3 checkGroundSize = Vector3.one;

    [SerializeField]
    private Vector3 checkGroundOffset;

    [SerializeField]
    private LayerMask LayerGround = 1 << 3;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.3f, 0.3f, 0.5f);
        Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
    }
    
    // 喚醒事件：播放後會第一個執行的事件 (執行一次)
    // 適合用來做初始化，例如：英雄聯盟一開始的玩家金幣
    private void Awake()
    {
        // 輸出訊息到 Untiy 的 Console 面板
        Debug.Log(":D");
    }

    // 開始事件：喚醒事件後執行一次
    private void Start()
    {
        Debug.Log("<color=green>開始事件</color>");
    }

    // 更新事件：開始事件後執行，每秒約 60 次
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        // Unity API (Unity 倉庫，遊戲功能)
        // 剛體的加速度 = 二維向量
        // Horizontal 左、A ， 右、D
        // 左：-1
        // 右：+1
        // 沒按：0
        Debug.Log(h);
        rig.linearVelocity = new Vector2(moveSpeed * h , 0);
        
        ani.SetFloat("移動數值" , Mathf.Abs(h));
        // 動畫的設定浮點數("參數的名稱"，數值)
        // Mathf.Abs() 取絕對值
        
        bool isGrounded = Physics2D.OverlapBox(transform.position + checkGroundOffset, checkGroundSize, 0, LayerGround);
        ani.SetBool("開關跳躍", !isGrounded);

        if (Mathf.Abs(h) < 0.1f) return;
        
        float angle = h > 0 ? 0 : 180;
        
        transform.eulerAngles = new Vector3(0 , angle , 0);
        
        rig.linearVelocity = new Vector2(moveSpeed * h , rig.linearVelocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("跳躍");
            rig.linearVelocity = new Vector2(0, jump);
            // 如果按下空白鍵就跳躍
        }
    }
}
