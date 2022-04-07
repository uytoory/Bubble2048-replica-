using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Level Level;
    // �������
    public ScoreElement[] ScoreElementPrefabs;
    // ��������� ��������
    public ScoreElement[] ScoreElements;
    public Transform ItemScoreParent;
    [SerializeField] private Camera _camera;

    public static ScoreManager Instance;

    private void Awake()
    {
        if(Instance  == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ScoreElements = new ScoreElement[Level.Tasks.Length];
        // ���������� �� ���� �������  ������
        for (int TaskIndex = 0; TaskIndex < Level.Tasks.Length; TaskIndex++)
        {
            // ������
            Task task = Level.Tasks[TaskIndex];
            // ��� �������, ������� ���� �������
            ItemType itemType = task.ItemType;
            // ���� ������, ������� ������������� �����  ��������
            for (int i = 0; i < ScoreElementPrefabs.Length; i++)
            {
                if(itemType  == ScoreElementPrefabs[i].ItemType)
                {
                    // ������� ����� ScoreElement
                    ScoreElement newScoreElement = Instantiate(ScoreElementPrefabs[i], ItemScoreParent);
                    newScoreElement.Setup(task); //task.Level, this
                    // ��������� ScoreElement � ������
                    ScoreElements[TaskIndex] = newScoreElement;
                }
            }
        }
    }

    public bool AddScore(ItemType itemType, Vector3 position, int level = 0)
    {
        for (int i = 0; i < ScoreElements.Length; i++)
        {
            if (ScoreElements[i].ItemType != itemType) continue;
            if (ScoreElements[i].CurrentScore == 0) continue;
            if (ScoreElements[i].Level != level) continue;

            StartCoroutine(AddScoreAnimation(ScoreElements[i], position));
            return true;
        }
        return false;
    }

    IEnumerator AddScoreAnimation(ScoreElement scoreElement, Vector3 position)
    {
        GameObject icon = Instantiate(scoreElement.FlyingIconPrefab, position, Quaternion.identity);
        Vector3 a = position;
        Vector3 b = position + Vector3.back * 6.5f + Vector3.down * 5f;
        Vector3 screenPoisiton = new Vector3(scoreElement.IconTransform.position.x, scoreElement.IconTransform.position.y, -_camera.transform.position.z);
        Vector3 d = _camera.ScreenToWorldPoint(screenPoisiton);
        Vector3 c = d + Vector3.back * 6f;

        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            icon.transform.position = Bezier.GetPoint(a, b, c, d, t);
            yield return null;
        }
        Destroy(icon.gameObject);
        scoreElement.AddOne();

        //��������� ������� ������
        CheckWin();
    }

    public void CheckWin()
    {
        for (int i = 0; i < ScoreElements.Length; i++)
        {
            if(ScoreElements[i].CurrentScore != 0)
            {
                return;
            }
        }
        GameManager.Instance.Win();
    }
}
