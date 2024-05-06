using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem
{
    public abstract class GameplayCueComponent : BaseMonoBehaviour
    {
        public Cue Cue { get; set; }

        /// <summary>
        /// Cue 를 재생합니다. 
        /// </summary>
        public abstract void Play();
        /// <summary>
        /// Cue 를 정지시킵니다.
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// Cue 를 일시 정지 시킵니다.
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// Cue 가 일시 정지 중이면 해제합니다.
        /// </summary>
        public abstract void Resume();

        protected virtual void Finish()
        {
            if (Cue is null)
                return;

            Cue.Remove(this);
            
            Cue = null;
        }
    }
}
