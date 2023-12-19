using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Entity _player;
    [SerializeField] private GameObject _goSign;

    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private Wave[] _waves;

    [System.Serializable]
    private class Wave {
        public int checkpointNumber;
        public List<GameObject> enemies;
        public List<Vector2> spawnPosition;
        public float spawnDelay;
    }

    private void OnEnable() {
        GameEvents.OnCheckPointEnter += SpawnEnemies;
    }

    private void OnDisable() {
        GameEvents.OnCheckPointEnter -= SpawnEnemies;
    }

    public void SpawnEnemies(int checkpointNumber) {
        foreach (Wave wave in _waves) {
            if (wave.checkpointNumber == checkpointNumber) {
                StartCoroutine(SpawnWave(wave));
            }
        }
    }

    private IEnumerator SpawnWave(Wave wave) {
        yield return new WaitForSeconds(wave.spawnDelay);
        _goSign.SetActive(false);
        for (int i = 0; i < wave.enemies.Count; i++) {
            GameObject enemy = Instantiate(wave.enemies[i], wave.spawnPosition[i], Quaternion.identity);
            enemy.transform.parent = _enemyParent.transform;
            enemy.GetComponent<Enemy>().SetTarget(_player);
        }
    }
}
