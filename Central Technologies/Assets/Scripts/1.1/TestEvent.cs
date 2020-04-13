 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEvent : MonoBehaviour
{
    public Button m_btn;
    public Toggle m_toggle;
    public Slider m_slider;

    // Start is called before the first frame update
    void Start()
    {
        m_btn.onClick.AddListener(OnBtnClick);
        m_toggle.onValueChanged.AddListener(OnToggleChange);
        m_slider.onValueChanged.AddListener(OnSliderChange);
    }

    public void OnBtnClick()
    {
        Debug.Log("Btn Click");
    }

    public void OnToggleChange(bool isOn)
    {
        Debug.Log("Toggle change:"+isOn);
    }

    public void OnSliderChange(float rate)
    {
        Debug.Log("Slider change:" + rate);
    }

}
