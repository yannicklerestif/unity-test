using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly float GroundMargin = 0.01f;
    public static float DummyX = 0.0f;
    public static float DummyY = 0.0f;

    public float speed;
    public float vSpeed;
    public Rigidbody2D body;

    private Collider2D _collider2D;

    public EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var bottomX = _collider2D.bounds.center.x;
        var bottomY = _collider2D.bounds.center.y - _collider2D.bounds.extents.y;
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(new Vector2(bottomX, bottomY),
            new Vector2(GroundMargin, -GroundMargin), 0);
        bool isGrounded = collider2Ds.Length == 2;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float vSpeed_ = body.velocity.y;
        float hSpeed_ = speed * h;

        if (isGrounded && v > 0)
        {
            vSpeed_ = v * vSpeed;
        }

        body.velocity = new Vector2(hSpeed_, vSpeed_);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Constants.DeathZoneTag))
            eventManager.OnPlayerDied();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Constants.MonsterTag))
            eventManager.OnPlayerDied();
    }
}