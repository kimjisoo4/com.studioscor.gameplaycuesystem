using StudioScor.Utilities;
using System;
using UnityEngine;

namespace StudioScor.GameplayCueSystem.Extend
{
    [Serializable]
    public class PlayCueTaskAction : TaskAction
    {
        [Header(" [ Play Cue Task Action ] ")]
        [SerializeField] private FGameplayCue _gameplayCue;
        [SerializeField] private bool _isAttached = false;

        private PlayCueTaskAction _original;

        public override ITaskAction Clone()
        {
            var clone = new PlayCueTaskAction();

            clone._original = this;

            return clone;
        }

        public override void Action(GameObject target)
        {
            var gameplayCue = _original is null ? _gameplayCue : _original._gameplayCue;
            bool isAttached = _original is null ? _isAttached : _original._isAttached;

            if(isAttached)
            {
                gameplayCue.PlayAttached(target.transform);
            }
            else
            {
                gameplayCue.PlayFromTarget(target.transform);
            }
        }
    }
}
