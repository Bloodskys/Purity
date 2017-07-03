using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PointPool
{
    public PointPool(float value=0, float maxValue=0)
    {
        this.value = value;
        this.maxValue = maxValue;
    }

    public float MaxValue
    {
        get
        {
            return maxValue;
        }
    }
    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = Mathf.Min(value, MaxValue);
        }
    }
    protected float maxValue;
    protected float value;

    public void SetMaxValue(float maxValue)
    {
        this.maxValue = maxValue;
    }

    #region Override Operators

    public static PointPool operator -(PointPool p)
    {
        return new PointPool()
        {
            Value = -p.Value
        };
    }
    public static PointPool operator +(PointPool p, float f)
    {
        return new PointPool()
        {
            maxValue = p.maxValue,
            value = p.value + f
        };
    }
    public static implicit operator PointPool(float f)
    {
        return new PointPool()
        {
            maxValue = f,
            Value = f
        };
    }
    public static implicit operator float(PointPool p)
    {
        return p.Value;
    }

    #endregion
}
