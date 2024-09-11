using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] Image screenImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(AsyncLoad(1));
    }
    public IEnumerator FadeIn()
    {
        screenImage.gameObject.SetActive(true);
        Color color = screenImage.color;
        color.a = 1f;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime;
            screenImage.color = color;
            if(color.a <= 0)
            {
                screenImage.gameObject.SetActive(false);
            }
        }
        yield return null;
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded");
        StartCoroutine(FadeIn());
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }
    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        // <asyncOperation.allowSceneActivation>
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� �����Դϴ�.
        Color color = screenImage.color;
        color.a = 0;

        // <asyncOperation.isDone>
        // �ش� ������ �Ϸ�Ǿ������� ��Ÿ���� �����Դϴ�.(�б�����)
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // �۾��� ���� ���¸� ��Ÿ���� �����Դϴ�.(�б�����)
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log("log");
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;
                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;
                    Debug.Log("SceneLoad");
                    yield break;
                }
            }
            
            yield return null;
        }
        
    }
}
