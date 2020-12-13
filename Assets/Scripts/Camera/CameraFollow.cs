using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform _target;
    [Range(-5, 5)] public float _frontView, _upPosition;
    [Range(0, 5)] public float _speed;
    private float _camZPos;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _camZPos = transform.position.z;
    }
    private void FixedUpdate()
    {
        float newPos = _target.position.x + (_frontView * _target.localScale.x);
        float horizontal = Mathf.Lerp(transform.position.x, newPos, _speed * Time.deltaTime);
        Vector3 camMoves = new Vector3(horizontal, _target.position.y + _upPosition, _camZPos);
        transform.position = camMoves;
    }
}