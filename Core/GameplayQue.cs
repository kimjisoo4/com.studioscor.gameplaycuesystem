using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.GameplayQueSystem
{
    [CreateAssetMenu(menuName ="StudioScor/GameplayQue/new GameplayQue", fileName = "Que_")]
    public class GameplayQue : BaseScriptableObject
    {
        [Header(" [ Gameplay Que ] ")]
        [SerializeField] private QueFX[] queFXs;

        public void PlayQueAttached(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            foreach (QueFX fX in queFXs)
            {
                fX.PlayQueAttached(transform, position, rotation, scale);
            }
        }

        public void PlayQue(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            foreach (QueFX fX in queFXs)
            {
                fX.PlayQue(position, rotation, scale);
            }
        }
    }
}
