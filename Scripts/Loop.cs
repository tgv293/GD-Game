using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    public GameObject loop;

    public float MaxTime;

    float timer;

    float heigh;
    private void Start()
    {
    }
    private void Update()
    {
        //Nếu tg vượt qua Maxtime (set trong Unity)
        if (timer > MaxTime)
        {
            //Tạo ra 1 cube mới
            //transform.position và Quaternion.identity là vị trí xuất hiện mà ta set ở trong Unity
            GameObject cube = Instantiate(loop, transform.position,Quaternion.identity);
            //Vì tạo ra trong hàng chờ, nếu trong xóa thì nó sẽ tạo rất nhiều nên ta phải xóa nó đi
            //Dùng Destroy để xóa cube sau mỗi 10 giây           
            Destroy(cube, 5f);
            //Sẽ reset về 0
            timer= 0;
        }
        timer += Time.deltaTime;
    }
}
