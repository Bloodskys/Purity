using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBurningButton : MonoBehaviour {
    public Creature Creature;
    public int ticks;
    public float timeToTick;
    public float damagePerTick;

    private int dots;
	// Use this for initialization
	void Start () {
        dots = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        dots++;

        Burning burning = new Burning(Creature, Creature, damagePerTick, timeToTick, ticks)
        {
            Title = "Burning" + dots
        };
        burning.AttachTo(Creature);
    }
}
