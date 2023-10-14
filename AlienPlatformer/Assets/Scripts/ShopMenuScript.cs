using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
	public GameObject[] cards;
	
	public GameObject confirmSkinPurchasePanel;
	public GameObject notEnoughMoneyPanel;

	private bool[] isBought = { true, false, false, false, false };
	private int[] prices = { 0, 20, 50, 100, 250 };
	public static int selectedSkin = 0;

	private int skinToBuy = 0; // for confirm modal

	public void Awake() {
		string[] array = PlayerPrefs.GetString("isBought", "true false false false false").Split(' ');
		for (int i = 0; i < array.Length; i++) {
			isBought[i] = bool.Parse(array[i]);
		}

		selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
	}

	public void Start() {
		for (int i = 0; i < cards.Length; i++) {
			setCardText(i);
			int tempI = i;
			cards[i].gameObject.GetComponent<Button>().onClick.AddListener(() => onCardClick(tempI));
		}
		selectCard();
	}

	private void saveData() {
		string isBoughtStr = string.Join(' ', isBought);
		PlayerPrefs.SetString("isBought", isBoughtStr);
		PlayerPrefs.SetInt("selectedSkin", selectedSkin);
	}

	private void setCardText(int cardNumber) {
		TextMeshProUGUI text = cards[cardNumber].gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

		if (cardNumber == selectedSkin) {
			text.text = "Выбран";
		} else if (isBought[cardNumber]) {
			text.text = "Выбрать";
		} else {
			text.text = prices[cardNumber].ToString();
		}
	}

	public void selectCard() {
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(cards[selectedSkin]);
	}

	public void onCardClick(int cardNumber) {
		int prevSelectedSkin = selectedSkin;
		if (isBought[cardNumber]) {
			// skin already bought
			selectedSkin = cardNumber;
			setCardText(cardNumber);
			setCardText(prevSelectedSkin);
			saveData();
		} else if (CoinManager.instance.getCoins() >= prices[cardNumber]) {
			// skin could be bough: open confirm modal
			skinToBuy = cardNumber;
			confirmSkinPurchasePanel.SetActive(true);
		} else {
			// not enough money to buy
			notEnoughMoneyPanel.SetActive(true);
		}
		selectCard();
	}

	public void confirmPurchaseSkin() {
		int prevSelectedSkin = selectedSkin;
		CoinManager.instance.spendCoins(prices[skinToBuy]);
		selectedSkin = skinToBuy;
		isBought[skinToBuy] = true;
		setCardText(skinToBuy);
		setCardText(prevSelectedSkin);
		saveData();
		closePanels();
	}

	public void onMenuButtonClick() {
		SceneManager.LoadScene("MainMenuScene");
	}

	public void onMenuButtonExit() {
		selectCard();
	}

	public void closePanels() {
		confirmSkinPurchasePanel.SetActive(false);
		notEnoughMoneyPanel.SetActive(false);
		selectCard();
	}
}