using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject SpawnEnemy;
    [SerializeField] private Transform _path;
    [SerializeField] private float _waitTime;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        var time = new WaitForSeconds(_waitTime);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(SpawnEnemy, new Vector3(_points[i].position.x, _points[i].position.y, 0), Quaternion.identity);
            yield return time;
        }
    }
}
