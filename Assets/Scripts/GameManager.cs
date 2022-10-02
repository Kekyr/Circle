using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    
    private CoinsManager _coinsManager;
    
    public bool isWin;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _coinsManager = GetComponent<CoinsManager>();
    }
    
    public void AddCoins(Coin coin)
    {
        _coinsManager.AddCoins(coin);
    }
    
    public void Win()
    {
        _winScreen.SetActive(true);
        isWin = true;
    }
    public void Lose()
    {
        _loseScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
