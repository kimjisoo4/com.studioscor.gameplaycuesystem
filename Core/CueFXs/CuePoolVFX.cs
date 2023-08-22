using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem.Utilities
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayCue/CueFX/new PoolVFX", fileName = "VFX_Pool_")]
    public class CuePoolVFX : CueFX
    {
        [Header(" [ Cue Pool VFX ] ")]
        [SerializeField] private SimplePooledObject pooled;
        [SerializeField] private int startSize = 5;

        private SimplePool pool;
        private Transform container;

        public SimplePooledObject GetItem
        {
            get
            {
                if (!container)
                    CreatePool();

                return pool.Get();
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            pool = null;
            container = null;
        }

        private void CreatePool()
        {
            var container = new GameObject(name);

            this.container = container.transform;

            pool = new(pooled, this.container, startSize);
        }

        public override void Initialization()
        {
            base.Initialization();

            if (!container)
                CreatePool();
        }


        public override GameplayCueComponent GetCue()
        {
            return GetItem.GetComponent<GameplayCueComponent>();
        }

        
    }
}