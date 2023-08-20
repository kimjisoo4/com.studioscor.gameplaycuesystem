using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StudioScor.Utilities;

namespace StudioScor.GameplayQueSystem
{
    public abstract class QueFX : BaseScriptableObject
    {
        public abstract QueComponent PlayQueAttached(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale);
        public abstract QueComponent PlayQue(Vector3 position, Quaternion rotation, Vector3 scale);
    }
}
