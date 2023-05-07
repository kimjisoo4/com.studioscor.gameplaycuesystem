using UnityEngine;


namespace StudioScor.GameplayQueSystem
{
    public static class GameplayQueSystemUtility
    {
        public static void PlayQueAttached(Transform transform, GameplayQue gameplayQue, Vector3 localPosition = default, Vector3 localRotation = default, float localScale = 1f)
        {
            Quaternion rotation = localRotation == default ? Quaternion.identity : Quaternion.Euler(localRotation);
            Vector3 scale = Vector3.one * localScale;

            gameplayQue.PlayQueAttached(transform, localPosition, rotation, scale);
        }
        public static void PlayQue(Transform transform, GameplayQue gameplayQue, Vector3 position = default, Vector3 rotation = default, float scale = 1f)
        {
            position = position == default ? transform.position : transform.TransformPoint(position);
            Quaternion queRotation = rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(rotation);
            Vector3 queScale = scale == default ? transform.localScale : transform.localScale * scale;

            gameplayQue.PlayQue(position, queRotation, queScale);
        }

        public static void PlayQue(Transform transform, FGameplayQue gameplayQue)
        {
            Vector3 position = gameplayQue.Position == default ? transform.position : transform.TransformPoint(gameplayQue.Position);
            Quaternion rotation = gameplayQue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayQue.Rotation);
            Vector3 scale = gameplayQue.Scale == default ? transform.localScale : transform.localScale * gameplayQue.Scale;

            gameplayQue.Que.PlayQue(position, rotation, scale);
        }
    }
}
