using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 나쁜아이템 : MonoBehaviour
{
    public GameObject 아이템;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        아이템.GetComponent<Transform>().localPosition = new Vector2(아이템.GetComponent<Transform>().localPosition.x, 아이템.GetComponent<Transform>().localPosition.y - 5f);
        if (아이템.GetComponent<Transform>().localPosition.y < -200 && 아이템.GetComponent<Transform>().localPosition.y > -500)
        {
            if (아이템.name.Split('_')[0].Equals("L") && 전역변수.방향 == false)
            {
                전역변수.HP--;
                Destroy(아이템);
            }
            else if (아이템.name.Split('_')[0].Equals("R") && 전역변수.방향 == true)
            {
                전역변수.HP--;
                Destroy(아이템);
            }
        }
        else if (아이템.GetComponent<Transform>().localPosition.y < -700)
        {
            Debug.Log("뱉어냄");
            Destroy(아이템);
        }
    }
}
