using UnityEngine;

namespace StudioScor.GameplayCueSystem
{
    [System.Serializable]
    public struct FGameplayCue
    {
        public static FGameplayCue Default = new FGameplayCue(null, Vector3.zero, Vector3.zero, Vector3.one, 1f);

        public GameplayCue Cue;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
        [Range(0f, 1f)] public float Volume;

        public FGameplayCue(GameplayCue que, Vector3 position, Vector3 rotation, Vector3 scale, float volume)
        {
            Cue = que;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Volume = volume;
        }

        public readonly void Initialization()
        {
            if (Cue)
                Cue.Initialization();
        }
    }

}
