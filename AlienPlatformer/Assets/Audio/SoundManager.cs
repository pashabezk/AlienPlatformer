using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundManager : MonoBehaviour
{
	public Slider volumeSlider;
	public TextMeshProUGUI percentage;

	private AudioSource audioSource;

	public void Start() {
		audioSource = GetComponent<AudioSource>();
		volumeSlider.onValueChanged.AddListener(delegate { onVolumeChange(); });
		volumeSlider.value = PlayerPrefs.GetFloat("volume", 1);
	}

	private void onVolumeChange() {
		percentage.text = (Math.Round(volumeSlider.value * 100)).ToString() + "%";
		audioSource.volume = volumeSlider.value;
		PlayerPrefs.SetFloat("volume", volumeSlider.value);
	}
}
