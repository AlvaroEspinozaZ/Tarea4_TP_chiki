using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour
{
    public static Action<int> UdateHealth;
    public static Action<int> ModifyHealth;
    public int health;
    void Start()
    {
        UdateHealth = CurrentVida;
        ModifyHealth = CurrentVida;
    }

    private void CurrentVida(int damage)
    {
        health += damage;
        if (health <= 0)
        {
            GameController.OnLose?.Invoke();
        }
    }
    private int GetVida()
    {
        return health ;
    }
}
