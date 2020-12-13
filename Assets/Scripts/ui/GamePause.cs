using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject _fadePrefab, _pauseView;
    private bool _pause;

    private void Awake()
    {
        #region Create Fade
        GameObject fade = Instantiate(_fadePrefab, transform);
        Fade fadeComponents = fade.GetComponent<Fade>();
        fadeComponents._isFirst = true;
        #endregion
    }
    void Update()
    {
        Puase();
    }
    void Puase()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _pause = !_pause;

        _pauseView.SetActive(_pause);

        if (!_pause)
        {    
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}