using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLOBALS : MonoBehaviour
{   
    public static PointPool Energy;
    public static PointPool Health;
    public static PointPool Shield;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = CurrentHealth;
        }
    }
    public float CurrentEnergy
    {
        get
        {
            return currentEnergy;
        }
        set
        {
            currentEnergy = CurrentEnergy;
        }
    }
    public float CurrentShield
    {
        get
        {
            return currentShield;
        }
        set
        {
            currentShield = CurrentShield;
        }
    }

    public float currentHealth;
    public float currentEnergy;
    public float currentShield;

    private void Awake()
    {
        Energy = new PointPool(100, 150);
        Health = new PointPool(90, 150);
        Shield = new PointPool(30, 150);
    }

    private void FixedUpdate()
    {
        CurrentHealth = currentHealth;
        CurrentEnergy = currentEnergy;
        CurrentShield = currentShield;
    }
}
