using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle;

    [SerializeField]
    private float _delay;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnObstacles()
    {
        var count = 10;

        for (int i = 0; i < count; i++)
        {
            Instantiate(_obstacle, transform.position, transform.rotation);
            yield return new WaitForSeconds(_delay);
        }
    }
}
