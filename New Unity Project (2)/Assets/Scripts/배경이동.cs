using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 배경이동 : MonoBehaviour
{
    public GameObject 배경;
    public GameObject 프리팹;
    public GameObject 부모;
    public Text 시간;
    public float time;

    void Start()
    {
        time = 0;
        시간.text = "0";
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Convert.ToInt32(시간.text) == 10)
        {
            배경.GetComponent<Transform>().localScale = new Vector2(배경.GetComponent<Transform>().localScale.x + 0.001f, 배경.GetComponent<Transform>().localScale.y + 0.001f);
            배경.GetComponent<Transform>().position = new Vector2(배경.GetComponent<Transform>().position.x, 배경.GetComponent<Transform>().position.y - 0.05f);
            if (배경.GetComponent<Transform>().position.y < -8)
            {
                시간.text = "0";
                time = 0;
                Destroy(배경);
                배경 = Instantiate(프리팹, 부모.GetComponent<Transform>());
                배경.GetComponent<Transform>().SetSiblingIndex(3);
            }
        }
        else
        {
            시간.text = (((int)(time * 10)) / 10).ToString();
        }
    }
}
