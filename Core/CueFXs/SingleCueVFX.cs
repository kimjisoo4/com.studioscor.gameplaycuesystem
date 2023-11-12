using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayCue/CueFX/new Single VFX", fileName = "VFX_")]
    public class SingleCueVFX : CueFX
    {
        [Header(" [ Single Cue VFX ] ")]
        [SerializeField] private GameplayCueComponent cue;

        private GameplayCueComponent instanceCue;

        public override GameplayCueComponent GetCue()
        {
            if(!instanceCue)
                instanceCue = Instantiate(cue);
            
            return instanceCue;
        }
    }
}
 