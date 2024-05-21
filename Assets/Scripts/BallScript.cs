using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.Rendering.Universal;
using TMPro;

public class BallScript : MonoBehaviour {
    public float minY = -6.5f;
    public float maxVelocity = 15f;
    public float timer = 0f;
    public float spawnTime = 0.5f;
    public Rigidbody2D rb;
    public GameObject Square;
    public GameObject playerObject;
    [SerializeField] private GameObject debuff;
    [SerializeField] GameLogic gameLogic;
  

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.Find("Player");
        rb.velocity = Vector2.down * 10f;
        Debug.Log(gameLogic.hpAmount);
      

    }
    private void Awake() {
        gameLogic = FindObjectOfType<GameLogic>();
       
    }

    void Update() { 
        var objectsAmount = GameObject.FindGameObjectsWithTag("Circle");
        if(gameLogic.hpAmount >= 0) {
            if (transform.position.y < minY) {
                timer += Time.deltaTime;
                if(objectsAmount.Length > 1) {
                    Destroy(gameObject);
                }
           
                if (timer > spawnTime) {
                    gameLogic.decreaseLHP();
                    Debug.Log(gameLogic.hpAmount);
                    returnBall();
                    timer = 0;
                }
            }
        } else {
           Destroy(gameObject); 
        }

        if (rb.velocity.magnitude > maxVelocity) {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Brick")) {
            Destroy(collision.gameObject);  
        }
       
        if (collision.gameObject.CompareTag("BuffBrick")) {
            Destroy(collision.gameObject);
            Instantiate(Square, transform.position, transform.rotation);
        }

        if (collision.gameObject.CompareTag("DebuffBrick")) {
             Destroy(collision.gameObject);
            Instantiate(debuff, transform.position, transform.rotation);
        }
    }
 
    void returnBall() {
        transform.position = new Vector2(playerObject.transform.position.x, -1);
        rb.velocity = Vector2.down * 10f;
    }
    
}