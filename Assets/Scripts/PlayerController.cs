using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;          //�̵� �ӵ�
    public bool hasPowerup;             //�÷��̾� �Ŀ��� ���� ����
    public GameObject powerupIndicator; //�Ŀ��� ����Ʈ

    private float powerupStrength = 15.0f;  //�Ŀ��� ��ġ

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

        //�Ŀ��� ����Ʈ ����
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    //�÷��̾� - �Ŀ��� �浹
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    //�Ŀ��� �÷��̾� - �� �浹
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //�� ������Ʈ ã��
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            //������ ���� �� �ֱ�
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    //�Ŀ��� ��ȿ�ð� �� ����Ʈ ����
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
