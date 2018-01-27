using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	Ray ray;

	RaycastHit hit;

	public LayerMask transmitterMask;
	public LayerMask transmitterRangeMask;

	public Transform particleHigherOrbit;
	public Transform particleLowerOrbit;

    [SerializeField]
    private GameObject towerModelInstance;

	public Modes mode = Modes.MEO;

	public Transform emitter;

    protected void Awake()
    {
        SetOribitSignal(mode);
    }

	protected void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000, transmitterMask);

        if (hit.collider != null && hit.collider.gameObject == towerModelInstance)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (mode == Modes.MEO || mode == Modes.None)
				{
                    SetOribitSignal(Modes.HEO);
                    DoParticle(particleHigherOrbit);
				}
				else if (mode == Modes.LEO)
                {
                    SetOribitSignal(Modes.MEO);
                    DoParticle(particleHigherOrbit);
                }
			}

			if (Input.GetMouseButtonDown(1))
			{
                if (mode == Modes.MEO || mode == Modes.None)
                {
                    SetOribitSignal(Modes.LEO);
                    DoParticle(particleLowerOrbit);

				}
				else if (mode == Modes.HEO)
                {
                    SetOribitSignal(Modes.MEO);
                    DoParticle(particleLowerOrbit);
                }
			}
		}
	}


    private void DoParticle(Transform particlePrefab)
    {
        Transform t = Instantiate(particlePrefab, emitter.transform);
        t.transform.localPosition = Vector3.zero;
    }

    private void SetOribitSignal(Modes mode)
    {
        Debug.Log("switching tower to " + mode.ToString());
        this.mode = mode;
        emitter.GetComponent<Renderer>().material.SetColor("_TintColor", GameGlobals.GetColorFor(mode));
    }

	void OnMouseExit()
	{
		
	}

	void Start () {
		
	}
}
