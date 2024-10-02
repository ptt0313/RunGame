using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] Transform[] roads;
    int index = -1;

    [SerializeField] float[] randomPositionZ = new float[16];
    private void Awake()
    {
        for(int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f + -10.0f;
        }
    }
    private void Start()
    {
        StartCoroutine(SetPosition());
    }
    public void InitializePosition()
    {
        index = (index + 1) % roads.Length;
        transform.SetParent(roads[index]);
        transform.position += new Vector3(0, 0, 40);
    }
    IEnumerator SetPosition()
    {
        while (true)
        {
            yield return CoroutinCache.waitForSecond(2.5f);
            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0,randomPositionZ.Length)]);
        }
    }
}
