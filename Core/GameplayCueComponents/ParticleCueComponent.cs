using StudioScor.Utilities;
using System.Linq;
using UnityEngine;
namespace StudioScor.GameplayCueSystem
{

    [AddComponentMenu("StudioScor/GameplayCue/Particle Cue Component")]
    public class ParticleCueComponent : GameplayCueComponent
    {
        [Header(" [ Particle Cue ] ")]
        [SerializeField] private ParticleSystem[] _particles;

        private void Reset()
        {
#if UNITY_EDITOR
            _particles = GetComponentsInChildren<ParticleSystem>();
#endif
        }

        private void OnDisable()
        {
            Finish();
        }

        public override void Pause()
        {
            foreach (var particle in _particles)
            {
                var main = particle.main;

                main.simulationSpeed = 0f;
            }
        }

        public override void Resume()
        {
            foreach (var particle in _particles)
            {
                var main = particle.main;

                main.simulationSpeed = 1f;
            }
        }
        public override void Play()
        {
            if (Cue.AttachTarget)
                transform.SetParent(Cue.AttachTarget);

            if(Cue.UseStayWorldPosition)
            {
                transform.SetPositionAndRotation( Position, Rotation);
            }
            else
            {
                transform.SetLocalPositionAndRotation(Position, Rotation);
            }

            transform.localScale = Scale;

            if (!_particles[0].main.playOnAwake)
                _particles[0].Play();
        }

        public override void Stop()
        {
            foreach (var particle in _particles)
            {
                particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}