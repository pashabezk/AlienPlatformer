using System;
using UnityEngine;

public class Spider : MonoBehaviour
{
	public GameObject spiderSprite;
	public Transform startPoint;
	public Transform endPoint;

	public float speed = 1.0f;

	void Update() {
		Vector3 spiderPosition = spiderSprite.transform.position;
		Vector3 endPosition = endPoint.position;
		spiderSprite.transform.position = Vector3.MoveTowards(spiderPosition, endPosition, speed * Time.deltaTime);
		if (Math.Abs(spiderPosition.x - endPosition.x) < 0.1 && Math.Abs(spiderPosition.y - endPosition.y) < 0.1) {
			swapStartAndEnd();
		}
	}

	private void swapStartAndEnd() {
		var spiderScale = spiderSprite.transform.localScale;
		spiderSprite.transform.localScale = new Vector3(spiderScale.x * -1, spiderScale.y, spiderScale.z);
		(startPoint, endPoint) = (endPoint, startPoint);
	}
}