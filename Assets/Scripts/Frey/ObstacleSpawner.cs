using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public Transform[] Prefabs;
    [Tooltip("Do we want to pick a random prefab from the list each time we spawn?")]
    public bool MixPrefabs = true;

    public int Count = 100;
    public bool RandomRotation = false;

    public void Spawn (float Size) {
        prefabIndex = Random.Range(0, Prefabs.Length);
        SpawnInArea((Vector2)transform.position, 
                    (Vector2)transform.position + new Vector2(Size, Size)); 
    }

    int prefabIndex;

    void SpawnInArea(Vector2 min, Vector2 max) {
        for (int i = 0; i < Count; i++) {

            if (MixPrefabs)
                prefabIndex = Random.Range(0, Prefabs.Length);

            Transform t = Instantiate(Prefabs[prefabIndex], transform);
            Vector3 pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            t.localPosition = pos;

            if (RandomRotation)
                t.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
        }
    }
}
