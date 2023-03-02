using UnityEngine;

namespace StudioScor.GameplayQueSystem
{
    [System.Serializable]
    public struct FGameplayQue
    {
        public GameplayQue Que;
        public Vector3 Position;
        public Vector3 Rotation;
        public float Scale;

        public FGameplayQue(GameplayQue que, Vector3 position, Vector3 rotation, float scale)
        {
            Que = que;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }

}
