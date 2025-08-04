using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f); //1�� �ڿ� ���ӿ�����Ʈ ���ش�
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
