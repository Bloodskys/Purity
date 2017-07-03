using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IEffect : IDestroyable
{
    void Remove();
    void AttachTo(Creature target);
}
