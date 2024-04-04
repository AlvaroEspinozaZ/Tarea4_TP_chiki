using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    Vector2 direciont2D;
    Rigidbody2D rgb;
    [SerializeField] float speed;
    public bool isInFloor = true;
    public int nJumps = 2;

    [Header("Raycast")]
    public float distance =2;
    public LayerMask layer;
    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,distance, layer);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (hit)
        {
            Debug.Log("Estoy tocando" + layer);
            isInFloor = true;
            nJumps = 2;
        }
        else
        {
            isInFloor = false;
            --nJumps;
        }              
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(direciont2D.x) > 0)
        {
            rgb.velocity = new Vector2(direciont2D.x * speed, rgb.velocity.y);
        }
        else { rgb.velocity = new Vector2(0, rgb.velocity.y); }

        if (isInFloor || nJumps>0)
        {            
            if(!isInFloor && nJumps == 1)
            {
                --nJumps;
            }
            if (direciont2D.y > 0)
            {
                rgb.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
            }
        }
     
    }

    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        direciont2D = value.ReadValue<Vector2>();
    }
    public void onChangeColor(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Cambiar al siguiente color");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Estas tocando " + 6);
        }
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Estas tocando " + 7);
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Estas tocando " + 8);
        }
    }
    private void OnDisable()
    {
        GameController.OnLose?.Invoke();
    }
}
