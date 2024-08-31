using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    public interface ICueActor
    {
        public GameObject gameObject { get; }
        public Transform transform { get; }

        public Cue Cue { get; }

        public void Setup(Cue cue, Vector3 position, Vector3 rotation, Vector3 scale, float volume);
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        public Vector3 Scale { get; }

        public void Play();
        public void Stop();
        public void Pause();
        public void Resume();
    }
}
