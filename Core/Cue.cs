﻿using StudioScor.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    public class Cue : BaseClass
    {
        public delegate void CueStateHandler(Cue cue);

        public GameplayCue GameplayCue;

        private readonly List<ICueActor> _instanceCues = new();

        public Transform AttachTarget { get; set; }
        public Transform StartTarget { get; set; }
        public Transform EndTarget { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public float Volume { get; set; }
        public Vector3 EndPosition { get; set; }
        public float Duration { get; set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }
        public bool IsStopped { get; private set; }
        public bool UseStayWorldPosition { get; set; }

        public event CueStateHandler OnStartedCue;
        public event CueStateHandler OnStoppedCue;
        public event CueStateHandler OnPausedCue;
        public event CueStateHandler OnResumedCue;
        public event CueStateHandler OnEndedCue;

        public override bool UseDebug => GameplayCue.UseDebug;
        public override Object Context => GameplayCue;

        public override string ToString()
        {
            return $"{GameplayCue} - Cue (Position {Position} || Rotation {Rotation} || Scale {Scale} || Attach Target {AttachTarget})";
        }
        public Cue() { }
        
        public void Clear()
        {
            _instanceCues.Clear();

            Release();
        }

        private void Release()
        {
            if (!IsPlaying)
                return;

            Detach();

            IsPlaying = false;
            IsStopped = false;
            IsPaused = false;

            AttachTarget = null;
            StartTarget = null;
            EndTarget = null;

            Position = default;
            Rotation = default;
            Scale = Vector3.one;
            Volume = 1f;

            EndPosition = default;
            Duration = default;

            UseStayWorldPosition = false;

            Invoke_OnEndedCue();

            OnStartedCue = null;
            OnStoppedCue = null;
            OnPausedCue = null;
            OnResumedCue = null;
            OnEndedCue = null;

            GameplayCue.ReleaseCue(this);
        }

        public void Setup(GameplayCue gameplayCue)
        {
            GameplayCue = gameplayCue;
        }

        public void Add(ICueActor cueComponent)
        {
            _instanceCues.Add(cueComponent);
        }

        public void Remove(ICueActor cueComponent)
        {
            if (_instanceCues.Remove(cueComponent))
            {
                if (_instanceCues.Count == 0)
                {
                    Release();
                }
            }
        }

        public void Play()
        {
            if (IsPlaying)
                return;

            IsPlaying = true;

            for(int i = _instanceCues.LastIndex(); i >= 0; i--)
            {
                var cue = _instanceCues[i];

                if (AttachTarget)
                    cue.transform.parent = AttachTarget;

                cue.gameObject.SetActive(true);

                cue.Play();
            }

            Invoke_OnStartedCue();
        }
        public void Detach()
        {
            if (!AttachTarget)
                return;

            foreach (var cue in _instanceCues)
            {
                if (cue.transform.parent == AttachTarget)
                {
                    cue.transform.parent = null;
                }
            }
        }
        public void Pause()
        {
            if (!IsPlaying || IsPaused)
                return;

            IsPaused = true;

            foreach (var cue in _instanceCues)
            {
                cue.Pause();
            }

            Invoke_OnPausedCue();
        }
        public void Stop()
        {
            if (!IsPlaying || IsStopped)
                return;

            Resume();

            IsStopped = true;

            foreach (var cue in _instanceCues)
            {
                cue.Stop();
            }

            Invoke_OnStoppedCue();
        }
        public void Resume()
        {
            if (!IsPlaying || !IsPaused)
                return;

            IsPaused = false;

            foreach (var cue in _instanceCues)
            {
                cue.Resume();
            }

            Invoke_OnResumedCue();
        }

        private void Invoke_OnStartedCue()
        {
            Log(nameof(OnStartedCue));

            OnStartedCue?.Invoke(this);
        }
        private void Invoke_OnStoppedCue()
        {
            Log(nameof(OnStoppedCue));

            OnStoppedCue?.Invoke(this);
        }
        private void Invoke_OnPausedCue()
        {
            Log(nameof(OnPausedCue));

            OnPausedCue?.Invoke(this);
        }
        private void Invoke_OnResumedCue()
        {
            Log(nameof(OnResumedCue));

            OnResumedCue?.Invoke(this);
        }
        private void Invoke_OnEndedCue()
        {
            Log(nameof(OnEndedCue));

            OnEndedCue?.Invoke(this);
        }
    }
}
