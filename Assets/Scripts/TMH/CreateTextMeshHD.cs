#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;


public class CreateTextMeshHD : MonoBehaviour
{

    [MenuItem("GameObject/3D Object/3D Text HD")]
    static void Spawn()
    {
        var text = new GameObject("New Text HD");
        text.AddComponent<TextMesh>().characterSize = 0.01f;
        text.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
        text.GetComponent<TextMesh>().fontSize = 500;
        text.GetComponent<TextMesh>().text = "Hello World!";
        text.AddComponent<TextNumer>();
        text.AddComponent<TextAlpha>();
        
    }
}
#endif