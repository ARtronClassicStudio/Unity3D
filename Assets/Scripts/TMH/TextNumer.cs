using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class TextNumer : MonoBehaviour
{
    public bool UseNumerText,UseNumerTextPlusMinus;
    public bool UsePlus, UseMinus;
    public int Number;
    private TextMesh text;



    private void Start()
    {
        text = GetComponent<TextMesh>();

    }

    private void Update()
    {
        if (UseNumerText)
        {
            UseNumerTextPlusMinus = false;


            text.text = Number.ToString();

        }


        if (UseNumerTextPlusMinus)
        {
            UseNumerText = false;

            if (UsePlus)
            {

                text.text = "+" + Number.ToString();
            }


            if (UseMinus)
            {

                text.text = "-" + Number.ToString();
            }
        }

    }

}
