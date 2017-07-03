using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPointPoolBehaviour : MonoBehaviour {
    public Text Info;
    public PointPool Pool;
    public RectTransform Rect;
    public enum PoolType
    {
        Health,
        Energy,
        Shield
    }
    public PoolType poolType;
	// Use this for initialization
	void Start () {
        switch(poolType)
        {
            case PoolType.Energy:
                {
                    Pool = GLOBALS.Energy;
                    break;
                }
            case PoolType.Shield:
                {
                    Pool = GLOBALS.Shield;
                    break;
                }
            default:
                {
                    Pool = GLOBALS.Health;
                    break;
                }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Info.text = Pool.Value + " / " + Pool.MaxValue;
        Vector2 size = new Vector2(150 * Pool.Value/Pool.MaxValue, 16);
        Rect.sizeDelta = size;
	}
}
