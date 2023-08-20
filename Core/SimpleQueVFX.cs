using StudioScor.Utilities;
using UnityEngine;

namespace StudioScor.GameplayQueSystem
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayQue/QueFX/new VFX", fileName = "QFX_")]
    public class SimpleQueVFX : QueFX
    {
        [Header(" [ Simple Que VFX ] ")]
        [SerializeField] private QueComponent que;

        public override QueComponent PlayQueAttached(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var instance = Instantiate(que, position, rotation, transform);

            instance.transform.localScale = scale;

            instance.Play();

            return instance;
        }

        public override QueComponent PlayQue(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var instance = Instantiate(que, position, rotation);

            instance.transform.localScale = scale;

            instance.Play();

            return instance;
        }
    }
}
 