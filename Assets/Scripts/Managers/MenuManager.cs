using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        //StartCoroutine(SceneryManager.AsyncLoad(1));
    }
    public void OnPointerEnter()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 75;
    }
    public void OffPointerEnter()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 50; 
    }
    public void Shop()
    {
        Debug.Log("Shop");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
