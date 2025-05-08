using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;



    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }

        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Direita").position;  //Direita
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Esquerda").position;    //Esquerda
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y > 0 && pm.moveDir.x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Cima").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Cima").position; //Cima
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y < 0 && pm.moveDir.x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Baixo").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Baixo").position;    //Baixo
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita Cima").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Direita Cima").position;   //Direita Cima
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita Baixo").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Direita Baixo").position;  //Direita Baixo
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda Cima").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Esquerda Cima").position;  //Esquerda Cima
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda Baixo").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Esquerda Baixo").position; //Esquerda Baixo
                SpawnChunk();
            }
        }
    }

   void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);

    }
}