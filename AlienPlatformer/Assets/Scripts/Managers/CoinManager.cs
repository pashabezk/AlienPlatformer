using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
	public static CoinManager instance;
	public TextMeshProUGUI coinsText;

	private int coins;

	private void Awake() {
		instance = this;
		coins = PlayerPrefs.GetInt("Coins", 0);
	}

	private void Start() {
		setCoinsText();
	}

	public void addCoin() {
		coins++;
		PlayerPrefs.SetInt("Coins", coins);
		setCoinsText();
	}

	private void setCoinsText() {
		coinsText.text = coins.ToString();
	}

	public int getCoins() {
		return coins;
	}

	public void spendCoins(int number) {
		coins -= number;
		PlayerPrefs.SetInt("Coins", coins);
		setCoinsText();
	}
}