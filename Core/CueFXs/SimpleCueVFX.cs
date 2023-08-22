using StudioScor.Utilities;
using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayCue/CueFX/new VFX", fileName = "VFX_")]
    public class SimpleCueVFX : CueFX
    {
        [Header(" [ Simple Cue VFX ] ")]
        [SerializeField] private GameplayCueComponent cue;

        public override GameplayCueComponent GetCue()
        {
            return Instantiate(cue);
        }
    }
}
 