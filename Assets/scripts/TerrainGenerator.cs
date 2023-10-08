using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject terrainChunkPrefab;
    public Transform player;
    public float chunkSize = 100f;
    public float chunkDistance = 200f;
    public int maxChunk = 10;

    private Transform terrainParent;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        terrainParent = new GameObject("TerrainChunk").transform;
        spawnPosition = Vector3.zero;
        GenerateInitialTerrain();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, spawnPosition) < chunkDistance){
            GenerateTerrainChunk();
        }
    }

    private void GenerateInitialTerrain(){
        for (int i = 0; i < maxChunk; i++)
        {
            GenerateTerrainChunk();
        }
    }

    private void GenerateTerrainChunk(){
        GameObject newChunk = Instantiate(terrainChunkPrefab, spawnPosition, Quaternion.identity);
        newChunk.transform.parent = terrainParent;

        spawnPosition += Vector3.forward * chunkSize;

        if(terrainParent.childCount > maxChunk){
            Destroy(terrainParent.GetChild(0).gameObject);
        }
    }
}
