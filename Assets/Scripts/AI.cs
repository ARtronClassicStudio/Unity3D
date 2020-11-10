using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AI : MonoBehaviour
{



    void Start()
    {
   
          InvokeRepeating("RandomTo",0,5);
    }


    private void Update()
    {
     GetComponent<MeshRenderer>().material.color = LoadBundles.setColor;
     transform.Rotate(LoadBundles.rotation);
    }

    void RandomTo()
    {
        GetComponent<MeshRenderer>().material.color = LoadBundles.setColor;
        LoadBundles.setColor = Random.ColorHSV();
        LoadBundles.rotation = Random.rotation.eulerAngles * Time.deltaTime * LoadBundles.speed;
        
    }


}
