using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VectorHex
{
    float col;
    float row;
    public VectorHex(float col, float row)
    {
        Col = col;
        Row = row;
    }
    public float Col
    {
        get
        {
            return col;
        }
        set
        {
            col = value;
        }
    }
    public float Row
    {
        get
        {
            return row;
        }
        set
        {
            row = value;
        }
    }
}
