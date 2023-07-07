using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeightMapMy : MonoBehaviour
{

    float[,] array = new float[12,12];
    Chunk[] chunks = new Chunk[144];
    
    public GameObject darkergrass;
    public GameObject grass;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < chunks.GetLength(0); i++) {
            float[,] array2 = new float[12,12];
            array2[0,0] = Random.Range(1,10);
            FillArray(array2, 0, 0);
            
            chunks[i] = new Chunk(array2);
        }
        
        
        int relena = Random.Range(1,100);


        //Jesus christ instantiate Block
        //Also: du gehst in einem chunk ein 2d feld durch, und platzierst es in einem "terrain" welches auch 2d ist deswegen 4 for schleifen
        //Vorgangsweise: als erstes unten links von jedem chunk in der untersten reihe des Terrains platzieren dann einen nach rechts im generierten array und die werden dann
        //auf der untersten terrain achse platziert jeweils bis eine ganze reihe fertig is, dann eine reihe nach oben dann so weiter.
        for(int i = 0; i < array.GetLength(0); i++) {
            for(int o = 0; o < array.GetLength(1); o++) {
                for(int p = 0; p<array.GetLength(0); p++) {
                    for(int q = 0; q<array.GetLength(0); q++) {
                        if(relena >= 50) Instantiate(grass, new Vector3((p*4 + (48*q)) ,1 + chunks[(i*12+q)].getArray()[p,o]/6, (o*4 + (i*48)) ), Quaternion.identity);
                        //UnityEngine.Debug.Log("chunk=" + (p*12+q) + " stelle=" + p + "," + o +  " hoehe=" + chunks[(p*12 + q)].getArray()[p,o]);
                        if(relena < 50) Instantiate(darkergrass, new Vector3((p*4 + 48*q)  ,1 + chunks[(i*12+q)].getArray()[p,o]/6, (o*4 + i*48) ), Quaternion.identity);
                        relena = Random.Range(1,100);
                    }
                }
                
                
                
            }
        }
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