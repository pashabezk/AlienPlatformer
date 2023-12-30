using UnityEngine;

public class OnlyMobile : MonoBehaviour
{
	void Start() {
		if (!(
			Application.platform == RuntimePlatform.Android
			|| Application.platform == RuntimePlatform.IPhonePlayer
			|| Application.platform == RuntimePlatform.WindowsEditor
		)) {
			Destroy(gameObject);
		}
	}
}