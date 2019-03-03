using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float movespeed = 3;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    private Vector3 bulleteulerAngles;
    private float timeVal = 2;
    public GameObject ExplosionPrefab;
    public bool Defended=true;
    public float ShieldTime = 3;
    public GameObject Shield;
    public AudioSource moveAudio;
    public AudioClip[] tankAudio;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Defended)
        {
            ShieldTime -= Time.deltaTime;
            Shield.SetActive(true);
            if (ShieldTime<=0)
            {
                Defended = false;
                Shield.SetActive(false);
            }
        }
        //gongji
        
    }
    private void FixedUpdate()
    {
        if (PlayManager.Instance.isDefeat)
        {
            return;
        }
        if (timeVal >= 0.5f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
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
        
        if (Mathf.Abs(h)>0.05f)
        {
            moveAudio.clip = tankAudio[1];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        if (h != 0)
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
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
        if (v!=0)
        {
            moveAudio.clip = tankAudio[1];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudio[0];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bulleteulerAngles));
            timeVal = 0;
        }
    }
    private void Die()//坦克死亡方法
    {
        if (Defended)
        {
            return;
        }
        
        PlayManager.Instance.dead = true;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
