using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
public class Hexagon : MonoBehaviour
{
    static AbilityTreeManager manager;
    public static AbilityTreeManager Manager
    {
        get
        {
            if (manager == null)
            {
                manager = AbilityTreeManager.Manager;
            }
            return manager;
        }
    }
    public void Awake()
    {
        RecalculateWorldPosition();
    }
    public static Vector3 QOrt = Vector3.right;
    public static Vector3 ROrt = Quaternion.Euler(0,0,120) * Vector3.right;
    public static Vector3 SOrt = -QOrt - ROrt;

    float size = 50;
    [SerializeField]
    Vector3 position = Vector3.zero;
    public Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            if (position != value)
            {
                position = value;
                RecalculateWorldPosition();
            }
        }
    }
    public float Size
    {
        get
        {
            return size;
        }
        set
        {
            if (size != value)
            {
                size = value;
                RecalculateWorldPosition();
            }
        }
    }
    public float Q
    {
        get
        {
            return position.x;
        }
    }
    public float R
    {
        get
        {
            return position.y;
        }
    }
    public float S
    {
        get
        {
            return position.z;
        }
    }
    public Vector3 Center
    {
        get
        {
            return Manager.Center;
        }
    }
    private void RecalculateWorldPosition()
    {
        Vector3 localDisplacement = HexToWorld(Position) * Size + Center;
        transform.localPosition = localDisplacement;
    }
    public static Vector3 HexToWorld(Vector3 hex)
    {
        return QOrt * hex.x + ROrt * hex.y + SOrt * hex.z;
    }
    public void Slide(Vector2 v)
    {

    }
}
