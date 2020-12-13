using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [HideInInspector]
    public bool _isFirst;
    private Image _panel;
    private Color _fadeColor;

    [HideInInspector] public string _sceneName;
    [Range(0,1)] public float _speed;

    private void Awake()
    {
        _panel = GetComponent<Image>();
        
        _fadeColor = Color.black;
        _fadeColor.a = (_isFirst) ? 1 : 0;
        _panel.color = _fadeColor;
    }

    private void Update()
    {
        float velocity = Time.deltaTime * _speed;
        _fadeColor.a = (_isFirst) ? _fadeColor.a -= velocity : _fadeColor.a += velocity;
        Mathf.Clamp(_fadeColor.a, 0, 1);
        _panel.color = _fadeColor;

        if (_fadeColor.a <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (_fadeColor.a >= 1)
        {
            if(_sceneName != null)
                SceneManager.LoadScene(_sceneName);
        }
    }
}