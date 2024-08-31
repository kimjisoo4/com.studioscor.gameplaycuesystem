using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem
{
    public abstract class CueFX : BaseScriptableObject
    {
        public virtual void Initialization() 
        {
            Log("Initialization");
        }

        public abstract ICueActor GetCueActor();
    }
}
