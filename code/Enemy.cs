using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float movespeed = 3;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    private Vector3 bulleteulerAngles;
    private float timeVal ;
    public GameObject ExplosionPrefab;
    private float h=0;
    private float v=-1;
    private float timeValDirection=0;
   
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //gongji
        if (timeVal>=3.5)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (timeValDirection>=3.5f)
        {
            int num = Random.Range(0, 12);
            if (num>7)
            {
                h = 0;
                v = -1;
            }
            else if (num>4&&num<8)
            {
                h = 1;
                v = 0;
            }
            else if (num > 1 && num < 5)
            {
                h = -1;
                v = 0;
            }
            else if (num==0||num==1)
            {
                h = 0;
                v = 1;
            }
            timeValDirection = 0;
        }
        else
        {
            timeValDirection += Time.deltaTime;
        }
        transform.Translate(Vector3.right * h * movespeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulleteulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulleteulerAngles = new Vector3(0, 0, -90);
        }
        if (h != 0)
        {
            return;
        }
        
        transform.Translate(Vector3.up * v * movespeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulleteulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulleteulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void Attack()
    {
        
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bulleteulerAngles));
            timeVal = 0;
        
    }
    private void Die()
    {
        PlayManager.Instance.playerScore++;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
