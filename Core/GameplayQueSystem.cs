using UnityEngine;

namespace StudioScor.GameplayQueSystem
{
    public static class GameplayQueSystem
    {
        public static void SpawnGameplayQue(Transform transform, FGameplayQue gameplayQue)
        {
            Vector3 position = gameplayQue.Position == default ? transform.position : transform.TransformPoint(gameplayQue.Position);
            Quaternion rotation = gameplayQue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayQue.Rotation);
            Vector3 scale = gameplayQue.Scale == default ? transform.localScale : transform.localScale * gameplayQue.Scale;

            gameplayQue.Que.PlayQue(position, rotation, scale);
        }
    }
}
