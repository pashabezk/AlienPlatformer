using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public static bool isRightButtonClick = false;
	public static bool isLeftButtonClick = false;
	public static bool isUpButtonClick = false;

	private float speed = 600f;
	private Animator anim;

	public bool onGround = false;
	public Transform groundCheck;
	private float checkRadius;
	public LayerMask ground;
	private float defaultGravityScale;

	private Rigidbody2D rb;
	private bool isRight = true;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		checkRadius = groundCheck.GetComponent<CircleCollider2D>().radius;
		defaultGravityScale = rb.gravityScale;

		// destroy current character skin
		Transform t = gameObject.transform;
		for (int i = 0; i < t.childCount; i++) {
			if (t.GetChild(i).gameObject.CompareTag("PlayerSprite")) {
				Destroy(t.GetChild(i).gameObject);
				break;
			}
		}

		// add character skin according to settings
		GameObject playerSkinPrefab = Resources.Load<GameObject>("Prefabs/Character/CharacterSprite" + PlayerPrefs.GetInt("selectedSkin", 0));
		Instantiate(playerSkinPrefab, gameObject.transform);
		anim = t.GetChild(t.childCount - 1).gameObject.GetComponent<Animator>();
	}

	void Update() {
		walk();
		checkingGround();
		jump();
	}

	void walk() {
		float moveX = Input.GetAxis("Horizontal");

		if (isRightButtonClick) {
			moveX += 0.6f;
		} else if (isLeftButtonClick) {
			moveX -= 0.6f;
		}

		// rb.MovePosition(rb.position + Vector2.right * (moveX * speed * Time.deltaTime));
		// rb.velocity = Vector2.right * (moveX * speed * Time.deltaTime);
		rb.velocity = new Vector2(moveX * speed * Time.deltaTime, rb.velocity.y * Time.deltaTime);
		anim.SetFloat("moveX", Mathf.Abs(moveX));

		if (moveX > 0 && !isRight) {
			flip();
		} else if (moveX < 0 && isRight) {
			flip();
		}
	}

	void flip() {
		isRight = !isRight;
		transform.localScale = new Vector3(
			transform.localScale.x * -1,
			transform.localScale.y,
			transform.localScale.z
		);
	}

	void jump() {
		if ((Input.GetButtonDown("Jump") || isUpButtonClick) && onGround) {
			// rb.AddForce(Vector2.up * 4000);
			// rb.velocity = Vector2.up * (10000 * Time.deltaTime);
			rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, 200);
			isUpButtonClick = false;
			rb.gravityScale = defaultGravityScale / 10;
		}

		if (rb.velocity.y < 0) {
			rb.gravityScale += 0.7f;
		} else if (rb.velocity.y > 0) {
			rb.gravityScale += 0.5f;
		} else {
			rb.gravityScale = defaultGravityScale;
		}
	}

	void checkingGround() {
		onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
		anim.SetBool("onGround", onGround);
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		switch (coll.tag) {
			case "Coin": {
				CollectableObject coin = coll.GetComponent<CollectableObject>();

				if (!coin.collected) {
					coin.collected = true;
					CoinManager.instance.addCoin();
				}

				Destroy(coll.gameObject);
				break;
			}
			case "Heart": {
				CollectableObject heart = coll.GetComponent<CollectableObject>();

				if (!heart.collected) {
					heart.collected = true;
					LivesManager.addLive();
				}

				Destroy(coll.gameObject);
				break;
			}
			case "Finish": {
				CollectableObject finish = coll.GetComponent<CollectableObject>();
				if (!finish.collected) {
					finish.collected = true;
					LevelManager.loadNextLevel();
				}

				break;
			}
			case "Enemy": {
				gameObject.transform.position = DieSpace.respawn.transform.position;
				LivesManager.loseLive();
				break;
			}
		}
	}
}