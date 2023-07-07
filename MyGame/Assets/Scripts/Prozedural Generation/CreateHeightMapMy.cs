using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeightMapMy : MonoBehaviour
{

    float[,] array = new float[12,12];
    Chunk[] chunks = new Chunk[144];
    
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < chunks.GetLength(0); i++) {
            array[0,0] = Random.Range(1,10);
            FillArray(array, 0, 0);
             chunks[i] = new Chunk(array);
        }
        
        
        

        string ausgabe = string.Empty;

        for(int i = 0; i < array.GetLength(0); i++) {
            for(int o = 0; o < array.GetLength(1); o++) {
                Instantiate(block, new Vector3((i+ 12*i) * 2 ,1 + chunks[0].getArray()[i,o]/10, (o + o*12) * 2), Quaternion.identity);
                
                ausgabe += array[i,o] + "|";
            }
            ausgabe += "\n";
        }
        UnityEngine.Debug.Log(ausgabe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillArray(float[,] array, int x, int y) {
    
        if(x + 1 >= array.GetLength(0)) {
            array[array.GetLength(0)-1,array.GetLength(1)-1] = (array[array.GetLength(0)-2,array.GetLength(1)-1] + array[array.GetLength(0)-1,array.GetLength(1)-2] + Random.Range(1,10)) / 3;
            return;
        } else if(y + 1 >= array.GetLength(1)) {
            return;
        }

        
        array[x,y + 1] = (array[x,y] + Random.Range(1,10))/2;
        array[x + 1,y] = (array[x,y] + Random.Range(1,10))/2;

        FillArray(array, x + 1, y);
        FillArray(array, x, y + 1);

    }

    
}

public class Chunk
{
    float[,] array;

    public Chunk(float[,] arrayt) {
        array = arrayt;
    }

    public float[,] getArray() {
        return array;
    }
}