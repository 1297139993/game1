using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour {
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool dead;
    public GameObject born;
    public bool isDefeat;
    public Text PlayerScore;
    public Text PlayerLifeValue;
    public GameObject isDefeatUI;
    private static PlayManager instance;

    public static PlayManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnMainMenu", 2);
            
        }
        if (dead)
        {
            Recover();
        }
        PlayerScore.text = playerScore.ToString();
        PlayerLifeValue.text = lifeValue.ToString();
    }
    private void Recover()
    {
        if (lifeValue<=0)
        {
            isDefeat = true;
            Invoke("ReturnMainMenu", 2);
            //游戏失败返回界面
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            dead = false;
        }
    }
    private void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
