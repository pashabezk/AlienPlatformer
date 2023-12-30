using UnityEngine;

public class Background : MonoBehaviour
{
	public Transform followingTarget;
	public float parallaxStrength = 1f;
	public bool enableVerticalParallax = false;
	private Vector3 targetPreviousPosition;

	// Start is called before the first frame update
	void Start() {
		if (!followingTarget) {
			followingTarget = Camera.main.transform;
		}

		targetPreviousPosition = followingTarget.position;
	}

	// Update is called once per frame
	void Update() {
		Vector3 delta = followingTarget.position - targetPreviousPosition;

		if (!enableVerticalParallax) {
			delta.y = 0;
		}

		targetPreviousPosition = followingTarget.position;

		transform.position += delta * parallaxStrength;
	}
}