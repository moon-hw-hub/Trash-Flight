using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // ������ �������� ���븦 �����ϴ� Ŭ����. �̱��� ���������� ��� 
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false; //���� ������ �ȳ�����

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

        Invoke("ShowGameOverPanel", 1f); // 1�� �ڿ� �޼��� ����
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // SetActive(bool) : ������Ʈ�� Ȱ�� ��Ȱ�� ���� ���� 
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene"); //���ý��� �ٽ� �ҷ���
    }
}
