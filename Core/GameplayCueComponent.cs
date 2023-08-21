using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem
{
    public abstract class GameplayCueComponent : BaseMonoBehaviour
    {
        public Cue Cue { get; set; }
        public abstract void Play();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();

        protected virtual void Finish()
        {
            Cue.Remove(this);
        }
    }
}
