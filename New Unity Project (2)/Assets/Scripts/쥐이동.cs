using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 쥐이동 : MonoBehaviour
{
    public GameObject 쥐;
    public void 왼쪽클릭()
    {
        쥐.GetComponent<Transform>().localPosition = new Vector2(-180, 쥐.GetComponent<Transform>().localPosition.y);
        전역변수.방향 = false;
        Debug.Log("왼쪽");
    }
    
    public void 오른쪽클릭()
    {
        쥐.GetComponent<Transform>().localPosition = new Vector2(180, 쥐.GetComponent<Transform>().localPosition.y);
        전역변수.방향 = true;
        Debug.Log("오른쪽");
    }
}
