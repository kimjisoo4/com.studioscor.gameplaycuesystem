using StudioScor.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace StudioScor.GameplayCueSystem
{
    [CreateAssetMenu(menuName ="StudioScor/GameplayCue/new GameplayCue", fileName = "Cue_")]
    public class GameplayCue : BaseScriptableObject
    {
        [System.Serializable]
        public struct FCueFX
        {
            public CueFX Cue;
            public Vector3 Position;
            public Vector3 Rotation;
            public Vector3 Scale;
        }

        [Header(" [ Gameplay Que ] ")]
        [SerializeField] private FCueFX[] _cueFXs;

        private ObjectPool<Cue> cuePool;

        private ObjectPool<Cue> CuePool
        {
            get
            {
                if (cuePool is null)
                    CreatePool();

                return cuePool;
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            cuePool = null;
        }
        private void CreatePool()
        {
            Log(" Create Pool ");

            cuePool = new ObjectPool<Cue>(Create);
        }

        private Cue Create()
        {
            Log(" Create New Cue ");

            return new Cue(this);
        }

        public void Initialization()
        {
            Log("Initialization GameplayCue");

            if (cuePool is null)
                CreatePool();

            
            foreach (var queFX in _cueFXs)
            {
                queFX.Cue.Initialization();
            }
        }

        public Cue GetCue()
        {
            var cue = CuePool.Get();

            foreach (FCueFX fx in _cueFXs)
            {
                var cueFX = fx.Cue.GetCue();

                cueFX.SetOffset(fx.Position, fx.Rotation, fx.Scale);

                cue.Add(cueFX);
            }

            return cue;
        }

        public void ReleaseCue(Cue cue)
        {
            CuePool.Release(cue);
        }
    }
}
