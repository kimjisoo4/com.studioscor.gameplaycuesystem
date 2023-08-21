using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [AddComponentMenu("StudioScor/GameplayCue/Sound Cue Component")]
    public class SoundCueComponent : GameplayCueComponent
    {
        [Header(" [ Sound Que Component ] ")]
        [SerializeField] private AudioSource audioSource;

        public override void Pause()
        {
            audioSource.Pause();
        }

        public override void Play()
        {
            audioSource.Play();
        }

        public override void Resume()
        {
            audioSource.UnPause();
        }

        public override void Stop()
        {
            audioSource.Stop();
        }
    }
}
 