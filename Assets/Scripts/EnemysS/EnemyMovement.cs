using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] posiciones;
    public float velocity;
    Rigidbody2D rgb;
    int id=0;
    int direction = 1;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 point = posiciones[id].position;
        float distance = point.x - transform.position.x;
        if (Mathf.Abs(distance) < 0.1f)
        {
            direction *= -1; 
            id = (id + 1) % posiciones.Length; // Avanza al siguiente objetivo
        }

        // Aplica la velocidad en la dirección correcta
        Vector2 movement = Vector2.right * direction * velocity;
        rgb.velocity = movement;
    }
}
