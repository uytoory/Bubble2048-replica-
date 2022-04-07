using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 25;
    [SerializeField] private float _maxsXPosition = 2.5f;

    private float _xPosition;
    private float _oldMouseX;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _oldMouseX = Input.mousePosition.x;
        }

        if(Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - _oldMouseX;
            _oldMouseX = Input.mousePosition.x;
            _xPosition += delta * _sensitivity / Screen.width;
            _xPosition = Mathf.Clamp(_xPosition, -_maxsXPosition, _maxsXPosition);
            transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
        }
    }
}
