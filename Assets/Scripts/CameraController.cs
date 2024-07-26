using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���������

public class CameraController : MonoBehaviour
{
    public float speed = 3; //����ƶ��ٶ�


    void Update()
    {
        Move();
    }



    private void Move()
    {
        float horizontal = GameInputManager.MainInstance.Movement.x;
        float vertical = GameInputManager.MainInstance.Movement.y;

        transform.Translate(new Vector3(horizontal * speed, 0, vertical * speed) * Time.deltaTime, Space.World);
    }
}
