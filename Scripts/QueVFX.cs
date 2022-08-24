using UnityEngine;


namespace KimScor.GameplayTagSystem.GameplayQue
{
    [CreateAssetMenu(menuName = "GAS/GameplayQue/QueFX/new VFX", fileName = "QFX_")]
    public class QueVFX : QueFX
    {
        [SerializeField] private ParticleSystem _Effect;

        public override void Play(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            ParticleSystem effect = Instantiate(_Effect, position, rotation);

            effect.transform.localScale = scale;

            effect.Play();
        }
    }
}
