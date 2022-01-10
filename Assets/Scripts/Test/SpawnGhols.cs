using System.Collections;
using UnityEngine;

public class SpawnGhols : MonoBehaviour
{
    public Transform TriggerZone;
    public GameObject EnemyPrefab;
    public PlayerController Player;
    private Vector3 _trigerArea;

    private int _enemyCount = 10;
    private float _timeSpawn;

    private void Awake()
    {
        _trigerArea = new Vector3(TriggerZone.position.x, 0, TriggerZone.position.z);
    }
    private IEnumerator GhoulSpawn()
    {
        while (_enemyCount > 0)
        {
            _enemyCount--;
         var gameObject = Instantiate(EnemyPrefab, SearchingSpawnPoint(_trigerArea), Quaternion.identity);
            gameObject.GetComponent<Ghoul>().SetTarget(Player);
            yield return new WaitForSeconds(SetSpawnTime());
        }
    }

    private Vector3 SearchingSpawnPoint(Vector3 spawnArea)
    {
        var Xscale = TriggerZone.localScale.x / 2f;
        var Zscale = TriggerZone.localScale.z / 2f;

        var newX = Random.Range(-Xscale, Xscale);
        var newZ = Random.Range(-Zscale, Zscale);

        var spawnPoint = new Vector3(spawnArea.x + newX, 1f, spawnArea.z + newZ);

        return spawnPoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GhoulSpawn());
    }
    private float SetSpawnTime()
    {
        _timeSpawn = Random.Range(0f, 1.5f);
        return _timeSpawn;
    }




}
