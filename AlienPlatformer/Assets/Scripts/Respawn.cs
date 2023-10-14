using UnityEngine;

public class Respawn : MonoBehaviour
{
	public int respawnIndex = 0;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (respawnIndex >= DieSpace.respawn.gameObject.GetComponent<Respawn>().respawnIndex) {
				DieSpace.respawn = gameObject;
			}
		}
	}
}
