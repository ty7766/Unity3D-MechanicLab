using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;             //ī�޶� ȸ�� �ӵ�


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
