using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 문제출제 : MonoBehaviour
{
    public GameObject 배경;
    public Text 퀴즈;
    public Text 답1;
    public Text 답2;
    private Text 시간;
    private bool 정답방향;
    private System.Random rd;
    private bool 정답체크;

    private int num1;
    private int num2;
    private int ans;

    void Start()
    {
        정답체크 = false;
        정답방향 = false;
        rd = new System.Random((int)DateTime.Now.Ticks);
        시간 = GameObject.Find("Canvas/시간").GetComponent<Text>();

        num1 = rd.Next(10);
        num2 = rd.Next(10);
        ans = num1 + num2;

        퀴즈.text = num1 + " + " + num2 + " = ?";

        if (rd.Next(2) == 1)
        {
            답1.text = ans.ToString();
            답2.text = rd.Next(20).ToString();
            정답방향 = false;
        }
        else
        {
            답2.text = ans.ToString();
            답1.text = rd.Next(20).ToString();
            정답방향 = true;
        }
    }

    void Update()
    {
        if(배경.GetComponent<Transform>().localPosition.y < -550)
        {
            if(정답방향 == 전역변수.방향)
            {
                Debug.Log("정답!");
            }
            else
            {
                Debug.Log("오답!");
            }
        }
    }
}