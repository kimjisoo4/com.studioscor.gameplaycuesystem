using UnityEngine;
using UnityEngine.UIElements;


namespace StudioScor.GameplayCueSystem
{
    public static class GameplayCueSystemUtility
    {
        /// <summary>
        /// Target 을 중심으로 Offset 값을 적용하여 Play.
        /// </summary>
        /// <param name="gameplayCue"> GameplayCue 와 Offset Value</param>
        /// <param name="transformSpace"> Offset Value 를 적용할 Transform Space </param>
        /// <returns></returns>
        public static Cue PlayFromTarget(this FGameplayCue gameplayCue, Transform transformSpace)
        {
            Vector3 position = gameplayCue.Position == default ? transformSpace.position : transformSpace.TransformPoint(gameplayCue.Position);
            Quaternion rotation = gameplayCue.Rotation == default ? transformSpace.rotation : transformSpace.rotation * Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale == default ? transformSpace.localScale : gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.Position = position;
            cue.Rotation = rotation;
            cue.Scale = scale;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// Target 을 중심으로 Offset 값을 적용하여 Play.
        /// </summary>
        /// <param name="gameplayCue"> GameplayCue 와 Offset Value</param>
        /// <param name="transformSpace"> Offset Value 를 적용할 Transform Space </param>
        /// <param name="position"> Position Offset </param>
        /// <param name="rotation"> Rotation Offset </param>
        /// <param name="scale"> new Scale </param>
        /// <returns></returns>
        public static Cue PlayFromTarget(this GameplayCue gameplayCue, Transform transformSpace, Vector3 position = default, Vector3 rotation = default, float scale = 1f)
        {
            position = position == default ? transformSpace.position : transformSpace.TransformPoint(position);
            Quaternion cueRotation = rotation == default ? transformSpace.rotation : transformSpace.rotation * Quaternion.Euler(rotation);
            Vector3 cueScale = scale == default ? transformSpace.localScale : transformSpace.localScale * scale;

            var cue = gameplayCue.GetCue();

            cue.Position = position;
            cue.Rotation = cueRotation;
            cue.Scale = cueScale;

            cue.Play();

            return cue;
        }



        /// <summary>
        /// Collider 의 중심 기준으로 Offset 값을 적용하여 Play
        /// </summary>
        /// <param name="gameplayCue"> GameplayCue 와 Offset Value </param>
        /// <param name="collider"> Offset Vvalue 를 적용할 Collider. Bounds 의 중심을 기준으로 offset 이 적용됨. </param>
        /// <returns></returns>
        public static Cue PlayFromCollider(this FGameplayCue gameplayCue, Collider collider)
        {
            Transform transform = collider.transform;
            Vector3 center = collider.bounds.center;

            Vector3 position = gameplayCue.Position == default ? center : center + transform.TransformDirection(gameplayCue.Position);
            Quaternion rotation = gameplayCue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale == default ? transform.localScale : gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.Position = position;
            cue.Rotation = rotation;
            cue.Scale = scale;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// Collider 의 중심 기준으로 Offset 값을 적용하여 Play
        /// </summary>
        /// <param name="gameplayCue"> 재생될 GameplayQue</param>
        /// <param name="collider"> Offset Vvalue 를 적용할 Collider. Bounds 의 중심을 기준으로 offset 이 적용됨. </param>
        /// <param name="position"> Position Offset </param>
        /// <param name="rotation"> Rotation Offset </param>
        /// <param name="scale"> new Scale </param>
        /// <returns></returns>
        public static Cue PlayFromCollider(this GameplayCue gameplayCue, Collider collider, Vector3 position = default, Vector3 rotation = default, float scale = 1f)
        {
            Transform transform = collider.transform;
            Vector3 center = collider.bounds.center;

            position = position == default ? center : center + transform.TransformDirection(position);
            Quaternion queRotation = rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(rotation);
            Vector3 queScale = scale == default ? transform.localScale : transform.localScale * scale;

            var cue = gameplayCue.GetCue();

            cue.Position = position;
            cue.Rotation = queRotation;
            cue.Scale = queScale;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// 대상의 자식으로 Attach 하여 Play
        /// </summary>
        /// <param name="gameplayCue">GameplayCue 와 Offset Value</param>
        /// <param name="attachTarget">Attach 할 대상</param>
        /// <returns></returns>
        public static Cue PlayAttached(this FGameplayCue gameplayCue, Transform attachTarget)
        {
            Quaternion rotation = gameplayCue.Rotation == default ? Quaternion.identity : Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.AttachTarget = attachTarget;
            cue.StartTarget = attachTarget;
            cue.Position = gameplayCue.Position;
            cue.Rotation = rotation;
            cue.Scale = scale;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// 대상의 자식으로 Attach 하여 Play
        /// </summary>
        /// <param name="gameplayCue">GameplayCue 와 Offset Value</param>
        /// <param name="attachTarget">Attach 할 대상</param>
        /// <param name="localPosition"> Position Offset </param>
        /// <param name="localRotation"> Rotation Offset </param>
        /// <param name="localScale"> new Scale </param>
        /// <returns></returns>
        public static Cue PlayAttached(this GameplayCue gameplayCue, Transform attachTarget, Vector3 localPosition = default, Vector3 localRotation = default, float localScale = 1f)
        {
            Quaternion rotation = localRotation == default ? Quaternion.identity : Quaternion.Euler(localRotation);
            Vector3 scale = Vector3.one * localScale;

            var cue = gameplayCue.GetCue();

            cue.AttachTarget = attachTarget;
            cue.StartTarget = attachTarget;
            cue.Position = localPosition;
            cue.Rotation = rotation;
            cue.Scale = scale;

            cue.Play();

            return cue;
        }




        
    }
}
