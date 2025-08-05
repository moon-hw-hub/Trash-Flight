using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; // ����Ƽ���� �迭�� ���� ���ӿ�����Ʈ(�������� �����յ�) ����

    [SerializeField]
    private GameObject boss;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; //��������� x���� �迭�� ����

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // EnemySpawner�̶�� ��ü�� ��������鼭 �����
    {
        StartEnemyRoutine();
    }

    // �޼��� ���� ����
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine"); // ��ȣ �ȿ� �޼��� �̸�, Coroutine�� �ð��� �帧�� ���� �۾��� ������ ó���� �� �ֵ��� ���ִ� ����Ƽ�� ���
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); // ���� ������ �ϱ� ���� ���ð� �ο�

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in arrPosX) //x��ǥ �迭�� ���� �ݺ���
            {
                //int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;

            if (spawnCount % 10 == 0) //10ȸ ������ ������
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            if (enemyIndex >=  enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0; //���̵� ����
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) 
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0, 5) == 0) // 20���� Ȯ���� �Ѵܰ� ���� ������ ���� ����
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity); 
        Enemy enemy = enemyObject.GetComponent<Enemy>(); //GetComponent<T>(): �ش� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ����Ƽ�� �Լ�. T�� Ŭ���� Ÿ��
        enemy.SetMoveSpeed(moveSpeed);
    }


    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
