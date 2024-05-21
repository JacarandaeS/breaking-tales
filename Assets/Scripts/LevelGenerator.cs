using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public Gradient gradient;
    public GameObject brickPrefab;
    public GameObject buffBrickPrefab;
    public GameObject debuffBrick;
    [SerializeField] private GameObject gameOverScreen;



    private void Awake() {  
        for (int i = 0; i < size.x; i++) { 
            for (int j = 0; j < size.y; j++) {
               float random = UnityEngine.Random.Range(1, 10);
                if (random < 6) {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 1);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j /(size.y-1));
               

                }else if (random > 6 && random < 8) {
                    GameObject newBrick = Instantiate(buffBrickPrefab, transform);
                    newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 1);
                    newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
                    
                }else {
                    GameObject newBrick = Instantiate(debuffBrick, transform);
                    newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 1);
                    newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
                   
                }              
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
     
     if(transform.childCount == 0 ) {
            Debug.Log("wacho posta que ganaste wtf Xd");
            gameOverScreen.SetActive(true);

        }   
    }
   
}
