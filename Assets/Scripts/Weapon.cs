using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f); //1초 뒤에 게임오브젝트 없앤다
    }
    [SerializeField]
    private float moveSpeed = 10f;

    public float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
