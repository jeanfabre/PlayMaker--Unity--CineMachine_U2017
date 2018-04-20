using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

[RequireComponent(typeof(CinemachineCollider))]
public class ColliderWatcher : MonoBehaviour {

	public bool IsTargetObscured;
	public bool CameraWasDisplaced;

	CinemachineCollider _cache;

	public CinemachineVirtualCameraBase VirtualCamera;

	// Use this for initialization
	void Start () {
		_cache = this.GetComponent<CinemachineCollider> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (_cache != null) {

			VirtualCamera = _cache.VirtualCamera;

			if (_cache.IsTargetObscured (_cache.VirtualCamera)) {
				Debug.Log ("IsTargetObscured");
			}

			if (_cache.CameraWasDisplaced (_cache.VirtualCamera)) {
				Debug.Log ("CameraWasDisplaced");
			}


			IsTargetObscured = _cache.IsTargetObscured (_cache.VirtualCamera);
			CameraWasDisplaced = _cache.CameraWasDisplaced (_cache.VirtualCamera);

		}
	}
}
