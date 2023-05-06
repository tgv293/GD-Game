using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship: MonoBehaviour
{
    [SerializeField] private Transform Sprite;
    [SerializeField] private GameObject FlyEffect;
    private float gravityScale;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        fly();
    }

    private void FixedUpdate()
    {
            if (rb.gravityScale == -gravityScale)
            {
                FlyEffect.SetActive(true);
                Sprite.rotation = Quaternion.Euler(0, 0, 20);
            }
            else if (rb.gravityScale == gravityScale)
            {
                FlyEffect.SetActive(false);
                Sprite.rotation = Quaternion.Euler(0, 0, -20);
            } 
            
    }

    private void fly()
    {
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
            rb.gravityScale = -gravityScale;
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            rb.gravityScale = gravityScale;
    }

}
