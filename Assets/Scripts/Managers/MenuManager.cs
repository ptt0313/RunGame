using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void OnPointerEnter()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 85;
    }
    public void OffPointerEnter()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 50;
    }
    public void Execute()
    {
        EventManager.Publish(EventType.START);
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
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
