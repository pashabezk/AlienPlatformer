using UnityEngine;

public class CamMove : MonoBehaviour
{
	public GameObject player;
	private float cameraSpeed = 3f;
	private float yOffset = 1f;

	public void Update() {
		Vector3 positionToGo = new Vector3(player.transform.position.x, player.transform.position.y, -10f); //Target position of the camera
		positionToGo.y += yOffset;
		transform.position = Vector3.Lerp(transform.position, positionToGo, Time.deltaTime * cameraSpeed);
	}
}