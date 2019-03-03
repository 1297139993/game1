using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {
    public AudioClip hit;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	private void hitAudio()
    {
        AudioSource.PlayClipAtPoint(hit, transform.position);
    }
        
	
}
