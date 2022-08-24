using UnityEngine;


namespace KimScor.GameplayTagSystem.GameplayQue
{
    public abstract class QueFX : ScriptableObject
    {
        public abstract void Play(Vector3 position, Quaternion rotation, Vector3 scale);
    }
}
