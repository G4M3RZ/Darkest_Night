using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    private Image _panel;
    private Color _fadeColor;
    [Range(0, 5)] public float _speed;
    [HideInInspector] public bool _stop;

    private void Awake()
    {
        _panel = GetComponent<Image>();

        _fadeColor = Color.black;
        _fadeColor.a = 0;
        _panel.color = _fadeColor;
    }

    private void Update()
    {
        float velocity = Time.deltaTime * _speed;
        _panel.color = _fadeColor;

        if (!_stop)
        {
            _fadeColor.a = (_fadeColor.a < 1) ? _fadeColor.a += velocity : _fadeColor.a = 1;
            if (_fadeColor.a == 1)
                _stop = true;
        }
        else
        {
            _fadeColor.a = (_fadeColor.a > 0) ? _fadeColor.a -= velocity : _fadeColor.a = 0;
            if (_fadeColor.a == 0)
                Destroy(this.gameObject);
        }
    }
}