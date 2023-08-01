using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.GameplayQueSystem.Utilities
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayQue/QueFX/new PoolVFX", fileName = "VFX_Pool_")]
    public class QuePoolVFX : QueFX
    {
        [SerializeField] private SimplePooledObject pooled;
        [SerializeField] private int startSize = 5;

        private SimplePool pool;
        private Transform container;

        public SimplePooledObject GetItem
        {
            get
            {
                if (!container)
                {
                    var container = new GameObject(name);

                    this.container = container.transform;

                    pool = new(pooled, this.container, startSize);
                }

                return pool.Get();
            }
        }

        protected override void OnReset()
        {
            base.OnReset();

            pool = null;
            container = null;
        }

        public override void PlayQueAttached(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var item = GetItem;

            item.SetParent(transform);

            item.SetLocalPositionAndRotation(position, rotation);
            item.transform.localScale = scale;

            item.gameObject.SetActive(true);
        }

        public override void PlayQue(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var item = GetItem;

            item.SetPositionAndRotation(position, rotation);
            item.transform.localScale = scale;

            item.gameObject.SetActive(true);
        }
    }
}