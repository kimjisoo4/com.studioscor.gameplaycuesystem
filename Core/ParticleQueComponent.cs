using UnityEngine;

namespace StudioScor.GameplayQueSystem
{
    [AddComponentMenu("StudioScor/GameplayQue/Particle Que Component")]
    public class ParticleQueComponent : QueComponent
    {
        [Header(" [ Particle Que ] ")]
        [SerializeField] private ParticleSystem particle;

        private void Reset()
        {
#if UNITY_EDITOR
            particle = GetComponentInChildren<ParticleSystem>();
#endif
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
            if (!particle.main.playOnAwake)
                particle.Play();
        }

        public override void Stop()
        {
            particle.Stop();
        }
    }
}
 