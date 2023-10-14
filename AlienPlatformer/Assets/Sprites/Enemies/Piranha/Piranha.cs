using System;
using UnityEngine;

public class Piranha : MonoBehaviour
{
	public GameObject enemySprite;

	public Transform startPoint;
	public Transform endPoint;
	private Transform pointToGo;

	public float speed = 6.0f;

	public void Start() {
		pointToGo = endPoint;
	}

	public void Update() {
		Vector3 enemyPosition = enemySprite.transform.position;
		Vector3 endPosition = pointToGo.position;

		float heightCoeff = endPoint.position.y - enemyPosition.y;
		enemySprite.transform.position = Vector3.MoveTowards(enemyPosition, endPosition, heightCoeff * speed * Time.deltaTime);
		if (Math.Abs(enemyPosition.x - endPosition.x) < 0.1 && Math.Abs(enemyPosition.y - endPosition.y) < 0.1) {
			swapPointToGo();
		}
	}

	private void swapPointToGo() {
		var enemyScale = enemySprite.transform.localScale;
		enemySprite.transform.localScale = new Vector3(enemyScale.x, enemyScale.y * -1, enemyScale.z);

		pointToGo = pointToGo == startPoint ? endPoint : startPoint;
	}
}