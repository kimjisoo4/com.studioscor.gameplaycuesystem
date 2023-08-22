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
        public Transform Target { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 EndPosition { get; set; }
        public float Duration { get; set; }

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
            AttachTarget = null;
            Position = default;
            Rotation = default;
            Scale = Vector3.one;

            pool.Release(this);
        }

        public void Add(GameplayCueComponent cueComponent)
        {
            cueComponent.Cue = this;

            instanceCues.Add(cueComponent);
        }

        public void Remove(GameplayCueComponent cueComponent)
        {
            if (cueComponent.Cue == this)
                cueComponent.Cue = null;

            instanceCues.Remove(cueComponent);

            if (instanceCues.Count == 0)
                Release();
        }

        public void Play()
        {
            foreach (var cue in instanceCues)
            {
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
