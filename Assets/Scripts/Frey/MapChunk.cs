using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunk : MonoBehaviour {

    public float Size = 10f;

    public int X { get; private set; }
    public int Y { get; private set; }

    Renderer meshRenderer;
    ObstacleSpawner[] spawners;

    public void Init() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.gameObject.SetActive(false);

        spawners = GetComponentsInChildren<ObstacleSpawner>();
        for (int i = 0; i < spawners.Length; i++) {
            spawners[i].Spawn(Size);
        }
    }

    public void SetPosition (int x, int y) {
        this.X = x;
        this.Y = y;
        transform.position = new Vector3(x, y, 0f) * Size;
    }

    public void SetColor (Color color) {
        meshRenderer.gameObject.SetActive(true);
        meshRenderer.material.color = color;

    }
}
