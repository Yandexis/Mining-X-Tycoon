using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    public float Speed;
    public float MinCordX;
    public float MaxCordX;
    public float MinCordZ;
    public float MaxCordZ;

    private Vector3 startingPosition;
    private Camera camera;
    private float targetPositionX;
    private float targetPositionZ;
    private float bonus = 20f;

    private void Start()
    {
        camera = GetComponent<Camera>();
        targetPositionX = transform.position.x;
        targetPositionZ = transform.position.z;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) startingPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float positionX = (camera.ScreenToWorldPoint(Input.mousePosition).x - startingPosition.x) * Speed;
            targetPositionX = Mathf.Clamp(transform.position.x - positionX, MinCordX, MaxCordX);

            float positionZ = (camera.ScreenToWorldPoint(Input.mousePosition).z - startingPosition.z) * Speed - bonus;
            targetPositionZ = Mathf.Clamp(transform.position.z - positionZ, MinCordZ, MaxCordZ);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPositionX, (Speed + 5f) * Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, targetPositionZ, (Speed + 5f)/2f * Time.deltaTime));
    }
}
