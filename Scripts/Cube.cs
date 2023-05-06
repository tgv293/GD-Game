using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube: MonoBehaviour
{
    [SerializeField] private float JumpPointDistance = 1f;
    [SerializeField] private Transform GroundCheckTransform;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Transform Sprite;
    [SerializeField] private ParticleSystem movementParticle;
    [SerializeField] private GameObject JumpEffect;
    [SerializeField] private ParticleSystem jumpParticle;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (OnGround()||NearJumpPoint())
        {
            movementParticle.Play();
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            Sprite.rotation = Quaternion.Euler(Rotation);
            if (Input.GetMouseButton(0)||Input.GetKeyDown(KeyCode.Space))
            {
                JumpEffect.SetActive(true);
                jumpParticle.Play();
                jump();
                
            }
            else JumpEffect.SetActive(false);

        }
        else
        {
            Sprite.Rotate(Vector3.back * 3f);
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 43f, ForceMode2D.Impulse);
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
    }
    
    private bool NearJumpPoint()
    {
        var hit = Physics2D.CircleCast(transform.position, JumpPointDistance, Vector2.zero, 0, 1 << LayerMask.NameToLayer("JumpPoint"));

        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("JumpButton"))
            jump();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * GroundCheckRadius);
    }

}
