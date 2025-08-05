using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // 게임의 전반적인 내용를 관리하는 클래스. 싱글톤 디자인패턴 사용 
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false; //아직 게임이 안끝났음

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        if (coin % 30 == 0) // 30, 60, 90 ...
        {
            Player player = FindAnyObjectByType<Player>();
            if (player != null )
            {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }

        Invoke("ShowGameOverPanel", 1f); // 1초 뒤에 메서드 실행
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // SetActive(bool) : 오브젝트의 활성 비활성 상태 조절 
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene"); //샘플신을 다시 불러옴
    }
}
