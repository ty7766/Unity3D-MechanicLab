using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;          //이동 속도
    public bool hasPowerup;             //플레이어 파워업 적용 여부


    private float powerupStrength = 15.0f;  //파워업 수치

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

    //플레이어 - 파워업 충돌
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    //파워업 플레이어 - 적 충돌
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //적 오브젝트 찾기
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            //적에게 순간 힘 주기
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
