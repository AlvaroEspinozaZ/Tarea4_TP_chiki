using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour
{

    public static Action<int> UdateHealth;
    public static Action<int> ModifyHealth;
    public int health;

    [Header("Handlers")]
    [SerializeField] private HandleMessage updateLife;
    [SerializeField] private HandleMessage lose;

    void Start()
    {
        //UdateHealth = CurrentVida;
        //ModifyHealth = CurrentVida;
        updateLife.ActionGeneralInt += CurrentVida;
    }

    private void CurrentVida(int damage)
    {
        health += damage;
        if (health <= 0)
        {
            lose.CallEventGeneral();
        }
    }
    private int GetVida()
    {
        return health ;
    }
}
