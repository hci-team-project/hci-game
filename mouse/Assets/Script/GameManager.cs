using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    AudioSource bgm1;
    AudioSource bgm2;
    AudioSource bgm3;
    AudioSource mouseSound;

    public GameObject Wall;

    public GameObject waterFlow;
    public GameObject GameStartObj;
    public GameObject GameOverObj;
    public GameObject GameClearObj;

    public bool GameStart = false;
    public bool isGameOver = false;
    public bool isGameClear = false;

    public Text ScoreText;
    public int Score = 0;

    // Use this for initialization
    void Start () {
        bgm1 = GameObject.Find("creepybgm").GetComponent<AudioSource>();
        bgm2 = GameObject.Find("ticking").GetComponent<AudioSource>();
        bgm3 = GameObject.Find("clear").GetComponent<AudioSource>();
        mouseSound = GameObject.Find("mousesound").GetComponent<AudioSource>();

        GameStartObj.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine("flow");
        StartCoroutine("wall");
    }

    // Update is called once per frame
    void Update () {
        ScoreText.text = Score.ToString();

        if(isGameOver == true)
        {
            Time.timeScale = 0f;
            GameOverObj.SetActive(true);
            bgm1.Stop();
            bgm2.Stop();
            bgm3.Stop();
            mouseSound.Play();
        }

        if(isGameClear == true)
        {
            Time.timeScale = 0f;
            GameClearObj.SetActive(true);
            bgm3.Play();
            bgm1.Stop();
            bgm2.Stop();
        }
    }

    IEnumerator flow()
    {
        Instantiate(waterFlow, waterFlow.transform.position, waterFlow.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("flow");
    }
    IEnumerator wall()
    {
        Instantiate(Wall, Wall.transform.position, Wall.transform.rotation);
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        StartCoroutine("wall");
    }
    public void StartBt()
    {
        GameStart = false;
        Time.timeScale = 1f;
        GameStartObj.SetActive(false);
        bgm1.Play();
        bgm2.Play();
    }
    public void ReStartBt()
    {
        SceneManager.LoadScene("main");
    }
}
