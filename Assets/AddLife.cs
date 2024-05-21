using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{
    public Rigidbody2D buffRb;
    public float offsetRotation = 20;
    [SerializeField]  private Vector3 actualCirclePosition;
    [SerializeField] private GameObject circle;
    [SerializeField] private BallScript ballScript;
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

    //private void OnCollisionEnter2D(Collision2D collision) {
    //    if (collision.collider.CompareTag("Player")) {
    //        Debug.Log("this many lives:" + ballScript.lives);
    //    } 
    //}
}

