using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl1 : MonoBehaviour
{
    public float Speed;
    public float MinCordX;
    public float MaxCordX;    

    private Vector2 startingPosition;
    private Camera camera;
    private float targetPosition;

    private void Start()
    {
        camera = GetComponent<Camera>();
        targetPosition = transform.position.x;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) startingPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float position = (camera.ScreenToWorldPoint(Input.mousePosition).x - startingPosition.x) * Speed;
            targetPosition = Mathf.Clamp(transform.position.x - position, MinCordX, MaxCordX);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition, (Speed + 3) * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
