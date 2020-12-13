using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject _transition, _otherDoor;
    private Transform _player, _canvas;
    private Transition _fade;

    private Vector3 _otherDoorPos;
    private float _setPlayerHight;
    private bool _doorIsUsed;

    private void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("GameController").transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _setPlayerHight = _player.position.y;
        _otherDoorPos = _otherDoor.transform.position;
        _otherDoorPos.y -= Mathf.Abs(_setPlayerHight);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _doorIsUsed)
        {
            StartCoroutine(UsingDoor());
            _doorIsUsed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _doorIsUsed = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _doorIsUsed = false;
    }
    IEnumerator UsingDoor()
    {
        GameObject fade = Instantiate(_transition, _canvas);
        _fade = fade.GetComponent<Transition>();

        yield return new WaitUntil(() => _fade._stop == true);

        _player.position = _otherDoorPos;
    }
}