using UnityEngine;
using Cinemachine;

namespace StudioScor.GameplayCueSystem
{
#if SCOR_ENABLE_CINEMACHINE
    public class CinemachineImpulseCue : GameplayCueComponent
    {
        [Header(" [ Cinemachine Impulse Cue ] ")]
        [SerializeField] private CinemachineImpulseSource cinemachineImpulseSource;
        [SerializeField] private Vector3 direction = Vector3.up;
        [SerializeField] private float force = 1f;
        [SerializeField] private float durataion = 0.2f;

        private void Reset()
        {
#if UNITY_EDITOR
            cinemachineImpulseSource = GetComponentInChildren<CinemachineImpulseSource>();
#endif
        }
        public override void Pause()
        {
            
        }

        public override void Play()
        {
            float cueScale = Cue.Scale.x;

            cinemachineImpulseSource.m_ImpulseDefinition.m_ImpulseDuration = cueScale * durataion;

            Vector3 shakeDirection = Cue.Rotation * direction;
            float shakeForce = cueScale * force;

            Vector3 velocity = shakeDirection * shakeForce;

            cinemachineImpulseSource.GenerateImpulseAtPositionWithVelocity(Cue.Position, velocity);
        }

        public override void Resume()
        {
        }

        public override void Stop()
        {
        }
    }
#endif
}
 