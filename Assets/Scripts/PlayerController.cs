using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;          //�̵� �ӵ�

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
        //�÷��̾� �̵�
        //ī�޶� ȸ�������� �÷��̾� ���� �ʱ�ȭ
        playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);
    }
}
