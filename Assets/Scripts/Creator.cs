using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Transform _tube;
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform _rayTransform;
    [SerializeField] private ActiveItem _ballPrefab;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TextMeshProUGUI _numberOfBallsText;
    
    private int _ballsLeft;
    private ActiveItem _itemInTube;
    private ActiveItem _itemInSpawner;

    void Start()
    {
        _ballsLeft = Level.Instance.NumberOfBalls;
        UpdateBallsLeftText();

        CreateItemInTube();
        StartCoroutine(nameof(MoveToSpawner));
    }

    public void UpdateBallsLeftText()
    {
        _numberOfBallsText.text = _ballsLeft.ToString();
    }

    // —оздаем новый м€ч в трубе
    void CreateItemInTube()
    {
        // Ќазначаем шару случайный уровень
        if(_ballsLeft == 0)
        {
            Debug.Log("balls ended");
            return;
        }
        int ItemLevel = Random.Range(0, 5);
        _itemInTube = Instantiate(_ballPrefab, _tube.position, Quaternion.identity);
        _itemInTube.SetLevel(ItemLevel);
        _itemInTube.SetupToTube();
        _ballsLeft--;
        UpdateBallsLeftText();
    }

    // ƒвижение м€ча из трубы до спавнера
    private IEnumerator MoveToSpawner()
    {
        _itemInTube.transform.parent = _spawner;
        for (float t = 0; t < 1f; t +=Time.deltaTime / 0.4f)
        {
            _itemInTube.transform.position = Vector3.Lerp(_tube.position, _spawner.position, t);
            yield return null;
        }
        _itemInTube.transform.localPosition = Vector3.zero;
        _itemInSpawner = _itemInTube;
        _rayTransform.gameObject.SetActive(true);
        _itemInSpawner.Projection.Show();
        _itemInTube = null;
        CreateItemInTube();
    }

    private void LateUpdate()
    {
        if(_itemInSpawner)
        {
            Ray ray = new Ray(_spawner.position, Vector3.down);
            RaycastHit hit;
            if (Physics.SphereCast(ray, _itemInSpawner.Radius,out hit, 100, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _rayTransform.localScale = new Vector3(_itemInSpawner.Radius * 2f, hit.distance, 1f);
                _itemInSpawner.Projection.SetPosition(_spawner.position + Vector3.down * hit.distance);
            }

            if(Input.GetMouseButtonUp(0))
            {
                Drop();
            }
        }
    }

    private Coroutine _waitForLose;

    void Drop()
    {
        _itemInSpawner.Drop();
        _itemInSpawner.Projection.Hide();
        // „тобы бросить м€ч только один раз обнул€ем его
        _itemInSpawner = null;
        _rayTransform.gameObject.SetActive(false);
        if(_itemInTube)
        {
            StartCoroutine(nameof(MoveToSpawner));
        }
        else
        {
            _waitForLose = StartCoroutine(nameof(WaitForLose));
            CollapseManager.Instance.OnCollapse.AddListener(ResetLoseTimer);
            GameManager.Instance.OnWIn.AddListener(StopWaitForLose);
        }
    }

    void ResetLoseTimer()
    {
        if(_waitForLose != null)
        {
            StopCoroutine(_waitForLose);
            _waitForLose = StartCoroutine(WaitForLose());
        }      
    }

    void StopWaitForLose()
    {
        if (_waitForLose != null)
        {
            StopCoroutine(_waitForLose);
        }
    }

    IEnumerator WaitForLose()
    {
        for (float t = 0; t < 5f; t += Time.deltaTime)
        {
            yield return null;
        }
        Debug.Log("Lose");
        GameManager.Instance.Lose();
    }
}
