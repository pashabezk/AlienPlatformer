using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
	public GameObject confirmResetPanel;

	void Start() {
		closeModals();
	}

	public void onMenuButtonClick() {
		SceneManager.LoadScene("MainMenuScene");
	}

	public void onResetButtonClick() {
		confirmResetPanel.SetActive(true);
	}

	public void resetGame() {
		PlayerPrefs.DeleteAll();
		closeModals();
	}

	public void closeModals() {
		confirmResetPanel.SetActive(false);
	}
}