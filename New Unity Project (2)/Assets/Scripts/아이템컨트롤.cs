using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 아이템컨트롤 : MonoBehaviour
{
    public GameObject[] 아이템;
    private GameObject[] 필드아이템;
    public Text 시간;
    private int i;
    private System.Random rd;
    private int j;
    public GameObject 부모;
    // Start is called before the first frame update
    void Start()
    {
        rd = new System.Random((int)DateTime.Now.Ticks);
        필드아이템 = new GameObject[2];
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Convert.ToInt32(시간.text) == 2 && i == 0)
        {
            i++;
            필드아이템[0] = Instantiate(아이템[rd.Next(4)], 부모.GetComponent<Transform>());
            if (필드아이템[0].name.Split('_')[1].Equals("Bad(Clone)"))
            {
                if (rd.Next(2) == 0)
                    필드아이템[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("can");
                else
                    필드아이템[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("wood");
            }
            else if (필드아이템[0].name.Split('_')[1].Equals("Good(Clone)"))
            {
                if (rd.Next(2) == 0)
                    필드아이템[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("ham");
                else
                    필드아이템[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("cheese");
            }
            else
            {
                Debug.Log(필드아이템[0].name.Split('_')[1]);
                Debug.Log("망함");
            }
        }
        else if (Convert.ToInt32(시간.text) == 5 && i == 1)
        {
            i = 0;
            필드아이템[1] = Instantiate(아이템[rd.Next(4)], 부모.GetComponent<Transform>());
            if (필드아이템[1].name.Split('_')[1].Equals("Bad(Clone)"))
            {
                if (rd.Next(2) == 0)
                    필드아이템[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("can");
                else
                    필드아이템[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("wood");
            }
            else if (필드아이템[1].name.Split('_')[1].Equals("Good(Clone)"))
            {
                if (rd.Next(2) == 0)
                    필드아이템[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("ham");
                else
                    필드아이템[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("cheese");
            }
            else
            {
                Debug.Log(필드아이템[1].name.Split('_')[1]);
                Debug.Log("망함");
            }
        }
    }
}
