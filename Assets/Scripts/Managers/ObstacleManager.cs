using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject prefab;

    [SerializeField] int creatCount = 5;
    void Start()
    {
        obstacles.Capacity = 10;
        Creat();
    }
    public void Creat()
    {
        for(int i = 0; i < creatCount; i++)
        {
            prefab = ResourcesManager.Instance.Instantiate("Corn", gameObject.transform);
            prefab.SetActive(false);
            obstacles.Add (prefab);
        }
    }
}
