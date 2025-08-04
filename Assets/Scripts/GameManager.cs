using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour // 게임의 전반적인 내용를 관리하는 클래스. 싱글톤 디자인패턴 사용 
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
