using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public Image startImg;
    float alfa;
    bool flag_a;

    void Start()
    {
        alfa = 0;
        //print(flag_G);
    }

    void Update()
    {
        //スプライトの透明度を変更する
        startImg.color = new Color(255, 255, 255, alfa);

        if (flag_a)
            alfa -= Time.deltaTime;
        else
            alfa += Time.deltaTime;

        if (alfa < 0)
        {
            alfa = 0;
            flag_a = false;
        }
        else if (alfa > 1)
        {
            alfa = 1;
            flag_a = true;
        }
    }
}
