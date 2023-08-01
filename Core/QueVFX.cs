using System;
using UnityEngine;
using UnityEngine.Pool;

namespace StudioScor.GameplayQueSystem
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayQue/QueFX/new VFX", fileName = "QFX_")]
    public class QueVFX : QueFX
    {
        [SerializeField] private ParticleSystem effect;

        public override void PlayQueAttached(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            ParticleSystem effect = Instantiate(this.effect, position, rotation, transform);

            effect.transform.localScale = scale;

            if(!effect.main.playOnAwake)
                effect.Play();
        }

        public override void PlayQue(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            ParticleSystem effect = Instantiate(this.effect, position, rotation);

            effect.transform.localScale = scale;

            if (!effect.main.playOnAwake)
                effect.Play();
        }
    }
}
 