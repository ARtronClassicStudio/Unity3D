using UnityEngine;


[CreateAssetMenu(fileName ="Value",menuName ="Create Data",order =1)]
[System.Serializable]
public  class Value : ScriptableObject
{
    public  int click;
    public  Color color;
    public  int Finish = 100;

}
