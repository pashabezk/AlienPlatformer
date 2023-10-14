using UnityEngine;

public class DieSpace : MonoBehaviour
{
	public static GameObject respawn;

	public GameObject firstRespawn;

	public void Start() {
		if (firstRespawn) {
			respawn = firstRespawn;
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.transform.position = respawn.transform.position;
			LivesManager.loseLive();
		}
	}
}