using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.GameplayCueSystem.Utilities
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayCue/CueFX/new PoolVFX", fileName = "VFX_Pool_")]
    public class CuePoolVFX : CueFX
    {
        [Header(" [ Cue Pool VFX ] ")]
        [SerializeField] private PooledObject _pooled;
        [SerializeField] private int _startSize = 5;

        private SimplePool _pool;
        private Transform _container;

        public PooledObject GetItem
        {
            get
            {
                if (!_container)
                    CreatePool();

                return _pool.Get();
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            _pool = null;
            _container = null;
        }

        private void CreatePool()
        {
            var container = new GameObject($"[Pool] {name}");

            this._container = container.transform;

            _pool = new(_pooled, this._container, _startSize);
        }

        public override void Initialization()
        {
            base.Initialization();

            if (!_container)
                CreatePool();
        }


        public override ICueActor GetCueActor()
        {
            return GetItem.GetComponent<GameplayCueComponent>();
        }

        
    }
}