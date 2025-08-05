using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField] // �̻��� �������� ��ü��
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform; // �߻� ���� ��ġ��

    [SerializeField]
    private float shootInterval = 0.05f;

    private float lastShotTime = 0f;

    void Update() //������Ʈ �޼���
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        //Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //
        //    transform.position -= moveTo;
        //} else if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += moveTo;
        //}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // ��踦 ����� ����� ������ ����
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        if (GameManager.instance.isGameOver == false) // ���� ���� �� ������ ���ȸ� �����Ѵ�.
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        // 10 - 0 > 0.05
        // lastShotTime = 10

        // 10.001 - 10 > 0.05? -> False
        //10.06 - 10 > 0.05 -> True
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }

    }

    public void OnTriggerEnter2D(Collider2D other) //�÷��̾�� ���� �浹���� ��� ó��
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            //Debug.Log("Game Over");
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin +1");
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }

}
