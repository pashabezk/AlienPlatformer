using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
	private static LivesManager instance;

	private static int liveCount = 3;
	private GameObject heartPrefab;

	public void Start() {
		instance = this;
		liveCount = 3;
		heartPrefab = Resources.Load<GameObject>("Prefabs/HeartUI");
		changeLives();
	}

	public static void addLive() {
		liveCount++;
		instance.changeLives();
	}

	public static void loseLive() {
		liveCount--;
		instance.changeLives();
		if (liveCount <= 0) {
			SceneManager.LoadScene("MainMenuScene");
			liveCount = 3;
		}
	}

	private void changeLives() {
		int childCount = gameObject.transform.childCount;
		while (childCount != liveCount) {
			if (liveCount > childCount) {
				Instantiate(heartPrefab, gameObject.transform);
				childCount++;
			} else if (liveCount < childCount) {
				Destroy(gameObject.transform.GetChild(0).gameObject);
				childCount--;
			}
		}
	}
}