using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private CoinsText _coinsText;
    
    private List<Coin> _coins;
    private float _amountOfCoins;
    
    private void Start()
    {
        _coins = new List<Coin>();
        _coins.AddRange(FindObjectsOfType<Coin>());
    }
    
    public void AddCoins(Coin coin)
    {
        _amountOfCoins++;
        _coinsText.UpdateText(_amountOfCoins.ToString());
        _coins.Remove(coin);
        IsWin();
    }

    private void IsWin()
    {
        if (_coins.Count == 0)
        {
            GameManager.instance.Win();
        }
    }

}
