using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreTeam : MonoBehaviour
{
    float Speed = 7;
    public Rigidbody2D Rigidbody;
    void Start()
    {
        //G?i kh?i khi b?t ??u game
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }
}
