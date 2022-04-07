using UnityEngine;


public class Ball : ActiveItem
{
    [SerializeField] private BallSettings _ballSettings;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _visualTransform;

    public override void SetLevel(int level)
    {
        base.SetLevel(level);
        _renderer.material = _ballSettings.BallMaterials[level];    

        Radius = Mathf.Lerp(0.4f, 0.7f, level / 10f);
        Vector3 ballScale = Vector3.one * Radius * 2f;
        _visualTransform.localScale = ballScale;
        _collider.radius = Radius;
        _trigger.radius = Radius;
        _trigger.radius = Radius + 0.1f;

        Projection.Setup(_ballSettings.BallProjectionMaterials[level], _levelText.text, Radius);

        if(ScoreManager.Instance.AddScore(ItemType, transform.position, level))
        {
            Die();
        }
        
    }

    public override void DoEffect()
    {
        base.DoEffect();
        IncreaseLevel();
    }
}