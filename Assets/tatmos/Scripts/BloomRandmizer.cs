using UnityEngine;
using System.Collections;

public class BloomRandmizer : MonoBehaviour {
	
	FastBloom fb;
	// Use this for initialization
	void Start () {
		fb = GetComponent<FastBloom>();
	}
	
	public float heightScale = 1.0F;
    public float xScale = 1.0F;
	
	// Update is called once per frame
	void Update () {
		
		float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0F);		
		fb.threshhold = height*0.1f;
		
		height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.5F);		
		fb.intensity = height;
		
	}
}
