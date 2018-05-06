using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const char BLOCK = '1';
    private const char EMPTY = '0';

    [SerializeField]
    private GameObject _obstacle;
    [SerializeField]
    private GameObject _spawnLocation;
    // Spawned at the end of a pattern to help figure out when to spawn the next one
    [SerializeField]
    private GameObject _patternEnd;
    [SerializeField]
    private int _columns;
    [SerializeField]
    private float _columnSeparation;
    [SerializeField]
    private float _rowSeparation;
    [SerializeField]
    private float _nextPatternDelay;
    [SerializeField]
    private TextAsset[] _patterns;
    [SerializeField]
    private int _randomPatternRows;
    [SerializeField]
    private int _maxObstaclesInRandomRow;    
    
    private GameObject[] _spawnLocations;

    // Use this for initialization
    void Start()
    {
        if (_maxObstaclesInRandomRow < 1)
            throw new Exception();

        CreateSpawnLocations();
        SpawnPattern(_patterns.First());
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

    private IEnumerator SpawnNextPattern()
    {
        yield return new WaitForSeconds(_nextPatternDelay);

        var chanceOfRandomPattern = 0.2f;
        if (UnityEngine.Random.value < chanceOfRandomPattern)
        {

        }
        else
        {
            SpawnPattern(_patterns.First());
        }
    }
    private void SpawnPattern(TextAsset pattern)
    {
        var lines = pattern.text
            .Split('\n')
            .Select(s => s.Trim('\r'))
            .ToArray();

        var patternLength = lines.Length;

        float rowPosition = 0;
        for (int i = 0; i < patternLength; i++)
        {
            var line = lines[i];

            rowPosition += _rowSeparation;
            if (line.Length != _columns)
                throw new Exception();
            
            for (int j = 0; j < _columns; j++)
            {
                if (line[j] == BLOCK)
                {
                    var location = _spawnLocations[j];
                    var obstacle = Instantiate(_obstacle, location.transform);
                    obstacle.transform.Translate(new Vector3 { z = rowPosition });
                }
            }
        }

        var patternEnd = Instantiate(_patternEnd, transform);
        patternEnd.transform.Translate(new Vector3 { z = rowPosition });

        patternEnd.GetComponent<PatternEnd>()
            .PatternComplete
            .AddListener(() => StartCoroutine(SpawnNextPattern()));
    }

    private void SpawnRandomPattern()
    {
        for (int i = 0; i < _randomPatternRows; i++)
        {

        }
    }

    //private IEnumerator SpawnObstacles()
    //{
    //    var count = 10;

    //    for (int i = 0; i < count; i++)
    //    {
    //        foreach (var location in _spawnLocations)
    //        {
    //            Instantiate(_obstacle, location.transform.position, location.transform.rotation);
    //        }
    //        yield return new WaitForSeconds(_nextPatternDelay);
    //    }
    //}
    
}
