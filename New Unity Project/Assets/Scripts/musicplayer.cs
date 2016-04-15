using UnityEngine;
using System.Collections;

public class musicplayer : MonoBehaviour {
	public AudioClip itemSoundClip;
	public float itemSoundVolume = 10f;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(itemSoundClip, new Vector2(0,0), itemSoundVolume);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
