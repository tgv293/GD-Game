using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private ParticleSystem jumpParticle;
    [SerializeField] private GameObject JumpEffect;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            jumpParticle.Play();
            jump();  
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 50f, ForceMode2D.Impulse);
    }

}
