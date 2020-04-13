using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPanel : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("1");
        var btns = GetComponentsInChildren<Button>();
        for(int i=0;i<btns.Length;++i)
        {
            //法一：可自动注册，但是无法区分点击的是哪个按钮。
            //btns[i].onClick.AddListener(OnBtnClick);
            //法二：创建一个内部index变量，这部分内存需要随着回调传递。
            int index = i;
            btns[i].onClick.AddListener(() =>
            {
                OnButtonClick(index);
            });
        }
    }

    private void Start()
    {
        Debug.Log(2);
    }

    public void OnBtnClick()
    {
        Debug.Log("btn click");
    }

    public void OnButtonClick(int index)
    {
        Debug.Log("button click:" + index);
    }
}
