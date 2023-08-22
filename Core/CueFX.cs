using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem
{
    public abstract class CueFX : BaseScriptableObject
    {
        public virtual void Initialization() 
        {
            Log("Initialization");
        }

        public abstract GameplayCueComponent GetCue();
    }
}
