using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size; // Größe des Terrains (eine quadratische Fläche)
    public float roughness; // Rauheit des Terrains

    private int[,] terrainData; // Das Array, das das Terrain repräsentiert
    public GameObject block;

    void Start()
    {
        GenerateTerrain();

        for(int p = 0; p < size; p++){
            for(int q = 0; q < size; q++) {
                Instantiate(block, new Vector3(p*2, terrainData[p,q]*2, q*2), Quaternion.identity);
            }
        }
        
    }

    void GenerateTerrain()
    {
        terrainData = new int[size, size];

        // Initialisiere die vier Eckpunkte des Terrains mit zufälligen Höhenwerten
        terrainData[0, 0] = Random.Range(0, 100);
        terrainData[size - 1, 0] = Random.Range(0, 100);
        terrainData[0, size - 1] = Random.Range(0, 100);
        terrainData[size - 1, size - 1] = Random.Range(0, 100);

        DiamondSquare(0, 0, size - 1, size - 1, roughness);

        // Jetzt hast du das generierte Terrain im Array terrainData
    }

    void DiamondSquare(int x1, int y1, int x2, int y2, float roughness)
    {
        int halfSize = (x2 - x1) / 2;

        if (halfSize < 1)
            return;

        // Diamond-Phase
        for (int y = y1 + halfSize; y < y2; y += 2 * halfSize)
        {
            for (int x = x1 + halfSize; x < x2; x += 2 * halfSize)
            {
                terrainData[x, y] = DiamondAverage(x, y, halfSize, Random.Range(-roughness, roughness));
            }
        }

        // Square-Phase
        for (int y = y1; y < y2; y += halfSize)
        {
            for (int x = x1; x < x2; x += halfSize)
            {
                terrainData[x + halfSize, y] = SquareAverage(x + halfSize, y, halfSize, Random.Range(-roughness, roughness));
                terrainData[x, y + halfSize] = SquareAverage(x, y + halfSize, halfSize, Random.Range(-roughness, roughness));
            }
        }

        // Rekursiver Aufruf für die vier Unterquadrate
        DiamondSquare(x1, y1, x1 + halfSize, y1 + halfSize, roughness);
        DiamondSquare(x1 + halfSize, y1, x2, y1 + halfSize, roughness);
        DiamondSquare(x1, y1 + halfSize, x1 + halfSize, y2, roughness);
        DiamondSquare(x1 + halfSize, y1 + halfSize, x2, y2, roughness);
    }

    int DiamondAverage(int x, int y, int size, float offset)
    {
        int count = 4;
        int sum = terrainData[x - size - 1, y - size - 1] +
                  terrainData[x - size - 1, y + size - 1] +
                  terrainData[x + size - 1 , y - size - 1] +
                  terrainData[x + size - 1, y + size - 1];

        return Mathf.RoundToInt(sum / count + offset);
       }

    int SquareAverage(int x, int y, int size, float offset)
    {
        int count = 4;
        int sum = terrainData[x - size - 1, y] +
                  terrainData[x + size - 1, y] +
                  terrainData[x, y - size - 1] +
                  terrainData[x, y + size - 1];

        return Mathf.RoundToInt(sum / count + offset);
    }
}