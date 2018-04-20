// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using UnityEngine;
using Cinemachine;

using HutongGames.PlayMaker;

using HutongGames.PlayMaker.Ecosystem.Utils;

/// <summary>

/// </summary>
public class CinemachineColliderExtensionProxy : MonoBehaviour {


	[UnityEngine.Tooltip("Reference to the CinemachineCollider component")]
	[ExpectComponent(typeof(CinemachineCollider))]
	public Owner ColliderExtension;

	[Header("Events")]
	public PlayMakerEventTarget eventTarget = new PlayMakerEventTarget(true);

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onTargetBecameObscuredEvent= new PlayMakerEvent("CINEMACHINE / COLLIDER / ON TARGET BECAME OBSCURED");

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onTargetBecameVisibleEvent= new PlayMakerEvent("CINEMACHINE / COLLIDER / ON TARGET BECAME VISIBLE");

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onCameraWasDisplacedEvent= new PlayMakerEvent("CINEMACHINE / COLLIDER / ON CAMERA WAS DISPLACED");

	[Header("Variables")]
	public PlayMakerFsmVariableTarget variableTarget = new PlayMakerFsmVariableTarget();

	[FsmVariableTargetVariable("variableTarget")]
	public PlayMakerFsmVariable TargetObscuredVariable = new PlayMakerFsmVariable (VariableSelectionChoice.Bool);

	[FsmVariableTargetVariable("variableTarget")]
	public PlayMakerFsmVariable CameraWasDisplaced = new PlayMakerFsmVariable (VariableSelectionChoice.Bool);


	public bool debug = false;


	public bool IsTargetObscured_x;
	public bool CameraWasDisplaced_x;

	CinemachineCollider _cache;


	// Use this for initialization
	void Start () {
		_cache = ColliderExtension.gameObject.GetComponent<CinemachineCollider> ();

		TargetObscuredVariable.GetVariable(variableTarget);
		CameraWasDisplaced.GetVariable (variableTarget);

	}

	void Update()
	{
		if (_cache.IsTargetObscured (_cache.VirtualCamera)) {
			Debug.Log ("IsTargetObscured");
		}

		if (_cache.CameraWasDisplaced (_cache.VirtualCamera)) {
			Debug.Log ("CameraWasDisplaced");
		}


		IsTargetObscured_x = _cache.IsTargetObscured (_cache.VirtualCamera);
		CameraWasDisplaced_x = _cache.CameraWasDisplaced (_cache.VirtualCamera);


		if (TargetObscuredVariable.initialized) {
			TargetObscuredVariable.FsmBool.Value = _cache.IsTargetObscured(_cache.VirtualCamera);
		}

		if (CameraWasDisplaced.initialized) {
			CameraWasDisplaced.FsmBool.Value = _cache.CameraWasDisplaced (_cache.VirtualCamera);
		}
	}

}
