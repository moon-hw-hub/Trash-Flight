using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin; // ����Ƽ���� ���������� ��ü�� �ش� ���۷����� �Ҵ� 

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed; //�տ��Ŵ� Ŭ������� �ڿ��Ŵ� �Ű�����
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //istrigger üũ �Ǿ��������, �浹 ó�� �޼���
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                Destroy(gameObject); //���� �����
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision) // istrigger üũ �ȵǾ��������
    //{
        
    //}
}
