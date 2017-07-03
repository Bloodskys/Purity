using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ArrowAssistant : MonoBehaviour
{
    //Vector2 defaultDirection = Vector2.right;
    public Vector2 CustomVector = Vector2.right;
    public bool UseOrtCombination;
    [Range(-1, 1)]
    public int Q;
    [Range(-1, 1)]
    public int R;
    [Range(-1, 1)]
    public int S;
    Vector2 direction;
    float angle;
    void Update()
    {
        if (UseOrtCombination)
        {
            direction =
                (Q * Hexagon.QOrt) +
                (R * Hexagon.ROrt) +
                (S * Hexagon.SOrt);
        }
        else
        {
            direction = CustomVector;
        }
        angle = Vector2.Angle(Vector2.right, direction) * (direction.y < 0 ? -1 : 1);
        print("Direction: " + direction + ", angle: " + angle);
        transform.eulerAngles = Vector3.forward * angle;
    }
}
