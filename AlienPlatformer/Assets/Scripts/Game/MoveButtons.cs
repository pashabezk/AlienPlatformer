using UnityEngine;

public class MoveButtons : MonoBehaviour
{
	public void rightButtonPress() {
		PlayerControl.isRightButtonClick = true;
	}

	public void rightButtonRelease() {
		PlayerControl.isRightButtonClick = false;
	}

	public void leftButtonPress() {
		PlayerControl.isLeftButtonClick = true;
	}

	public void leftButtonRelease() {
		PlayerControl.isLeftButtonClick = false;
	}

	public void jumpButtonClick() {
		PlayerControl.isUpButtonClick = true;
	}
}