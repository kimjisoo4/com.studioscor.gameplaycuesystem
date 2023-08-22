using UnityEngine;
using StudioScor.Utilities;
using UnityEngine.Pool;
using System;

namespace StudioScor.GameplayCueSystem
{
    [CreateAssetMenu(menuName ="StudioScor/GameplayCue/new GameplayCue", fileName = "Cue_")]
    public class GameplayCue : BaseScriptableObject
    {
        [Header(" [ Gameplay Que ] ")]
        [SerializeField] private CueFX[] queFXs;

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

            return new Cue(cuePool);
        }

        public void Initialization()
        {
            Log("Initialization GameplayCue");

            if (cuePool is null)
                CreatePool();

            foreach (var queFX in queFXs)
            {
                queFX.Initialization();
            }
        }

        public Cue GetCue()
        {
            var cue = CuePool.Get();

            foreach (CueFX fX in queFXs)
            {
                cue.Add(fX.GetCue());
            }

            return cue;
        }
    }
}
