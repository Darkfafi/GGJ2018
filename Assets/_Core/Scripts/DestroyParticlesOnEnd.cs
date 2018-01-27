using UnityEngine;

public class DestroyParticlesOnEnd : MonoBehaviour
{
    private ParticleSystem ps;

    protected void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    protected void Update()
    {
        if(!ps.IsAlive())
        {
            Destroy(transform.gameObject);
        }
    }
}
