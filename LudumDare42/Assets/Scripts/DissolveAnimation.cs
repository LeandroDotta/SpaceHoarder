using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveAnimation : MonoBehaviour {

	[Range(0, 1)]
	public float dissolve;

	private Renderer render;

	private void Start() 
	{
		render = GetComponentInChildren<Renderer>();
		render.material.SetFloat("Dissolve", 0.5f);
	}
}
