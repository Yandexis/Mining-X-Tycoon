using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // разрешение перемещать камеру по координате Х
    public bool MovementX;
    // разрешение перемещать камеру по координате Y
    public bool MovementY;

    //скорость, чем больше это значение тем быстрее движется камера и наоборот
    public float SpeedValue;
    //инерция, чем больше это значение тем дальше камера летит после того как пользователь отпустить нажатие
    public float InertiaValue;

    //минимальные координаты Х
    public float MinCordX;
    //максимальные координаты Х
    public float MaxCordX;
    //минимальные координаты Y
    public float MinCordY;
    //максимальные координаты Y
    public float MaxCordY;

    //стартовая позиция камеры
    private Vector3 startingPosition;
    //камера
    private Camera mainCamera;
    //изменение позиции Х
    private float targetPositionX;
    //изменение позиции Y
    private float targetPositionY;

    private void Start()
    {
        //получаем елементы
        mainCamera = GetComponent<Camera>();
        targetPositionX = transform.position.x;
        targetPositionY = transform.position.y;
    }

    private void Update()
    {
        //если был сделан клик то получаем стартовые координаты камеры
        if (Input.GetMouseButtonDown(0))
        {
            startingPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        //иначе если клик зажат то вычисляем смещение координат Х и Y взависимости от разрешений
        else if (Input.GetMouseButton(0))
        {
            if (MovementX)
            {
                float positionX = (mainCamera.ScreenToWorldPoint(Input.mousePosition).x - startingPosition.x) * SpeedValue;
                targetPositionX = Mathf.Clamp(transform.position.x - positionX, MinCordX, MaxCordX);
            }
            if (MovementY)
            {
                float positionY = (mainCamera.ScreenToWorldPoint(Input.mousePosition).y - startingPosition.y) * SpeedValue;
                targetPositionY = Mathf.Clamp(transform.position.y - positionY, MinCordY, MaxCordY);
            }
        }

        //если разрешенно двигатся по Х то вычисляется перемешение обьекта по Х
        if (MovementX)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPositionX, (SpeedValue / InertiaValue) * Time.deltaTime), transform.position.y, transform.position.z);
        }
        //если разрешенно двигатся по Y то вычисляется перемешение обьекта по Y
        if (MovementY)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPositionY, (SpeedValue / InertiaValue) * Time.deltaTime), transform.position.z);
        }
    }
}
