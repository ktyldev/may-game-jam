using Extensions;
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
    private float _baseRowSeparation;
    private float RowSeparation { get { return _baseRowSeparation * _ship.SpeedMultiplier; } }

    [SerializeField]
    private float _nextPatternDelay;
    [SerializeField]
    private TextAsset[] _patterns;
    [SerializeField]
    private int _randomPatternRows;
    [SerializeField]
    private int _maxObstaclesInRandomRow;
    [SerializeField]
    [Range(0, 1)]
    private float _chanceOfRandomPattern;
    
    private GameObject[] _spawnLocations;
    private ShipMovement _ship;

    private void Awake()
    {
        _ship = this.Find<ShipMovement>(GameTags.Player);
    }

    // Use this for initialization
    void Start()
    {
        if (_maxObstaclesInRandomRow < 1)
            throw new Exception();

        CreateSpawnLocations();
        StartCoroutine(SpawnNextPattern());
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
        
        if (UnityEngine.Random.value < _chanceOfRandomPattern)
        {
            SpawnRandomPattern();
        }
        else
        {
            var r = UnityEngine.Random.Range(0, _patterns.Length);
            SpawnPattern(_patterns[r]);
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

            rowPosition += RowSeparation;
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
            .AddListener(() =>
            {
                if (!gameObject.activeInHierarchy)
                    return;

                StartCoroutine(SpawnNextPattern());
            });
    }

    private void SpawnRandomPattern()
    {
        float rowPosition = 0;
        for (int i = 0; i < _randomPatternRows; i++)
        {
            rowPosition += RowSeparation;

            var obstaclesInRow = UnityEngine.Random.Range(0, _maxObstaclesInRandomRow) + 1;

            var positions = new int[obstaclesInRow];
            for (int j = 0; j < obstaclesInRow; j++)
            {
                int col;
                do
                {
                    col = UnityEngine.Random.Range(0, _columns);
                }
                while (positions.Contains(col));

                positions[j] = col;
            }

            foreach (var pos in positions)
            {
                var location = _spawnLocations[pos];
                var obstacle = Instantiate(_obstacle, location.transform);
                obstacle.transform.Translate(new Vector3 { z = rowPosition });
            }
        }

        var patternEnd = Instantiate(_patternEnd, transform);
        patternEnd.transform.Translate(new Vector3 { z = rowPosition });

        patternEnd.GetComponent<PatternEnd>()
            .PatternComplete
            .AddListener(() =>
            {
                if (!gameObject.activeInHierarchy)
                    return;

                StartCoroutine(SpawnNextPattern());
            });
    }
}
