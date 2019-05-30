﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class wall : MonoBehaviour {

    public Text quizText;
    public Text AnswerText1;
    public Text AnswerText2;
    public Player player_script;
    public GameManager GM;
    int answer1 = 0;
    int answer2 = 0;
    int type;
    int qNum;

    string[] q = new string[]
{
            "골목을 뜻하는 제주도 사투리는?",
            "캐나다의 수도는?",
            "수도가 아닌 도시는?",
            "털어서 (  ) 안 나는 사람 없다.",
            "누난 나의 (  )"
};

    string[] ops = new string[]
    {
            "올레/둘레",
            "토론토/오타와",
            "시드니/델리",
            "먼지/각질",
            "VIP/MVP"
    };

    int[] ans = new int[]
    {
            1, 2, 1, 1, 2
    };

    const int CLEAR_SCORE = 5;

    // Use this for initialization
    void Start () {

        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        quizText = transform.GetChild(0).gameObject.GetComponent<Text>();
        AnswerText1 = transform.GetChild(1).gameObject.GetComponent<Text>();
        AnswerText2 = transform.GetChild(2).gameObject.GetComponent<Text>();

        int a = Random.Range(0, 10);
        int b = Random.Range(0, 10);
        int op = Random.Range(0, 3);
        type = Random.Range(0, 2);
        qNum = Random.Range(0, 5);

        if(type == 0)
        { // 산수
            AnswerText1.fontSize = 60;
            AnswerText2.fontSize = 60;
            quizText.fontSize = 60;

            switch (op)
            {
                case 0:
                    answer1 = a + b;
                    answer2 = Random.Range(2, 20);
                    quizText.text = a.ToString() + " + " + b.ToString() + " = ?";
                    break;
                case 1:
                    answer1 = a - b;
                    answer2 = Random.Range(-10, 10);
                    quizText.text = a.ToString() + " - " + b.ToString() + " = ?";
                    break;
                case 2:
                    answer1 = a * b;
                    answer2 = Random.Range(1, 20);
                    quizText.text = a.ToString() + " x " + b.ToString() + " = ?";
                    break;
            }
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                AnswerText1.text = answer1.ToString();
                AnswerText2.text = answer2.ToString();

            }
            else
            {
                AnswerText2.text = answer1.ToString();
                AnswerText1.text = answer2.ToString();
            }
        }
        else
        { // 산수 ㄴㄴ
            AnswerText1.fontSize = 30;
            AnswerText2.fontSize = 30;
            quizText.fontSize = 30;
            quizText.text = q[qNum].ToString();
            string[] str = ops[qNum].Split('/');
            AnswerText1.text = str[0].ToString();
            AnswerText2.text = str[1].ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Player")
        //{
        //    if (player_script.movePoint == 0)
        //    {
        //        if(System.Convert.ToInt32(AnswerText1.text) == answer1)
        //        {
        //            GM.Score++;
        //            if (GM.Score == CLEAR_SCORE)
        //            {
        //                GM.isGameClear = true;
        //            }
        //        }
        //        else
        //        {
        //            GM.isGameOver = true;
        //        }
        //    }
        //    else if (player_script.movePoint == 2)
        //    {
        //        if (System.Convert.ToInt32(AnswerText2.text) == answer1)
        //        {
        //            GM.Score++;
        //            if (GM.Score == CLEAR_SCORE)
        //            {
        //                GM.isGameClear = true;
        //            }
        //        }
        //        else
        //        {
        //            GM.isGameOver = true;
        //        }
        //    }
        //    else
        //    {
        //        GM.isGameOver = true;
        //    }
        //}

        if (other.tag == "Player")
        {
            if (player_script.movePoint == 0) // 왼쪽
            {
                if(type == 0)
                { // 산수 문제입니다..
                    if (System.Convert.ToInt32(AnswerText1.text) == answer1)
                    {
                        GM.Score++;
                        if (GM.Score == CLEAR_SCORE)
                        {
                            GM.isGameClear = true;
                        }
                    }
                    else
                    {
                        GM.isGameOver = true;
                    }
                }

                else
                { // 노산수 문제

                    if(ans[qNum] == 1)
                    { // 정답
                        GM.Score++;
                        if(GM.Score == CLEAR_SCORE)
                        {
                            GM.isGameClear = true;
                        }
                    }
                    else
                    {
                        GM.isGameOver = true;
                    }
                }

            }
            else if (player_script.movePoint == 2) // 오른쪽
            {
                                if(type == 0)
                { // 산수 문제입니다..
                    if (System.Convert.ToInt32(AnswerText2.text) == answer1)
                    {
                        GM.Score++;
                        if (GM.Score == CLEAR_SCORE)
                        {
                            GM.isGameClear = true;
                        }
                    }
                    else
                    {
                        GM.isGameOver = true;
                    }
                }

                else
                { // 노산수 문제
                    if (ans[qNum] == 2)
                    { // 정답
                        GM.Score++;
                        if(GM.Score == CLEAR_SCORE)
                        {
                            GM.isGameClear = true;
                        }
                    }
                    else
                    {
                        GM.isGameOver = true;
                    }
                }
            }
            else // 중간
            {
                GM.isGameOver = true;
            }
        }
    }
}
