using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace SampleSceneAssets.Scripts
{
    /// <summary>
    /// <c>ExplosionTrigger</c> is used to repeatedly trigger the explosion particle effect effect. I created this
    /// Vfx graph by using a trigger event just like a real explosion for example when a rocket hits the ground.
    /// but to use it in the showcase I decided to to trigger it with a set delay. I used a coroutine which
    /// just waits 5 seconds after each explosion
    /// </summary>
    public class ExplosionTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        private VisualEffect _effect;
        void Start()
        {
            _effect = GetComponent<VisualEffect>();
            StartCoroutine(TriggerParticle());

        }

        IEnumerator TriggerParticle()
        {
            while (_effect != null)
            {
                _effect.Reinit();
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
