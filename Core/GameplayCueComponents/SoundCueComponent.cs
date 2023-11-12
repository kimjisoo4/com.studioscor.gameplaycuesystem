using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [AddComponentMenu("StudioScor/GameplayCue/Sound Cue Component")]
    public class SoundCueComponent : GameplayCueComponent
    {
        [Header(" [ Sound Que Component ] ")]
        [SerializeField] private AudioSource audioSource;
        
        private float defaultVolume = 0f;

        private void Awake()
        {
            defaultVolume = audioSource.volume;
        }
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

            transform.SetLocalPositionAndRotation(Cue.Position, Cue.Rotation);
            audioSource.volume = defaultVolume * Cue.Scale.x;

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
 