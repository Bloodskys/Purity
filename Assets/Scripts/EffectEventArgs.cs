using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EffectEventArgs : EventArgs
{
    public IDestroyable affectedCreature;
    public object[] args;
}
