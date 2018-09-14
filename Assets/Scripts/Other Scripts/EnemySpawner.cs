using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Transform player;

    public Transform enemyPrefab;

    public float MaxSpawnRate = 8f;
    public AnimationCurve SpawnRateOverTime;

    void Start () {
        player = FindObjectOfType<PlayerControlForward>().transform;
	}

    float cooldown = 0f;

    float gameTime = 0f;

    void Update () {
        gameTime += Time.unscaledDeltaTime;

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

    int maxChildCount = 5;

    void TrySpawnEnemy () {
        float dist = Vector2.Distance(player.position, transform.position);

        if (transform.childCount < maxChildCount && dist < destroyRange && dist > spawnRange) {
            Transform t = Instantiate(enemyPrefab, transform);
            t.position = Random.onUnitSphere + transform.position;

            //After 60s enemies respawn instantly
            float time = Mathf.Clamp01(gameTime / 60f);
            //Invert
            float sample = (1f - SpawnRateOverTime.Evaluate(time));
            cooldown = sample * MaxSpawnRate;
        }
    }
}
