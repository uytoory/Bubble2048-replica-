using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{
    public ItemType ItemType;
    public GameObject FlyingIconPrefab;
    public int CurrentScore;    
    public Transform IconTransform;    
    public int Level;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AnimationCurve _scaleCurve;

    // Добавить один Item к счету
    [ContextMenu("AddOne")]
    public void AddOne()
    {
        CurrentScore--;
        if(CurrentScore < 0)
        {
            CurrentScore = 0;
        }
        _text.text = CurrentScore.ToString();
        //Запустить анимацию изменения счета
        StartCoroutine(AddAnimation());
        //ScoreManager.Instance.CheckWin();
    }

    public virtual void Setup(Task task)
    {
        CurrentScore = task.Number;
        _text.text = task.Number.ToString();
    }

    IEnumerator AddAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime * 1.8f)
        {
            float scale = _scaleCurve.Evaluate(t);
            IconTransform.localScale = Vector3.one * scale;
            yield return null;
        }
        IconTransform.localScale = Vector3.one;
    }

}
