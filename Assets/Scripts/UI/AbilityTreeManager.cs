using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTreeManager : Singleton<AbilityTreeManager>
{
    [SerializeField]
    Vector3 center;
    [SerializeField]
    int radius;
    [SerializeField]
    GameObject hexagonButtonPrefab;
    static AbilityTreeManager manager;
    public static AbilityTreeManager Manager
    {
        get
        {
            if (manager == null)
            {
                Debug.Log("Creating manager"); 
                manager = new AbilityTreeManager();
            } 
            return manager;
        }
    }
    public void SetSelfAsSingletonInstance()
    {
        manager = this;
    }
    public static Vector3[] Directions =
    {
        new Vector3(0,-1,0),
        new Vector3(0,0,1),
        new Vector3(-1,0,0),
        new Vector3(0,1,0),
        new Vector3(0,0,-1),
        new Vector3(1,0,0),
    }; 
    public List<Hexagon> map = new List<Hexagon>();
    public List<GameObject> rings = new List<GameObject>();
    public int Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = value;
        }
    }
    public Vector3 Center
    {
        get
        {
            return center;
        }
        set
        {
            center = value;
        }
    }
    public GameObject ButtonPrefab
    {
        get
        {
            return hexagonButtonPrefab;
        }
        set
        {
            hexagonButtonPrefab = value;
        }
    }
    public static int CellsInMapWithRadius(int radius)
    {
        return 3 * radius * (radius - 1) + 1;
    }
    public static Vector3 GetNeighbour(Vector3 position, int direction)
    {
        return position + Directions[direction];
    }
    public static List<Vector3> Ring(Vector3 center, int radius)
    {
        List<Vector3> result = new List<Vector3>();
        Vector3 pos = center + Directions[4] * radius;
        if (radius == 0)
        {
            result.Add(center);
            return result;
        }
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < radius; j++)
            {
                result.Add(pos);
                pos = GetNeighbour(pos, i);
            }
        }
        return result;
    }
    public void GenerateGrid()
    {
        RemoveGrid();
        for(int i=0;i<=radius;i++)
        {
            map.AddRange(CreateRingOfButtons(center, i));
        }
    }
    List<Hexagon> CreateRingOfButtons(Vector3 center, int radius)
    {
        List<Hexagon> result = new List<Hexagon>();
        List<Vector3> ring = Ring(center, radius);
        //Creating separate gameObject per each ring
        GameObject circle = new GameObject();
        circle.transform.SetParent(transform);
        circle.name = radius.ToString();
        circle.transform.localPosition = Vector3.zero;
        rings.Add(circle);
        foreach(Vector3 pos in ring)
        {
            GameObject h = Instantiate(ButtonPrefab);
            h.transform.SetParent(circle.transform);
            h.GetComponent<Hexagon>().Position = pos;
            h.name = pos.ToString();
        }
        return result;
    }
    void RemoveGrid()
    {
        while(rings.Count > 0)
        {
            if (rings[0] != null)
            {
                DestroyImmediate(rings[0]);
            }
            rings.RemoveAt(0);
        }
    }
}
