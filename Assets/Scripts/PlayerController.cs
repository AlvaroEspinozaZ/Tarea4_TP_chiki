using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rgb;
    [Header("Colores")]
    List<Color> listColores;
    bool canChangeColor=true;
    int idColors=0;
    [Header("Movimiento")]
    Vector2 direciont2D;
    [SerializeField] float speed=5;
    [Header("Salto")]
    [SerializeField] float forceJump=2;
    public bool isInFloor = true;
    public int nJumps = 2;

    [Header("Raycast")]
    public float distance =2;
    public LayerMask layer;

    [Header("Handlers")]
    //[SerializeField] private HandleMessage updateLife;
    //[SerializeField] private HandleMessage updatePoints;
    //[SerializeField] private HandleMessage win;
    //[SerializeField] private HandleMessage lose;
    [Header("GameEvent")]
    [SerializeField] private GameEvent updateLife;
    [SerializeField] private GameEvent updatePoints;
    [SerializeField] private GameEvent win;
    [SerializeField] private GameEvent lose;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        listColores = new List<Color>();
        listColores.Add(Color.blue);
        listColores.Add(Color.green);
        listColores.Add(Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,distance, layer);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (hit)
        {
            //Debug.Log("Estoy tocando" + layer);
            isInFloor = true;
            nJumps = 2;
        }
        else
        {
            isInFloor = false;
        }              
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(direciont2D.x) > 0)
        {
            rgb.velocity = new Vector2(direciont2D.x * speed, rgb.velocity.y);
        }
        else { rgb.velocity = new Vector2(0, rgb.velocity.y); }
    }

    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        direciont2D = value.ReadValue<Vector2>();
    }
    public void onJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {       
            if(Time.timeScale == 1)
            {
                if (!isInFloor)
                {
                    --nJumps;
                }
                else
                {
                    --nJumps;
                }
                if (nJumps > 0)
                {
                    rgb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
                }
            }           
        }
    }
    public void onChangeColor(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (Time.timeScale == 1)
            {
                if (canChangeColor)
                {
                    idColors++;
                    int id = idColors % 3;
                    Debug.Log(id);
                    //Debug.Log(listColores[0]);
                    gameObject.GetComponent<SpriteRenderer>().color = listColores[id];
                }
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //corazones
            collision.gameObject.SetActive(false);
            //updateLife.CallEventInt(5);
            updateLife.Raise(5);

        }
        if (collision.gameObject.layer == 7)
        {
            //enemigos azules
            canChangeColor = false;
            if (gameObject.GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {                
                Debug.Log("ChocasteConUnazules");
                //updateLife.CallEventInt(-7);
                updateLife.Raise(-7);
            }
        }
        if (collision.gameObject.layer == 8)
        {
            //enemigos verdes
            canChangeColor = false;
            if (gameObject.GetComponent<SpriteRenderer>().color!= collision.gameObject.GetComponent<SpriteRenderer>().color)
            {                
                Debug.Log("ChocasteConUnVerde");
                //updateLife.CallEventInt(-5);
                updateLife.Raise(-5);

            }

        }
        if(collision.gameObject.tag == "Coins")
        {
            collision.gameObject.SetActive(false);
            //PointSystem.UpdatePoints(10);            
            //updatePoints.CallEventInt(10);
            updatePoints.Raise(10);
        }
        if (collision.gameObject.tag == "Estrella")
        {
            collision.gameObject.SetActive(false);
            //win.CallEventGeneral();
            win.Raise();
        }
        if (collision.gameObject.tag == "Muerte")
        {
            //lose.CallEventGeneral();
            lose.Raise();
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("sali del azul");
            canChangeColor = true;
        }
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("sali del verde");
            canChangeColor = true;
        }
    }
    private void OnDisable()
    {
        //lose.CallEventGeneral();
    }
}
