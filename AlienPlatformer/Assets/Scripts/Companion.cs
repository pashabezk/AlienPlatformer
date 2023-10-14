using UnityEngine;

public class Companion : MonoBehaviour
{
	public GameObject player;
	public float speed = 1f;

	private float xOffset = -0.9f;
	private float yOffset = 0.5f;
	private Vector3 offset;
	private bool isRight = true;

	void Start() { offset = new Vector3(xOffset, yOffset, 0f); }

	void Update() {
		changePosition();
		fly();
	}

	// to move companion behind player move
	void changePosition() {
		if (player.transform.localScale.x < 0 && xOffset < 0) {
			xOffset *= -1;
			offset = new Vector3(xOffset, yOffset, 0f);
		} else if (player.transform.localScale.x >= 0 && xOffset > 0) {
			xOffset *= -1;
			offset = new Vector3(xOffset, yOffset, 0f);
		}
	}

	void fly() {
		Vector3 oldPosition = transform.position;

		Vector3 positionToGo = new Vector3(player.transform.position.x, player.transform.position.y, 0); //Target position of the camera
		positionToGo += offset;
		transform.position = Vector3.Lerp(oldPosition, positionToGo, Time.deltaTime * speed);

		// rotate companion
		if ((positionToGo.x > oldPosition.x) && !isRight) {
			flip();
		} else if ((positionToGo.x < oldPosition.x) && isRight) {
			flip();
		}

		// to make companion look on player after stop moving
		if (Mathf.Abs(positionToGo.x - oldPosition.x) < 1.0f) {
			if (xOffset < 0 && !isRight) {
				flip();
			} else if (xOffset > 0 && isRight) {
				flip();
			}
		}
	}

	void flip() {
		isRight = !isRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
}