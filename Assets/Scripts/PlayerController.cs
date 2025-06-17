using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;          //이동 속도

    private Rigidbody playerRb;
    private GameObject focalPoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        //플레이어 이동
        //카메라 회전에따라서 플레이어 방향 초기화
        playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);
    }
}
