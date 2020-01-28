using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletType;

    public bool IsRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Не больше 50 градусов

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты

        Vector2 AxisX = Vector2.right;
        float CalcMousePosY = mousePosition.y;
        float CalcTransformPosY = transform.position.y;

        if (!IsRight)
        {
            AxisX = Vector2.left;
            CalcMousePosY = -CalcMousePosY;
            CalcTransformPosY = -CalcTransformPosY;
        }

        var angle = Vector2.Angle(AxisX, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
        transform.eulerAngles = new Vector3(0f, 0f, CalcTransformPosY < CalcMousePosY ? angle : -angle);//немного магии на последок
    }
}