using StudioScor.Utilities;
using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    public class AnimNotify_PlayGamepalyCue : AnimNotifyBehaviour
    {
        [Header(" [ Play Gameplay Cue ] ")]
        [SerializeField] private FGameplayCue _gameplayCue;
        [SerializeField] private bool _isAttach = false;

        protected override void OnNotify(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(_isAttach)
            {
                _gameplayCue.PlayAttached(animator.transform);
            }
            else
            {
                _gameplayCue.PlayFromTarget(animator.transform);
            }
        }
    }
}
