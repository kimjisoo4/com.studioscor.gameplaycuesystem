using UnityEngine;
using Cinemachine;

namespace StudioScor.GameplayCueSystem
{
#if SCOR_ENABLE_CINEMACHINE
    public class CinemachineImpulseCue : GameplayCueComponent
    {
        [Header(" [ Cinemachine Impulse Cue ] ")]
        [SerializeField] private CinemachineImpulseSource _cinemachineImpulseSource;
        [SerializeField] private Vector3 _direction = Vector3.up;
        [SerializeField] private float _force = 1f;
        [SerializeField] private float _durataion = 0.2f;
        [SerializeField] private bool _useLegacy = false;


        private void OnValidate()
        {
#if UNITY_EDITOR
            if(!_cinemachineImpulseSource)
                _cinemachineImpulseSource = GetComponentInChildren<CinemachineImpulseSource>();
#endif
        }
        public override void Pause()
        {
            
        }

        public override void Play()
        {
            float cueScale = Cue.Scale.x;
            Vector3 shakeDirection = Cue.Rotation * _direction;
            float shakeForce = cueScale * _force;
            Vector3 velocity = shakeDirection * shakeForce;


            if(_useLegacy)
            {
                var impulseDefinition = _cinemachineImpulseSource.m_ImpulseDefinition;

                impulseDefinition.m_TimeEnvelope.m_SustainTime = Mathf.Max(0, (cueScale * _durataion) - impulseDefinition.m_TimeEnvelope.m_DecayTime);
            }
            else
            {
                _cinemachineImpulseSource.m_ImpulseDefinition.m_ImpulseDuration = cueScale * _durataion;
            }

            _cinemachineImpulseSource.GenerateImpulseAtPositionWithVelocity(Cue.Position, velocity);
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
 