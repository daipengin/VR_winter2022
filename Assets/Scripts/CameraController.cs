using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camFollower;
    public float moveSpeed = 1;
    public float camRotateSpeed = 1;
    int screenW = UnityEngine.Screen.width;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DirectionMove();
        ClickMove();
    }
    void DirectionMove()
    {
        // VRだとFollowerのオブジェクトを参照する
        Vector3 velocity = camFollower.transform.rotation * new Vector3(0, 0, moveSpeed);
        gameObject.transform.position += velocity * Time.deltaTime;
    }

    void ClickMove()
    {
        // 左ボタンクリック
        if (Input.GetMouseButton(0))
        {
            float mousePositionX = Input.mousePosition.x;
            if (screenW / 2 > mousePositionX)
            {
                // 画面の中央より左側をクリックするとカメラが左に回転
                gameObject.transform.Rotate(new Vector3(0, camRotateSpeed * -1, 0));
            }
            else
            {
                // 画面の中央より右側をクリックするとカメラが右に回転
                gameObject.transform.Rotate(new Vector3(0, camRotateSpeed, 0));
            }
        }
    }
}
