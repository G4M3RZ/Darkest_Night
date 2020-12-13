using UnityEngine;

public class Notas : MonoBehaviour
{
    public string _texto;
    private MostrarTextos _textComponent;

    private void Awake()
    {
        _textComponent = GameObject.FindGameObjectWithTag("GameController").GetComponent<MostrarTextos>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _textComponent._message = _texto;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _textComponent._message = null;
    }
}