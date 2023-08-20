using StudioScor.Utilities;

namespace StudioScor.GameplayQueSystem
{
    public abstract class QueComponent : BaseMonoBehaviour
    {
        public abstract void Play();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();
    }
}
