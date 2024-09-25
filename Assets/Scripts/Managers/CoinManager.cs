using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float offset = 2.5f;
    [SerializeField] int creatCount = 16;
    [SerializeField] List<GameObject> coins;
    [SerializeField] float positionX = 4.0f;

    void Start()
    {
        coins = new List<GameObject>();
        coins.Capacity = 20;
        Create();
    }
    public void Create()
    {
        for (int i = 0; i < creatCount; i++)
        {
            GameObject prefab = ResourcesManager.Instance.Instantiate("Coin");
            prefab.transform.SetParent(gameObject.transform);
            prefab.transform.localPosition = new Vector3(0, 0, offset * i);
            
            prefab.GetComponent<MeshRenderer>().enabled = false;
            prefab.GetComponent<BoxCollider>().enabled = false;
            coins.Add(prefab);
        }
    }
    public void InitializedPosition()
    {
        transform.localPosition = new Vector3(positionX * Random.Range(-1, 2), 0, 0);
        for(int i = 0;i < coins.Count;i++)
        {
            coins[i].GetComponent<MeshRenderer>().enabled = true;
            coins[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

}
