using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        fill -= Time.deltaTime * 0.01f;
        bar.fillAmount = fill;
    }
}
