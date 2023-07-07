using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeightMap : MonoBehaviour
{
    public GameObject block;
    static int xSize = 30;
    static int ySize = 30;
    int[,] heightmap = new int[xSize, ySize];


    // Start is called before the first frame update
    void Start()
    {

        for(int p = 0; p < xSize; p++){
            for(int q = 0; q < ySize; q++) {
                heightmap[p,q] = 0;
            }
        }

        int height = 10;
        int x = (xSize/2) + 1;
        int y = (ySize/2) + 1;
        heightmap[x,y] = height;
        int i = 0;
        
        switch(i) {
            case 0:
                if(x + 1 < xSize) {
                    heightmap[x + 1,y] = height;
                } 
                if(y + 1 < ySize) {
                    heightmap[x,y + 1] = height;
                }
                if(x - 1 >= 0) {
                    heightmap[x - 1,y] = height;
                }
                if(y - 1 >= 0) {
                    heightmap[x,y - 1] = height;
                }
                break;
            case 1:
                if(x + 1 < xSize) {
                    heightmap[x + 1,y] = height;
                } 
                if(y + 1 < ySize) {
                    heightmap[x,y + 1] = height;
                }
                if(x + 2 < xSize) {
                    heightmap[x + 2,y] = height;
                } 
                if(y + 2 < ySize) {
                    heightmap[x,y + 2] = height;
                }
                if(x - 1 >= 0) {
                    heightmap[x - 1,y] = height;
                }
                if(y - 1 >= 0) {
                    heightmap[x,y - 1] = height;
                }
                if(x + 1 < xSize && y + 1 < ySize) {
                    heightmap[x + 1,y + 1] = height;
                } 
                if(y + 1 < ySize) {
                    heightmap[x,y + 1] = height;
                }
                break;
        } 
        int randomizer = 0;
        while(height > 0) {

            for(int p = 0; p < xSize; p++){
                for(int q = 0; q < ySize; q++) {
                    randomizer = Random.Range(0,100);
                    if(heightmap[p,q] == height) {

                        //Oben drueber
                        if(p + 1 < xSize) {
                            if(randomizer < 50){
                                if(!(heightmap[p + 1,q] >= height)){
                                    heightmap[p + 1,q] = height - 1;
                                }
                            } else {
                                if(!(heightmap[p + 1,q] >= height)){
                                    heightmap[p + 1,q] = height - 1;
                                }
                                if(p + 2 < xSize) {
                                    if(!(heightmap[p + 2,q] >= height)){
                                        heightmap[p + 2,q] = height - 1;
                                    }   
                                }
                            }
                            randomizer = Random.Range(0,100);
                        } 
                        //Rechts davon
                        if(q + 1 < ySize) {
                            if(randomizer < 50){
                                if(!(heightmap[p,q+1] >= height)){
                                    heightmap[p,q + 1] = height - 1;
                                }
                            } else {
                                if(!(heightmap[p,q+1] >= height)){
                                    heightmap[p,q + 1] = height - 1;
                                }
                                    if(q + 2 < ySize) {
                                        if(!(heightmap[p,q + 2] >= height)){
                                            heightmap[p,q + 2] = height - 1;
                                        }   
                                }

                            }
                            if(!(heightmap[p,q+1] >= height)){
                                heightmap[p,q + 1] = height - 1;
                            }
                            randomizer = Random.Range(0,100);
                        }
                        //Unten drunter
                        if(p - 1 >= 0) {
                            if(randomizer < 50){
                                if(!(heightmap[p - 1,q] >= height)){
                                    heightmap[p - 1,q] = height - 1;
                                }
                            } else {
                                if(!(heightmap[p - 1,q] >= height)){
                                    heightmap[p - 1,q] = height - 1;
                                }
                                if(p - 2 >= 0) {
                                    if(!(heightmap[p-2,q] >= height)){
                                        heightmap[p-2,q] = height - 1;
                                    }  
                                }
                            }
                            randomizer = Random.Range(0,100);
                            
                        }
                        //Links davon
                        if(q - 1 >= 0) {
                            if(randomizer < 50){
                                if(!(heightmap[p,q - 1] >= height)){
                                    heightmap[p,q - 1] = height - 1;
                                }
                            } else {
                                if(!(heightmap[p,q - 1] >= height)){
                                    heightmap[p,q - 1] = height - 1;
                                }
                                if(q-2 >= 0) {
                                   if(!(heightmap[p,q - 2] >= height)){
                                        heightmap[p,q - 2] = height - 1;
                                    } 
                                }
                            }
                            
                           
                        }
                        //Oben links
                        if(q - 1 >= 0 && p + 1 < xSize) {
                            if(randomizer < 50){
                                
                            } else {

                            }
                            if(!(heightmap[p + 1,q - 1] >= height)){
                                heightmap[p + 1,q - 1] = height - 1;
                            }
                            
                        }
                        //Oben rechts
                        if(q + 1 < ySize && p + 1 < xSize) {
                            if(randomizer < 50){
                                
                            } else {

                            }
                            if(!(heightmap[p + 1,q + 1] >= height)){
                                heightmap[p + 1,q + 1] = height - 1;
                            }
                            
                        }
                        //Unten links
                        if(q - 1 >= 0 && p - 1 >= 0) {
                            if(randomizer < 50){
                                
                            } else {

                            }
                            if(!(heightmap[p - 1,q - 1] >= height)){
                                heightmap[p - 1,q - 1] = height - 1;
                            }
                            
                        }
                        //Unten rechts
                        if(q + 1 < ySize && p - 1 >= 0) {
                            if(randomizer < 50){
                                
                            } else {

                            }
                            if(!(heightmap[p - 1,q + 1] >= height)){
                                heightmap[p - 1,q + 1] = height - 1;
                            }
                            
                        }
                    }
                }
            
            }

            height -= 1;

        }



        string ausgabe = string.Empty;

        for(int p = 0; p < xSize; p++){
            for(int q = 0; q < ySize; q++) {
                ausgabe += heightmap[p,q];
                ausgabe += " , ";
            }
            ausgabe += "\n";
        }
        
        for(int p = 0; p < xSize; p++){
            for(int q = 0; q < ySize; q++) {
                Instantiate(block, new Vector3(p*2, heightmap[p,q]*2, q*2), Quaternion.identity);
            }
        }


        UnityEngine.Debug.Log(ausgabe);





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
