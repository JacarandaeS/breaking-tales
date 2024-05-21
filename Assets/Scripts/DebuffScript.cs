using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DebuffScript : MonoBehaviour
{
    public Rigidbody2D buffRb;
    public float time = 0;
    public float debuffTimer = 200;
    private Light2D buffLight;

    void Start() {
        buffRb = GetComponent<Rigidbody2D>();
        GameObject lightObject = GameObject.Find("potatolight");

        if (lightObject != null) {
            buffLight = lightObject.GetComponent<Light2D>();

            if (buffLight == null) {
                Debug.LogWarning("No Light2D component found on the object.");
            }
            else {
                buffLight.intensity = 1;
            }
        }
        else {
            Debug.LogWarning("Light2D object not found in the scene.");
        }
    }

    void Update() {
        
        if (buffLight.intensity == 0 && time < 3f) { 
            time += Time.deltaTime;
        }
        else {
            buffLight.intensity = 1;
            time = 0;
        }
        if (transform.position.y < -6) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            Destroy(gameObject);
            if (buffLight != null) {
                buffLight.intensity = 0;
                time = 0;
            }
        }
    }

}
