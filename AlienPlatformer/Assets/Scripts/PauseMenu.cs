using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isGamePaused = false;

	public GameObject pauseMenuPanel;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isGamePaused) {
				resume();
			} else {
				pause();
			}
		}
	}

	public void resume() {
		pauseMenuPanel.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
		AudioListener.pause = false;
	}

	public void pause() {
		pauseMenuPanel.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
		AudioListener.pause = true;
	}

	public void goToMenu() {
		SceneManager.LoadScene("MainMenuScene");
		Time.timeScale = 1f;
		isGamePaused = false;
		AudioListener.pause = false;
	}

	public void quitGame() {
		Application.Quit();
	}
}