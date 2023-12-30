using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
	public GameObject[] buttons;

	public void Start() {
		int lastLevel = LevelManager.openedLevels;
		for (int i = lastLevel; i < buttons.Length; i++) {
			buttons[i].GetComponent<Button>().interactable = false;
		}
	}

	public void onMenuButtonClick() {
		SceneManager.LoadScene("MainMenuScene");
	}

	public void onLevelButtonClick(int level) {
		LevelManager.loadLevel(level);
	}
}