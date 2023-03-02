using UnityEngine;
using StudioScor.Utilities;

namespace StudioScor.GameplayQueSystem.Utilities
{
    [CreateAssetMenu(menuName = "StudioScor/GameplayQue/QueFX/new PoolVFX", fileName = "VFX_Pool_")]
    public class QuePoolVFX : QueFX, ISerializationCallbackReceiver
    {
        [SerializeField] private SimplePooledObject _Pooled;
        [SerializeField] private int _StartSize = 5;

        private SimplePool _Pool;
        private Transform _Container;

        public SimplePooledObject GetItem
        {
            get
            {
                if (!_Container)
                {
                    var container = new GameObject(name);

                    _Container = container.transform;

                    _Pool = new(_Pooled, _Container, _StartSize);
                }

                return _Pool.Get();
            }
        }

        public void OnAfterDeserialize()
        {
            _Pool = null;
            _Container = null;
        }

        public void OnBeforeSerialize()
        {
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