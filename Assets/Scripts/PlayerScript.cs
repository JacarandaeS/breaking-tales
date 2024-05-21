using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    public float maxX = 7.5f;
    public Rigidbody2D playerBody;
    float movementHorizontal;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x > -maxX)) {
             transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}
