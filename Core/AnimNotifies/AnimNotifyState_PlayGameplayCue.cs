using StudioScor.Utilities;
using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    public class AnimNotifyState_PlayGameplayCue : AnimNotifyStateBehaviour
    {
        [Header(" [ Play Gameplay Cue ] ")]
        [SerializeField] private FGameplayCue _gameplayCue;
        [SerializeField] private bool _isAttach = false;

        private Cue _cue;

        protected override void OnEnterNotify(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnEnterNotify(animator, stateInfo, layerIndex);

            if (_isAttach)
            {
                _cue = _gameplayCue.PlayAttached(animator.transform);
            }
            else
            {
                _cue = _gameplayCue.PlayFromTarget(animator.transform);
            }
        }

        protected override void OnExitNotify(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnExitNotify(animator, stateInfo, layerIndex);

            if(_cue is not null)
            {
                _cue.Stop();
                _cue = null;
            }
        }
    }
}
