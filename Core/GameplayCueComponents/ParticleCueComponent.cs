using StudioScor.Utilities;
using UnityEngine;
namespace StudioScor.GameplayCueSystem
{

    [AddComponentMenu("StudioScor/GameplayCue/Particle Cue Component")]
    public class ParticleCueComponent : GameplayCueComponent
    {
        [Header(" [ Particle Cue ] ")]
        [SerializeField] private ParticleSystem particle;

        private void Reset()
        {
#if UNITY_EDITOR
            particle = GetComponentInChildren<ParticleSystem>();
#endif
        }

        private void OnDisable()
        {
            Finish();
        }

        public override void Pause()
        {
            var main = particle.main;

            main.simulationSpeed = 0f;
        }

        public override void Resume()
        {
            var main = particle.main;

            main.simulationSpeed = 1f;
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

            if (!particle.main.playOnAwake)
                particle.Play();
        }

        public override void Stop()
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}