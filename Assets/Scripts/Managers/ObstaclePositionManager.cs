using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] Transform[] parentRoads;
    [SerializeField] ObstacleManager obstacleManager;
    [SerializeField] Transform[] PositionX;
    int index = -1;
    bool state = false;

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
        index = (index + 1) % parentRoads.Length;
        transform.SetParent(parentRoads[index]);
        transform.position += new Vector3(0, 0, 40);
        state = true;
    }
    IEnumerator SetPosition()
    {
        while (true)
        {
            if(state == false)
            {
                yield return null;
            }
            yield return CoroutinCache.waitForSecond(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0,randomPositionZ.Length)]);

            obstacleManager.GetObstacle().transform.position = transform.localPosition;

            obstacleManager.GetObstacle().transform.localPosition = PositionX[Random.Range(0,PositionX.Length)].localPosition;

            obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild((index + 1) % parentRoads.Length));

            obstacleManager.GetObstacle().SetActive(true);
        }
    }
}
