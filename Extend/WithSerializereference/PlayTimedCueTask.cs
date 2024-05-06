using StudioScor.Utilities;
using System;
using UnityEngine;

namespace StudioScor.GameplayCueSystem.Extend
{
    [Serializable]
    public class PlayTimedCueTask : Task, ISubTask
    {
        [Header(" [ Play Cue Task Action ] ")]
        [SerializeField] private FGameplayCue _gameplayCue;
        [SerializeField][Range(0f, 1f)] private float _startTime = 0f;
        [SerializeField][Range(0f, 1f)] private float _endTime = 1f;
        [SerializeField] private bool _isAttached = true;

        private Cue _spawnedCue;

        private float _start;
        private float _end;
        private bool _attach;

        private bool _wasStarted = false;
        private PlayTimedCueTask _original;

        public override ITask Clone()
        {
            var clone = new PlayTimedCueTask();

            clone._original = this;

            return clone;
        }
        protected override void EnterTask()
        {
            base.EnterTask();

            _wasStarted = false;

            bool original = _original is null;

            _start = original ? _startTime : _original._startTime;
            _end = original ? _endTime : _original._endTime;
            _attach = original ? _attach : _original._isAttached;
        }
        protected override void ExitTask()
        {
            base.ExitTask();

            _spawnedCue.Stop();

            if(_attach)
            {
                _spawnedCue.Detach();
            }

            _spawnedCue = null;
        }
        public void FixedUpdateSubTask(float deltaTime, float normalizedTime)
        {
            return;
        }

        public void UpdateSubTask(float deltaTime, float normalizedTime)
        {
            if (!IsPlaying)
                return;

            if(!_wasStarted)
            {
                if(normalizedTime >= _start)
                {
                    SpawnCue();
                }
            }
            else
            {
                if(normalizedTime >= _end)
                {
                    EndTask();
                }
            }
        }   

        private void SpawnCue()
        {
            if (_wasStarted)
                return;

            _wasStarted = true;

            var gameplayCue = _original is null ? _gameplayCue : _original._gameplayCue;

            if (_attach)
            {
                _spawnedCue = gameplayCue.PlayAttached(Owner.transform);
            }
            else
            {
                _spawnedCue = gameplayCue.PlayFromTarget(Owner.transform);
            }
        }
    }
}
