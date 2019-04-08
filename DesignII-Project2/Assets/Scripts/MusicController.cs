using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [SerializeField] private AudioClip _music;
    [SerializeField] private AudioSource _musicSource;

	// Use this for initialization
	void Start () {
        _musicSource.clip = _music;
        _musicSource.Play();
	}
}
