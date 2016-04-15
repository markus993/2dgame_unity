using UnityEngine;
using System.Collections;

public class musicplayer : MonoBehaviour {
	public AudioClip itemSoundClip;
	public float itemSoundVolume = 1f;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(itemSoundClip, transform.position, itemSoundVolume);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
