using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public List<GameObject> _startAndEnd;
    public List<GameObject> _world;

    private float _localXPos;
    
    private void Start()
    {
        Instantiate(_startAndEnd[0], transform);
        StartCoroutine("WorldBuilding", 0.01f);
    }

    IEnumerator WorldBuilding(float time)
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 newPos = new Vector3(_localXPos, 0, 0);
            GameObject _instance = Instantiate(_world[Random.Range(0,_world.Count)], transform);
            _instance.transform.position = newPos;

            _localXPos += 10.5f;

            yield return new WaitForSeconds(time);
        }
        Destroy(this);
    }
}