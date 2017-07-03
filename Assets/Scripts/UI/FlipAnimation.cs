using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlipAnimation : MonoBehaviour {
    public AnimationCurve AnimationCurve;
    public float AnimationTime;
    public float StepTime;
    public float Angle;
    public Vector3 pointToRotateAround;
    private float timeAccum;
    private bool animate;
    public enum OrtoVector
    {
        Q = 0,
        R = 1,
        S = 2
    }
    public Vector2 FlipAxis;
    //Vector3 rotationVector = Vector3.zero;
	
	// Update is called once per frame
	void Update ()
    {
        //transform.Rotate()
    }
    IEnumerator Appearence(OrtoVector o)
    {
        FlipAxis = GetOrto(o);
        int steps = (int)(AnimationTime / StepTime);
        float angleStep = 90f / steps;
        //transform.eulerAngles = Quaternion.Euler(0, 0, 270) * FlipAxis;
        transform.Rotate(FlipAxis, 270);
        for (float t = 0; t < steps; t++)
        {
            //transform.eulerAngles = Quaternion.Euler(0, 0, angleStep) * FlipAxis;
            transform.Rotate(FlipAxis, angleStep);
            yield return new WaitForSeconds(StepTime/1000);
        }
        //TODO: try to solve with Lerp()
        /*for(float t = 0; t < AnimationTime; t += 50)
        {
            Mathf.Pow(Mathf.Lerp(0, AnimationTime, t), 2)
        }*/
    }
    IEnumerator Slide(Vector2 v)
    {
        int steps = (int)(AnimationTime / StepTime);
        Vector2 distanceStep = v / steps;
        for (float t=0;t<steps;t++)
        {
            transform.Translate(distanceStep);
            yield return new WaitForSeconds(StepTime / 1000);
        }
    }
    Vector2 GetOrto(OrtoVector o)
    {
        Vector2 v;
        switch (o)
        {
            case OrtoVector.R:
                {
                    v = Hexagon.ROrt;
                    break;
                }
            case OrtoVector.S:
                {
                    v = Hexagon.SOrt;
                    break;
                }
            default:
                {
                    v = Hexagon.QOrt;
                    break;
                }
        }
        return v.Rotate(-90f);
    }
    public void Flip(string o)
    {
        OrtoVector v;
        switch(o)
        {
            case "Q":
                {
                    v = OrtoVector.Q;
                    break;
                }
            case "R":
                {
                    v = OrtoVector.R;
                    break;
                }
            default:
                {
                    v = OrtoVector.S;
                    break;
                }
        }
        StartCoroutine("Appearence", v);
    }
    public void Move(string o)
    {
        Vector2 v;
        OrtoVector a;
        switch (o)
        {
            case "Q":
                {
                    v = Hexagon.QOrt;
                    a = OrtoVector.Q;
                    break;
                }
            case "R":
                {
                    v = Hexagon.ROrt;
                    a = OrtoVector.R;
                    break;
                }
            default:
                {
                    v = Hexagon.SOrt;
                    a = OrtoVector.S;
                    break;
                }
        }
        StartCoroutine("Appearence", a);
        StartCoroutine("Slide", v * 50f);
    }
}
