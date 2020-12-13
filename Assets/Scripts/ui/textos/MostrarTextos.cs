using System.Collections;
using UnityEngine;
using TMPro;

public class MostrarTextos : MonoBehaviour
{
    public TextMeshProUGUI _texto;
    [HideInInspector] public string _message;
    [Range(0, 0.1f)] public float _normalSpeed, _highSpeed;

    private float _speed;
    private bool _stoped;

    private void Awake()
    {
        StopText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_speed == 0 && _message != null)
            {
                StartCoroutine(mostrarTexto(_message));
            }
            else if(_speed == _normalSpeed && !_stoped)
            {
                _speed = _highSpeed;
            }
            else if (_stoped)
            {
                StopText();
            }
        }
    }

    void StopText()
    {
        _texto.text = "";
        _speed = 0;
        _stoped = false;
    }

    IEnumerator mostrarTexto(string texto)
    {
        _texto.text = "";
        _speed = _normalSpeed;
        for (int i = 0; i < texto.Length; i++)
        {
            _texto.text = _texto.text + texto[i];
            yield return new WaitForSeconds(_speed);
        }
        _stoped = true;
    }
}