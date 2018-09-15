using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour {

    public Transform Prefab;
    public int Count = 100;
    public bool RandomRotation = false;

    public Transform Root;
    [Header("World info")]
    public int ChunkSize = 10;
    
    public Vector2Int Size = new Vector2Int(100, 100);

    void Start () {
        int chunkCountX = Size.x / ChunkSize;
        int chunkCountY = Size.y / ChunkSize;

        //How many prefabs to spawn divided by total amount of chunks
        int prefabsPerChunk = Count / (chunkCountX * chunkCountY);

        for (int x = 0; x < chunkCountX; x++) {
            for (int y = 0; y < chunkCountY; y++) {
                Vector2 min = new Vector2(x * ChunkSize, y * ChunkSize);
                Vector2 max = new Vector2((x + 1) * ChunkSize, (y + 1) * ChunkSize);
                SpawnInArea(min, max, prefabsPerChunk);
            }
        }
	}
	
	void SpawnInArea (Vector2 min, Vector2 max, int count) {
        for (int i = 0; i < count; i++) {
            Transform t = Instantiate(Prefab, Root);
            Vector3 pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            t.localPosition = pos;

            if (RandomRotation)
                t.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));
        }
    }
}
