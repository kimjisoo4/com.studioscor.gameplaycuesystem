using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace StudioScor.GameplayCueSystem
{
    public class Cue
    {
        private readonly List<GameplayCueComponent> instanceCues = new();
        public readonly ObjectPool<Cue> pool;

        public Transform AttachTarget { get; set; }
        public Transform StartTarget { get; set; }
        public Transform EndTarget { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 EndPosition { get; set; }
        public float Duration { get; set; }
        public bool IsPlaying { get; set; } 

        public Cue(ObjectPool<Cue> pool)
        {
            this.pool = pool;
        }

        public void Clear()
        {
            instanceCues.Clear();

            Release();
        }

        private void Release()
        {
            IsPlaying = false;

            AttachTarget = null;
            StartTarget = null;
            EndTarget = null;

            Position = default;
            Rotation = default;
            Scale = Vector3.one;

            EndPosition = default;
            Duration = default;

            pool.Release(this);
        }

        public void Add(GameplayCueComponent cueComponent)
        {
            cueComponent.Cue = this;

            instanceCues.Add(cueComponent);
        }

        public void Remove(GameplayCueComponent cueComponent)
        {
            instanceCues.Remove(cueComponent);

            if (instanceCues.Count == 0)
                Release();
        }

        public void Play()
        {
            IsPlaying = true;

            foreach (var cue in instanceCues)
            {
                if (AttachTarget)
                    cue.transform.parent = AttachTarget;

                cue.gameObject.SetActive(true);

                cue.Play();
            }
        }
        public void Pause()
        {
            foreach (var cue in instanceCues)
            {
                cue.Pause();
            }
        }
        public void Stop()
        {
            IsPlaying = false;

            foreach (var cue in instanceCues)
            {
                cue.Stop();
            }
        }
        public void Resume()
        {
            foreach (var cue in instanceCues)
            {
                cue.Resume();
            }
        }
    }
}
