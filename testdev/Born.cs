using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {
    public GameObject Player;
    public GameObject[] Enemy;
    public bool createPlayer;
	// Use this for initialization
	void Start () {
        Invoke("BornTank",1.5f);
        Destroy(gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(Player, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(Enemy[num], transform.position, Quaternion.identity);
        }
    }
}
