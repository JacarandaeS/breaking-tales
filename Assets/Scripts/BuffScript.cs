using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffScript : MonoBehaviour {
    public Rigidbody2D buffRb;
    public float offsetRotation = 20;
    [SerializeField]  private Vector3 actualCirclePosition;
    [SerializeField] private GameObject circle;
    private GameObject player;
    
    void Start() {
        buffRb = GetComponent<Rigidbody2D>();
        buffRb.velocity = Vector2.down * 2f;
        player = GameObject.Find("Player");
    }

    void Update() {
        buffRb.velocity = Vector2.down * 2f;
        actualCirclePosition = circle.transform.position;
        if(transform.position.y < -6) {
            Destroy(gameObject);   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
           Destroy(gameObject);    
           Instantiate(circle, new Vector2(player.transform.position.x, -1), circle.transform.rotation);
        } 
    }
}
