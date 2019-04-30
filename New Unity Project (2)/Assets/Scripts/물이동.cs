using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 물이동 : MonoBehaviour
{
    public GameObject 물;
    public GameObject 물프리팹;
    private GameObject 부모;
    private GameObject go;
    private bool 프리팹생성;

    void Start()
    {
        프리팹생성 = false;
    }

    // Update is called once per frame
    void Update()
    {
        물.GetComponent<Transform>().position = new Vector2(물.GetComponent<Transform>().position.x, 물.GetComponent<Transform>().position.y - 0.01f);
        if(프리팹생성 == false && 물.GetComponent<Transform>().localPosition.y < 0)
        {
            프리팹생성 = true;
            go = Instantiate(물프리팹, GameObject.Find("Canvas").GetComponent<Transform>());
            go.GetComponent<Transform>().SetAsFirstSibling();
        }
        if(프리팹생성 == true && 물.GetComponent<Transform>().localPosition.y < -1280)
        {
            Destroy(물);
        }
    }
}
