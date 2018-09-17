using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Transform player;

    public Transform enemyPrefab;

    public TimedVariable SpawnDelay = new TimedVariable();

    //public float MaxSpawnRate = 8f;

    void Start () {
        player = FindObjectOfType<PlayerControlForward>().transform;
	}

    float cooldown = 0f;

    void Update () {
        DestroyChildren();

        cooldown -= Time.deltaTime;

        if (cooldown <= 0f) {
            TrySpawnEnemy();
        }
	}

    float spawnRange = 5f;
    float destroyRange = 30f;

    void DestroyChildren () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);

            if (Vector2.Distance(player.position, t.position) > destroyRange) {
                Destroy(t.gameObject);
            }
        }
    }

    public int MaxChildCount = 8;

    void TrySpawnEnemy () {
        float dist = Vector2.Distance(player.position, transform.position);

        if (transform.childCount < MaxChildCount && dist < destroyRange && dist > spawnRange) {
            Transform t = Instantiate(enemyPrefab, transform);
            t.position = Random.onUnitSphere + transform.position;
       
            cooldown = SpawnDelay.GetValue(GameController.GameTime);
        }
    }
}
