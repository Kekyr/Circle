using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    private TextMeshProUGUI _amountOfCoinsText;

    private void Start()
    {
        _amountOfCoinsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string newAmountOfCoins)
    {
        _amountOfCoinsText.text = newAmountOfCoins;
    }
}
