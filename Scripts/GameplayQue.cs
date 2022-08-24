﻿using UnityEngine;


namespace KimScor.GameplayTagSystem.GameplayQue
{
    [CreateAssetMenu(menuName ="GAS/GameplayQue/new GameplayQue", fileName = "Que_")]
    public class GameplayQue : ScriptableObject
    {
        [SerializeField] private GameplayTag _Tag;
        [SerializeField] private QueFX[] _QueFXs;

        public bool TryPlayQue(GameplayTag tag, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            if (CanPlayQue(tag))
            {
                PlayQue(position, rotation, scale);

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool CanPlayQue(GameplayTag tag)
        {
            return _Tag == tag;
        }

        public void PlayQue(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            foreach (QueFX fX in _QueFXs)
            {
                fX.Play(position, rotation, scale);
            }
        }
    }
}
