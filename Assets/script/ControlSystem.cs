using System;
using UnityEngine;

internal class ControlSystem : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public Rigidbody2D rig;
    public Animator ani;
    public Vector3 checkGroundOffset;
    public Vector2 checkGroundSize;
    public LayerMask LayerGround;

    private void Awake()
    {
        Debug.Log(":D");
    }

    private void Start()
    {
        Debug.Log("<color=green>開始事件</color>");
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        rig.linearVelocity = new Vector2(moveSpeed * h, rig.linearVelocity.y);

        ani.SetFloat("移動數值", Mathf.Abs(h));

        bool isGrounded = Physics2D.OverlapBox(transform.position + checkGroundOffset, checkGroundSize, 0, LayerGround);
        ani.SetBool("開關跳躍", !isGrounded);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("跳躍");
            rig.linearVelocity = new Vector2(rig.linearVelocity.x, jumpForce);
        }

        if (Mathf.Abs(h) < 0.1f) return;

        float angle = h > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}