using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject prefab;

    [SerializeField] int creatCount = 5;
    [SerializeField] int random;
    void Start()
    {
        obstacles.Capacity = 10;
        Creat();
        StartCoroutine(ActiveObstacle());
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
    public bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }
    public IEnumerator ActiveObstacle()
    {
        while(true)
        {
            yield return CoroutinCache.waitForSecond(2.5f);
            random = Random.Range(0, obstacles.Count);
            // 현재 게임 오브젝트가 활성화 되어 있는지 확인합니다.
            
            
            while (obstacles[random].activeSelf == true)
            {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                if (ExamineActive() == true)
                {
                    GameObject clone = ResourcesManager.Instance.Instantiate("Corn", gameObject.transform);
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                // 현재 리스트에 있는 게임 오브젝트가 활성화되어 있으면 random 변수의 값을 +1 해서 다시 검색 합니다.
                random = (random + 1) % obstacles.Count;
            }
            // 랜덤으로 설정된 Obstacle 오브젝트를 활성화합니다.
            obstacles[random].SetActive(true);
        }
    }
}
