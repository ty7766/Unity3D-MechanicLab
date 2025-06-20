using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;             //카메라 회전 속도


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
