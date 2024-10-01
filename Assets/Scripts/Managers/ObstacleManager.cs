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
            // ���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִ��� Ȯ���մϴ�.
            
            
            while (obstacles[random].activeSelf == true)
            {
                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if (ExamineActive() == true)
                {
                    GameObject clone = ResourcesManager.Instance.Instantiate("Corn", gameObject.transform);
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                // ���� ����Ʈ�� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������ random ������ ���� +1 �ؼ� �ٽ� �˻� �մϴ�.
                random = (random + 1) % obstacles.Count;
            }
            // �������� ������ Obstacle ������Ʈ�� Ȱ��ȭ�մϴ�.
            obstacles[random].SetActive(true);
        }
    }
}
