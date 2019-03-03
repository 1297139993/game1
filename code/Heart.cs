using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour {
    private SpriteRenderer sr;
    public Sprite heart;
    public GameObject Explosion;
    public AudioClip dieAudio;
    
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Die()
    {
        sr.sprite = heart;
        Instantiate(Explosion, transform.position, transform.rotation);
        PlayManager.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
        

    }
}
