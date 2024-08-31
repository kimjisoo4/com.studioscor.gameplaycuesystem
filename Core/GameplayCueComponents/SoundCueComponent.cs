using StudioScor.Utilities;
using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [AddComponentMenu("StudioScor/GameplayCue/Sound Cue Component")]
    public class SoundCueComponent : GameplayCueComponent
    {
        [Header(" [ Sound Que Component ] ")]
        [SerializeField] private AudioSource audioSource;

        private void OnDisable()
        {
            Finish();
        }

        public override void Pause()
        {
            audioSource.Pause();
        }

        public override void Play()
        {
            if (Cue.AttachTarget)
                transform.SetParent(Cue.AttachTarget);

            if (Cue.UseStayWorldPosition)
            {
                transform.SetPositionAndRotation(Position, Rotation);
            }
            else
            {
                transform.SetLocalPositionAndRotation(Position, Rotation);
            }

            audioSource.volume = Volume;

            audioSource.Play();
        }

        public override void Resume()
        {
            audioSource.UnPause();
        }

        public override void Stop()
        {
            if (transform.parent)
                transform.SetParent(null);

            audioSource.Stop();
        }

        private void Update()
        {
            if(!audioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
 