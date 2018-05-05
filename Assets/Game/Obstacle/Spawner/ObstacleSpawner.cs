using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const char _block = '1';
    private const char _empty = '0';

    [SerializeField]
    private GameObject _obstacle;
    [SerializeField]
    private GameObject _spawnLocation;
    [SerializeField]
    private int _columns;
    [SerializeField]
    private float _columnSeparation;
    [SerializeField]
    private float _rowSeparation;
    [SerializeField]
    private float _delay;
    [SerializeField]
    private TextAsset[] _patterns;
    [SerializeField]
    
    private GameObject[] _spawnLocations;

    // Use this for initialization
    void Start()
    {
        CreateSpawnLocations();

        SpawnPattern(_patterns.First());
        //StartCoroutine(SpawnObstacles());
    }

    private void CreateSpawnLocations()
    {
        _spawnLocations = new GameObject[_columns];
        // The furthest left position for a column to exist
        var limit = -(_columns * _columnSeparation) / 2;

        for (int i = 0; i < _columns; i++)
        {
            var location = Instantiate(_spawnLocation, transform);
            location.transform
                .Translate(new Vector3
                {
                    x = limit + _columnSeparation * i
                });

            _spawnLocations[i] = location;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnPattern(TextAsset pattern)
    {
        var lines = pattern.text
            .Split('\n')
            .Select(s => s.Trim('\r'));

        float rowPosition = 0;
        foreach (var line in lines)
        {
            rowPosition += _rowSeparation;
            if (line.Length != _columns)
                throw new Exception();
            
            for (int i = 0; i < _columns; i++)
            {
                if (line[i] == _block)
                {
                    var location = _spawnLocations[i];
                    var obstacle = Instantiate(_obstacle, location.transform);
                    obstacle.transform.Translate(new Vector3 { z = rowPosition });
                }
            }
        }
    }

    private IEnumerator SpawnObstacles()
    {
        var count = 10;

        for (int i = 0; i < count; i++)
        {
            foreach (var location in _spawnLocations)
            {
                Instantiate(_obstacle, location.transform.position, location.transform.rotation);
            }
            yield return new WaitForSeconds(_delay);
        }
    }
}
