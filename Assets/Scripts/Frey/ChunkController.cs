using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour {
    
    public PlayerControlForward player;
    public MapChunk chunkPrefab;

    public bool Debug = false;

    List<MapChunk> chunks = new List<MapChunk>();

	void Start () {
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                CreateChunk(x, y, Random.ColorHSV(.1f, .9f));
            }
        }
    }

    public float ChunkSize = 50f;

	void Update () {
        if (player.transform.position.x > ChunkSize) {
            ShiftChunks(-1, 0);
        } else if (player.transform.position.x < 0f) {
            ShiftChunks(1, 0);
        } else if (player.transform.position.y > ChunkSize) {
            ShiftChunks(0, -1);
        } else if (player.transform.position.y < 0f) {
            ShiftChunks(0, 1);
        }
    }

    void CreateChunk (int x, int y, Color color) {
        MapChunk c = Instantiate(chunkPrefab, transform);
        //Spawn enemies
        c.Init();
        c.SetPosition(x, y);

        if (Debug)
            c.SetColor(color);

        chunks.Add(c);
    }

    void ShiftChunks(int xShift, int yShift) {
        //print("ShiftChunks - X: " + xShift + ", Y: " + yShift);

        foreach (MapChunk c in chunks) {
            c.SetPosition(c.X + xShift, c.Y + yShift);
        }

        MapChunk[] mcs = new MapChunk[chunks.Count];
        chunks.CopyTo(mcs);

        for (int i = 0; i < mcs.Length; i++) {
            if (mcs[i].X < -1 || mcs[i].X > 1 || mcs[i].Y < -1 || mcs[i].Y > 1) {

                //Create new chunk

                int newX = xShift == 0 ? mcs[i].X : -xShift;
                int newY = yShift == 0 ? mcs[i].Y : -yShift;

                CreateChunk(newX, newY, Random.ColorHSV());

                //Remove old
                chunks.Remove(mcs[i]);
                Destroy(mcs[i].gameObject);
            }
        }
        //Also move player
        Vector3 playerPos = player.transform.position;

        float xPos = (ChunkSize * xShift);
        float yPos = (ChunkSize * yShift);

        player.SetPosition(player.transform.position + new Vector3(xPos, yPos));
    }
}
