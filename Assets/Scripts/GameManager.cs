using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour // ������ �������� ���븦 �����ϴ� Ŭ����. �̱��� ���������� ��� 
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;

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

        if (coin % 10 == 0) //10, 20, 30 ...
        {
            Player player = FindAnyObjectByType<Player>();
            if (player != null )
            {
                player.Upgrade();
            }
        }
    }

}
