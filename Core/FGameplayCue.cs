using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [System.Serializable]
    public struct FGameplayCue
    {
        public GameplayCue Cue;
        public Vector3 Position;
        public Vector3 Rotation;
        public float Scale;

        public FGameplayCue(GameplayCue que, Vector3 position, Vector3 rotation, float scale)
        {
            Cue = que;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }

}
