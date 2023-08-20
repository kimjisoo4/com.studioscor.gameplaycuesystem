using UnityEngine;

namespace StudioScor.GameplayQueSystem
{
    [AddComponentMenu("StudioScor/GameplayQue/Sound Que Component")]
    public class SoundQueComponent : QueComponent
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
 