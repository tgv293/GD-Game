using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    //Tạo value mặc định tốc độ di chuyển
    public float SpeedCube = 7;

    float Jump = 9;

    //Khởi tạo Body cho khối (cube)
    public Rigidbody2D Rigidbody;
    void Start()
    {
        //Gọi khối khi bắt đầu game
        Rigidbody= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Dùng Vector3 vì có 3 giá trị X,Y,Z
        //Nhân vơi deltaTime để game chạy mượt
        transform.position += Vector3.right * SpeedCube * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector2.up * Jump);         
        }
    }
}
