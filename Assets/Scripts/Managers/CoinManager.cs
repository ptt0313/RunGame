using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float offset = 2.5f;
    [SerializeField] int creatCount = 16;
    

    void Start()
    {
        Create();
    }
    public void Create()
    {
        for (int i = 0; i < creatCount; i++)
        {
            prefab = Instantiate(prefab);
            prefab.transform.SetParent(gameObject.transform);
            prefab.transform.localPosition = new Vector3(0, 0, offset * i);

        }
    }

}
