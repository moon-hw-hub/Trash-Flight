using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; // 유니티에서 배열에 직접 게임오브젝트(만들어놓은 프리팹들) 삽입

    [SerializeField]
    private GameObject boss;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; //스폰장소의 x값을 배열에 저장

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // EnemySpawner이라는 객체가 만들어지면서 실행됨
    {
        StartEnemyRoutine();
    }

    // 메서드 별도 정의
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine"); // 괄호 안에 메서드 이름, Coroutine은 시간의 흐름에 따라 작업을 나눠서 처리할 수 있도록 해주는 유니티의 기능
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); // 뒤의 동작을 하기 전에 대기시간 부여

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in arrPosX) //x좌표 배열을 도는 반복문
            {
                //int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;

            if (spawnCount % 10 == 0) //10회 스폰될 때마다
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            if (enemyIndex >=  enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0; //난이도 조절
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) 
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0, 5) == 0) // 20퍼의 확률로 한단계 높은 레벨의 적이 나옴
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity); 
        Enemy enemy = enemyObject.GetComponent<Enemy>(); //GetComponent<T>(): 해당 오브젝트에 붙어있는 컴포넌트를 가져오는 유니티의 함수. T는 클래스 타입
        enemy.SetMoveSpeed(moveSpeed);
    }


    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
