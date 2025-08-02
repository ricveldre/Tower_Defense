using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _secondToSpawn = 5f;
    [SerializeField]
    private float _radius = 10f;
    [SerializeField]
    private float _positionY = 0f;
    [SerializeField]
    private UnityEvent<Vector3> _spawnEnemy;
    public void Initialize()
    {
        StartCoroutine(SpawnEnemies());
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondToSpawn);
            Vector2 direction = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = new Vector3(direction.x, 0, direction.y) * _radius;
            spawnPosition.y = _positionY;
            _spawnEnemy?.Invoke(spawnPosition);
        }
    }
}
