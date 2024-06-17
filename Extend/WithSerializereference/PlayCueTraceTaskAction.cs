using StudioScor.Utilities;
using System;
using UnityEngine;

namespace StudioScor.GameplayCueSystem.Extend
{
    [Serializable]
    public class PlayCueTraceTaskAction : TraceTaskAction
    {
        [Header(" [ Play Cue Trace Task Action ] ")]
        [SerializeField] private FGameplayCue _gameplayCue;
        [SerializeField] private bool _isAttached = false;
        [SerializeField] private bool _useHitPosition = true;
        [SerializeField] private bool _useHitNormal = true;

        private PlayCueTraceTaskAction _original;

        public override void Action(FTraceInfo traceInfo, RaycastHit hit)
        {
            bool useHitPosition = _original is null ? _useHitPosition : _original._useHitPosition;
            bool useHitNormal = _original is null ? _useHitNormal : _original._useHitNormal;

            var target = hit.transform;
            var gameplayCue = _original is null ? _gameplayCue : _original._gameplayCue;
            bool isAttached = _original is null ? _isAttached : _original._isAttached;

            Vector3 position = useHitPosition && hit.distance > 0 ? hit.point : hit.collider.ClosestPoint(traceInfo.TraceStart);
            position += target.transform.TransformDirection(gameplayCue.Position);

            Vector3 direction = useHitNormal && hit.distance > 0 ? hit.normal : traceInfo.TraceDirection;


            Vector3 rotation = Quaternion.LookRotation(direction, Vector3.up).eulerAngles + gameplayCue.Rotation;

            Vector3 scale = gameplayCue.Scale;

            if (isAttached)
                gameplayCue.Cue.PlayAttached(target, position, rotation, scale, true);
            else
                gameplayCue.Cue.Play(position, rotation, scale);
        }

        public override ITraceTaskAction Clone()
        {
            var clone = new PlayCueTraceTaskAction();

            clone._original = this;

            return clone;
        }
    }
}
