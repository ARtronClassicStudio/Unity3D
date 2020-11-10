//Мне не понравилось ваш "ТЗ" поэтому я начал делать по своему. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class LoadBundles
{
    public static AssetBundle bundle;
    public static Value value;
    public static Color setColor;
    public static Vector3 rotation;
    public static float speed = 0.5f;

}

public class PlayerClick : MonoBehaviour
{
    
    public GameObject press,textUI,finish;
    public Color test;
    public Text textClick,textfinish;
    public int RandomMesh;
    private int i;
    private bool act = true;
  
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        LoadBundles.value.Finish +=100;
        File.WriteAllText("Assets/SaveClick.json", JsonUtility.ToJson(LoadBundles.value));
    }

    void Start()
    {
        Time.timeScale = 1;
        if(LoadBundles.bundle == null)
        {
            LoadBundles.bundle = AssetBundle.LoadFromFile("Assets/Data/res");
            LoadBundles.value = LoadBundles.bundle.LoadAsset("Value") as Value;
        }
     
 

        InvokeRepeating("SaveClick",10,10);

        if (File.Exists("Assets/SaveClick.json"))
        {
            Debug.Log("Load Save Click!");
            JsonUtility.FromJsonOverwrite(File.ReadAllText("Assets/SaveClick.json"), LoadBundles.value);
        }
        else
        {
            Debug.Log("No Save!");
        }
    }

   void RandomLoad()
    {
        RandomMesh = Random.Range(0, 3);
       
        if(act){
            switch (RandomMesh)
            {

                case 0:
                    Instantiate(LoadBundles.bundle.LoadAsset("Mesh1") as GameObject);
                    act = false;
                   
                    break;
                case 1:
                    Instantiate(LoadBundles.bundle.LoadAsset("Mesh2") as GameObject);
                    act = false;
                    break;
                case 2:
                    Instantiate(LoadBundles.bundle.LoadAsset("Mesh3") as GameObject);
                    act = false;
                    break;
                case 3:
                    Instantiate(LoadBundles.bundle.LoadAsset("Mesh4") as GameObject);
                    act = false;
                    break;
            }
  
        }
    }

    void SaveClick()
    {
        Debug.Log("Avto Save Clik("+i.ToString()+")");
        i++;
        File.WriteAllText("Assets/SaveClick.json", JsonUtility.ToJson(LoadBundles.value));
    }
    
    void Update()
    {
        if(LoadBundles.value.click >= LoadBundles.value.Finish)
        {
            finish.SetActive(true);
            textfinish.GetComponent<Text>().text = "Level completed, your clicks:"+LoadBundles.value.click.ToString();
            Time.timeScale = 0;

        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RandomLoad();
                textUI.SetActive(true);
                press.SetActive(false);

                if (Physics.Raycast(ray, out hit, 100))
                {
                    var point = Instantiate(LoadBundles.bundle.LoadAsset("NewTextHD") as GameObject);
                    point.transform.position = hit.point;
                    LoadBundles.value.click++;
                    LoadBundles.value.color = Random.ColorHSV();
                    LoadBundles.setColor = LoadBundles.value.color;
                    LoadBundles.rotation = Random.rotation.eulerAngles * Time.deltaTime * LoadBundles.speed;
                }
            }
        }

        if (LoadBundles.value)
        {
            textClick.text = "Click:" + LoadBundles.value.click.ToString();

        }


    }
}
