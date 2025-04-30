using System;
using UnityEngine;

internal class ControlSystem : MonoBehaviour

{
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
        Debug.Log("<color=red>更新事件</color>");
        rig.linearVelocity = new Vector2(moveSpeed, 0);
        
        float h = Input.GetAxis("Horizontal");
        Debug.Log(h);
        rig.linearVelocity = new Vector2(moveSpeed * h , 0);
        
        ani.SetFloat("移動數值", Mathf.Abs(h));

        float angle = h > 0 ? 0 : 180;
        
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
    [Header("基本數值")]
    [SerializeField, Header("移動速度"), Range(0, 10)]
    private float moveSpeed = 3.5f;

    [Header("元件")]
    [SerializeField]
    private Rigidbody2D rig;

    [SerializeField]
    private Animator ani;
    
}
