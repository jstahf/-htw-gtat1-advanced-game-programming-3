using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private VisualEffect explosion;
    void Start()
    {
        explosion = GetComponent<VisualEffect>();
        StartCoroutine(TriggerParticle());

    }

    IEnumerator TriggerParticle()
    {
        while (explosion != null)
        {
            explosion.Reinit();
            yield return new WaitForSeconds(5f);
        }
    }
}
