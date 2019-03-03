using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float movespeed = 10;
    public bool PlayerBullet;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * movespeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "tank":
                if (!PlayerBullet)
                {
                    collision.SendMessage("Die");
                }
                break;
            case "barrier":
                Destroy(gameObject);
                if (PlayerBullet)
                {
                    collision.SendMessage("hitAudio");
                }
                break;
            case "heart":
                collision.SendMessage("Die");
                
                break;
            case "wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "enemy":
                if (PlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                
                break;
        }
    }
}
