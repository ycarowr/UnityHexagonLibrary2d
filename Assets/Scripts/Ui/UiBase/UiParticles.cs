using System.Collections;
using Game.Ui;
using UnityEngine;

namespace HexCardGame.UI
{
    public class UiParticles : UiEventListener
    {
        protected ParticleSystem[] Particles { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Particles = GetComponentsInChildren<ParticleSystem>();
        }

        protected virtual IEnumerator Play(float delay = 0)
        {
            yield return new WaitForSeconds(delay);

            foreach (var particleSys in Particles)
                if (particleSys != null)
                    particleSys.Play();
        }
    }
}