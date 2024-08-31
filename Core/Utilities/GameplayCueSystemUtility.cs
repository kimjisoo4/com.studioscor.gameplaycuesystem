using UnityEngine;


namespace StudioScor.GameplayCueSystem
{
    public static class GameplayCueSystemUtility
    {
        public static Cue Play(this FGameplayCue gameplayCue)
        {
            var cue = gameplayCue.Cue.GetCue();

            cue.Position = gameplayCue.Position;
            cue.Rotation = Quaternion.Euler(gameplayCue.Rotation);
            cue.Scale = gameplayCue.Scale;
            cue.Volume = gameplayCue.Volume;

            cue.Play();

            return cue;
        }
        public static Cue Play(this GameplayCue gameplayCue, Vector3 position, Vector3 rotation, Vector3 scale, float volume)
        {
            var cue = gameplayCue.GetCue();

            cue.Position = position;
            cue.Rotation = Quaternion.Euler(rotation);
            cue.Scale = scale;
            cue.Volume = volume;

            cue.Play();

            return cue;
        }
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
            cue.Volume = gameplayCue.Volume;

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
        public static Cue PlayFromTarget(this GameplayCue gameplayCue, Transform transformSpace, Vector3 position, Vector3 rotation, Vector3 scale, float volume)
        {
            position = position == default ? transformSpace.position : transformSpace.TransformPoint(position);
            Quaternion cueRotation = rotation == default ? transformSpace.rotation : transformSpace.rotation * Quaternion.Euler(rotation);
            Vector3 cueScale = scale == default ? transformSpace.localScale : scale;

            var cue = gameplayCue.GetCue();

            cue.Position = position;
            cue.Rotation = cueRotation;
            cue.Scale = cueScale;
            cue.Volume = volume;

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
            cue.Volume = gameplayCue.Volume;

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
        public static Cue PlayFromCollider(this GameplayCue gameplayCue, Collider collider, Vector3 position, Vector3 rotation, float scale, float volume)
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
            cue.Volume = volume;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// 대상의 자식으로 Attach 하여 Play
        /// </summary>
        /// <param name="gameplayCue">GameplayCue 와 Offset Value</param>
        /// <param name="attachTarget">Attach 할 대상</param>
        /// <returns></returns>
        public static Cue PlayAttached(this FGameplayCue gameplayCue, Transform attachTarget, bool useStayWorldPosition = false)
        {
            Quaternion rotation = gameplayCue.Rotation == default ? Quaternion.identity : Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.AttachTarget = attachTarget;
            cue.StartTarget = attachTarget;
            cue.Position = gameplayCue.Position;
            cue.Rotation = rotation;
            cue.Scale = scale;
            cue.UseStayWorldPosition = useStayWorldPosition;
            cue.Volume = gameplayCue.Volume;

            cue.Play();

            return cue;
        }

        /// <summary>
        /// 대상의 자식으로 Attach 하여 Play
        /// </summary>
        /// <param name="gameplayCue">GameplayCue 와 Offset Value</param>
        /// <param name="attachTarget">Attach 할 대상</param>
        /// <param name="position"> Position Offset </param>
        /// <param name="eulerRotation"> Rotation Offset </param>
        /// <param name="scale"> new Scale </param>
        /// <returns></returns>
        public static Cue PlayAttached(this GameplayCue gameplayCue, Transform attachTarget, Vector3 position, Vector3 eulerRotation, Vector3 scale, float volume, bool useStayWorldPosition = false)
        {
            Quaternion quaRotation = eulerRotation == default ? Quaternion.identity : Quaternion.Euler(eulerRotation);

            var cue = gameplayCue.GetCue();

            cue.AttachTarget = attachTarget;
            cue.StartTarget = attachTarget;
            cue.Position = position;
            cue.Rotation = quaRotation;
            cue.Scale = scale;
            cue.UseStayWorldPosition = useStayWorldPosition;
            cue.Volume = volume;

            cue.Play();

            return cue;
        }




        
    }
}
