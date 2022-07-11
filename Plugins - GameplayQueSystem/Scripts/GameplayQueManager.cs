using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KimScor.GameplayTagSystem.GameplayQue
{
    public class GameplayQueManager : MonoBehaviour
    {
        [SerializeField] private GameplayQue[] _Ques;

        private static GameplayQueManager _Instance = null;
        public static GameplayQueManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindObjectOfType<GameplayQueManager>();
                }

                return _Instance;
            }
        }

        void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
        }


        public void PlayQue(GameplayTag tag, Vector3 position = default, Quaternion rotation = default)
        {
            foreach (GameplayQue que in _Ques)
            {
                if(que.TryPlayQue(tag, position, rotation))
                {
                    break;
                }
            }
        }
    }
}
