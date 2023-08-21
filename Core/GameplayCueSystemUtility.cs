using UnityEngine;
using UnityEngine.UIElements;


namespace StudioScor.GameplayCueSystem
{
    public static class GameplayCueSystemUtility
    {
        public static Cue PlayCueAttached(Transform transform, GameplayCue gameplayCue, Vector3 localPosition = default, Vector3 localRotation = default, float localScale = 1f)
        {
            Quaternion rotation = localRotation == default ? Quaternion.identity : Quaternion.Euler(localRotation);
            Vector3 scale = Vector3.one * localScale;

            var cue = gameplayCue.GetCue();

            cue.AttachTarget = transform;
            cue.StartPosition = localPosition;
            cue.StartRotation = rotation;
            cue.StartScale = scale;

            cue.Play();

            return cue;
        }
        public static Cue PlayCueAttached(Transform transform, FGameplayCue gameplayCue)
        {
            Vector3 position = gameplayCue.Position == default ? transform.position : transform.TransformPoint(gameplayCue.Position);
            Quaternion rotation = gameplayCue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale == default ? transform.localScale : transform.localScale * gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.AttachTarget = transform;
            cue.StartPosition = position;
            cue.StartRotation = rotation;
            cue.StartScale = scale;

            cue.Play();

            return cue;
        }


        public static Cue PlayCueFromTarget(Transform transform, GameplayCue gameplayCue, Vector3 position = default, Vector3 rotation = default, float scale = 1f)
        {
            position = position == default ? transform.position : transform.TransformPoint(position);
            Quaternion cueRotation = rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(rotation);
            Vector3 cueScale = scale == default ? transform.localScale : transform.localScale * scale;

            var cue = gameplayCue.GetCue();

            cue.StartPosition = position;
            cue.StartRotation = cueRotation;
            cue.StartScale = cueScale;

            cue.Play();

            return cue;
        }
        public static Cue PlayCueFromTarget(Transform transform, FGameplayCue gameplayCue)
        {
            Vector3 position = gameplayCue.Position == default ? transform.position : transform.TransformPoint(gameplayCue.Position);
            Quaternion rotation = gameplayCue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale == default ? transform.localScale : transform.localScale * gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.StartPosition = position;
            cue.StartRotation = rotation;
            cue.StartScale = scale;

            cue.Play();

            return cue;
        }

        public static Cue PlayCueFromCollider(Collider collider, FGameplayCue gameplayCue)
        {
            Transform transform = collider.transform;
            Vector3 center = collider.bounds.center;

            Vector3 position = gameplayCue.Position == default ? center : center + transform.TransformDirection(gameplayCue.Position);
            Quaternion rotation = gameplayCue.Rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(gameplayCue.Rotation);
            Vector3 scale = gameplayCue.Scale == default ? transform.localScale : transform.localScale * gameplayCue.Scale;

            var cue = gameplayCue.Cue.GetCue();

            cue.StartPosition = position;
            cue.StartRotation = rotation;
            cue.StartScale = scale;

            cue.Play();

            return cue;
        }

        public static Cue PlayQueFromCollider(Collider collider, GameplayCue gameplayCue, Vector3 position = default, Vector3 rotation = default, float scale = 1f)
        {
            Transform transform = collider.transform;
            Vector3 center = collider.bounds.center;

            position = position == default ? center : center + transform.TransformDirection(position);
            Quaternion queRotation = rotation == default ? transform.rotation : transform.rotation * Quaternion.Euler(rotation);
            Vector3 queScale = scale == default ? transform.localScale : transform.localScale * scale;

            var cue = gameplayCue.GetCue();

            cue.StartPosition = position;
            cue.StartRotation = queRotation;
            cue.StartScale = queScale;

            cue.Play();

            return cue;
        }
    }
}
