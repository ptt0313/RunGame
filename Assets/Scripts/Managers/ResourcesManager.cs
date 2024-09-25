using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);

        if(prefab == null)
        {
            Debug.Log("Failed to load prefab" + path);
            return null;
        }

        GameObject clone = Object.Instantiate(prefab, parent);

        int index = prefab.name.IndexOf("(Clone)");

        if (index > 0)
        {
            prefab.name = prefab.name.Substring(0, index);
        }


        return clone;
    }
    public void Destroy(GameObject prefab)
    {
        if (prefab == null) return;
        Object.Destroy(prefab);
    }
}
