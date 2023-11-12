using UnityEngine;
namespace StudioScor.GameplayCueSystem
{
    [AddComponentMenu("StudioScor/GameplayCue/Trail Cue Component")]
    public class TrailCueComponent : GameplayCueComponent
    {
        [Header(" [ Trail Cue ] ")]
        [SerializeField] private TrailRenderer trailRenderer;
        
        private float originaTime = 0f;
        private float elaspedTime = 0f;
        private void OnDisable()
        {
            Finish();
        }

        public override void Pause()
        {
            if (originaTime <= 0f)
            {
                originaTime = trailRenderer.time;
            }

            trailRenderer.time = Mathf.Infinity;
        }

        public override void Play()
        {
            originaTime = -1f;
            elaspedTime = 0f;

            transform.SetParent(Cue.AttachTarget);

            transform.SetLocalPositionAndRotation(Cue.Position, Cue.Rotation);
            trailRenderer.widthMultiplier = Cue.Scale.x;
            trailRenderer.Clear();
        }

        public override void Resume()
        {
            if(originaTime > 0f)
            {
                trailRenderer.time = originaTime;
                originaTime = -1f;
            }
        }

        public override void Stop()
        {
            transform.SetParent(null);
            originaTime = -1f;
        }

        private void Update()
        {
            if(!transform.parent)
            {
                elaspedTime += Time.deltaTime;

                if(elaspedTime >= trailRenderer.time)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}