using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	private static int currentLevel = 1;
	public static int openedLevels = 1;
	private static int maxLevel = 2;

	public void Awake() {
		currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
		openedLevels = PlayerPrefs.GetInt("OpenedLevels", 1);
	}

	public static void loadLevel(int lvl) {
		if (lvl > 0 && lvl <= maxLevel) {
			currentLevel = lvl;
			if (currentLevel > openedLevels) {
				openedLevels = currentLevel;
				PlayerPrefs.SetInt("OpenedLevels", openedLevels);
			}
			PlayerPrefs.SetInt("CurrentLevel", currentLevel);
			SceneManager.LoadScene("Level" + lvl + "Scene");
		} else {
			currentLevel = 1;
			PlayerPrefs.SetInt("CurrentLevel", 1);
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	public static void loadNextLevel() {
		loadLevel(currentLevel + 1);
	}

	public static void loadCurrentLevel() {
		loadLevel(currentLevel);
	}
}

