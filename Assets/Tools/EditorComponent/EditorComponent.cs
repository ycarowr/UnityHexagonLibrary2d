using UnityEngine;

namespace Tools.EditorComponent
{
    [ExecuteInEditMode]
    public class EditorComponent : MonoBehaviour
    {
        protected void OnEnable()
        {
            if (!Application.isEditor)
                Destroy(this);
        }
    }
}