using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraTargeting : MonoBehaviour
{
	// Which layers targeting ray must hit (-1 = everything)
	public LayerMask targetingLayerMask = -1;
	
	// Targeting ray length
	private float targetingRayLength = Mathf.Infinity;
	
	// Camera component reference
	private Camera cam;
	
	void Awake()
	{
		cam = GetComponent<Camera>();
	}
	
	void Update()
	{
		TargetingRaycast();
	}
	
	public void TargetingRaycast()
	{
		// Current mouse position on screen
		Vector3 mp = Input.mousePosition;
		
		// Current target object transform component
		Transform targetTransform = null;
		
		// If camera component is available
		if (cam != null)
		{
			RaycastHit hitInfo;

			Ray ray = cam.ScreenPointToRay(new Vector3(mp.x, mp.y, 0f));

			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, targetingRayLength, targetingLayerMask.value))
			{
				targetTransform = hitInfo.collider.transform;
			}
		}

		if (targetTransform != null)
		{
			HighlightableObject ho = targetTransform.root.GetComponentInChildren<HighlightableObject>();
			if (ho != null)
			{
				if (Input.GetButtonDown("Fire1"))
				{
					//显示信息
				}

				ho.On(Color.red);
			}
		}
	}
}
