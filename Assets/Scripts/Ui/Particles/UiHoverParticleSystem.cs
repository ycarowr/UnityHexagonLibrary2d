using UnityEngine;

namespace HexBoardGame.UI
{
    public class UiHoverParticleSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private Renderer[] renderers;

        public void Show(int layer = -1)
        {
            if (layer > 0)
                foreach (var i in renderers)
                    i.sortingOrder = layer;
            foreach (var i in particles)
                i.Play();
        }

        public void Hide(int layer = -1)
        {
            if (layer > 0)
                foreach (var i in renderers)
                    i.sortingOrder = layer;

            foreach (var i in particles)
            {
                i.Stop();
                i.Clear();
            }
        }
    }
}