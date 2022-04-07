using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : PassiveItem
{
    [Range(0,2)] public int Health = 1;
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject _breakEffectPrefab;
    [SerializeField] private Animator _animator;


    void Start()
    {
        SetHealth(Health);
    }

    [ContextMenu("OnAffect")]
    public override void OnAffect()
    {
        base.OnAffect();
        Health -= 1;
        Instantiate(_breakEffectPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        _animator.SetTrigger("Shake");
        if(Health <0)
        {
            Die();
        }
        else
        {
            SetHealth(Health);
        }
    }

    void SetHealth(int value)
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].SetActive(i <= value);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(ItemType, transform.position);
    }
}
