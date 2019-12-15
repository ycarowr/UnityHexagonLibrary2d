using UnityEngine;

namespace Tools.DialogSystem
{
    [CreateAssetMenu(menuName = "DialogSystem/Parameters")]
    public class Parameters : ScriptableObject
    {
        //------------------------------------------------------------------------------------------------------------
        [SerializeField]
        [Tooltip("Characters per second.")]
        [Range(50, 2000)]
        public int speed = 300;
    }
}