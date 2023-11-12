using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [System.Serializable]
    public struct FGameplayCue
    {
        public static FGameplayCue Default = new FGameplayCue(null, Vector3.zero, Vector3.zero, Vector3.one);

        public GameplayCue Cue;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;

        public FGameplayCue(GameplayCue que, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Cue = que;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }

}
