using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchmarkBehavior : MonoBehaviour {
    public GameObject tilePrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnButtonClick()
    {
        for(int i=0;i<100;i++)
        {
            GameObject newTile = Instantiate(tilePrefab);
            newTile.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
        Debug.Log("100 tiles added!");
    }
}
