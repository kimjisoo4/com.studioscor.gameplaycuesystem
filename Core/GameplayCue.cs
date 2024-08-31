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
            [Min(0)]public Vector3 Scale;
            [Range(0f, 1f)]public float Volume;
        }

        [Header(" [ Gameplay Que ] ")]
        [SerializeField] private FCueFX[] _cueFXs;

        private static ObjectPool<Cue> _cuePool;

        private ObjectPool<Cue> CuePool
        {
            get
            {
                if (_cuePool is null)
                    CreatePool();

                return _cuePool;
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            if(_cuePool is not null)
            {
                _cuePool.Clear();
                _cuePool = null;
            }
        }
        private void CreatePool()
        {
            Log(" Create Pool ");

            _cuePool = new ObjectPool<Cue>(Create);
        }

        private Cue Create()
        {
            Log($"{nameof(Create)} :: All - {_cuePool.CountAll} || Active - {_cuePool.CountActive} || Inactive - {_cuePool.CountInactive}");

            return new Cue();
        }

        public void Initialization()
        {
            Log("Initialization GameplayCue");

            if (_cuePool is null)
                CreatePool();
            
            foreach (var queFX in _cueFXs)
            {
                queFX.Cue.Initialization();
            }
        }

        public Cue GetCue()
        {
            var cue = CuePool.Get();

            cue.Setup(this);

            foreach (FCueFX fx in _cueFXs)
            {
                var cueFX = fx.Cue.GetCueActor();

                cueFX.Setup(cue, fx.Position, fx.Rotation, fx.Scale, fx.Volume);

                cue.Add(cueFX);
            }

            return cue;
        }

        public void ReleaseCue(Cue cue)
        {
            CuePool.Release(cue);

            Log($"{nameof(ReleaseCue)} :: All - {_cuePool.CountAll} || Active - {_cuePool.CountActive} || Inactive - {_cuePool.CountInactive}");
        }
    }
}
