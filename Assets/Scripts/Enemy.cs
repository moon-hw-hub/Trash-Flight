using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin; // 유니티에서 코인프리팹 객체를 해당 레퍼런스에 할당 

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed; //앞에거는 클래스멤버 뒤에거는 매개변수
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

    private void OnTriggerEnter2D(Collider2D other) //istrigger 체크 되어있을경우, 충돌 처리 메서드
    {
        if (other.gameObject.tag == "Weapon") //gameObject : 해당 스크립트가 붙어있는 GameObject를 참조함
        {
            Weapon weapon = other.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                if (gameObject.tag == "Boss")
                {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject); //적이 사라짐
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision) // istrigger 체크 안되어있을경우
    //{
        
    //}
}
