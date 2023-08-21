using UnityEngine;
using StudioScor.Utilities;
using UnityEngine.Pool;
using System;

namespace StudioScor.GameplayCueSystem
{
    [CreateAssetMenu(menuName ="StudioScor/GameplayQue/new GameplayCue", fileName = "Cue_")]
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
                    cuePool = new ObjectPool<Cue>(Create);

                return cuePool;
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            cuePool = null;
        }

        private Cue Create()
        {
            Log(" Create ");

            return new Cue(cuePool);
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
