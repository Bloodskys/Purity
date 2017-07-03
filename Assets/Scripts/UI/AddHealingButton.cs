using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealingButton : MonoBehaviour
{
    public Creature Creature;
    public int ticks;
    public float timeToTick;
    public float healingPerTick;

    private int hots;
    // Use this for initialization
    void Start()
    {
        hots = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        hots++;

        Healing healing = new Healing(Creature, Creature, healingPerTick, timeToTick, ticks)
        {
            Title = "Healing" + hots
        };
        healing.AttachTo(Creature);
    }
}
