using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAlpha : MonoBehaviour
{
    public bool UseAlphaAnimation;
    public bool On, Off, OnDestroy;
    [Range(0, 5)]
    public int Speed;
    [Range(0, 1)]
    public float Alpha = 0;
    private TextMesh text;



    private void Start()
    {
        text = GetComponent<TextMesh>();

    }

    private void Update()
    {
        Alpha = Mathf.Clamp(Alpha, 0, 5);
        text.color = new Color(text.color.r, text.color.g, text.color.b, Alpha);


        if (UseAlphaAnimation)
        {
            if (OnDestroy)
            {
                if (On)
                {

                    Alpha += Time.deltaTime * Speed;
                    if (Alpha >= 1)
                    {
                        On = false;
                        Off = true;
                    }
                }

                if (Off)
                {
                    Alpha -= Time.deltaTime * Speed;
                    if (Alpha <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                if (On)
                {
                    Alpha += Time.deltaTime * Speed;
                    if (Alpha >= 1)
                    {
                        On = false;
                    }
                }

                if (Off)
                {
                    Alpha -= Time.deltaTime * Speed;
                    if (Alpha <= 0)
                    {
                        Off = false;
                    }
                }
            }
        }
    }


}
