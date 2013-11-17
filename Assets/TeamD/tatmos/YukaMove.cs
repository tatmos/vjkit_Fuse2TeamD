using UnityEngine;
using System.Collections;

public class YukaMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float speed = 4f;
	// Update is called once per frame
	void Update () {
		this.transform.Translate(speed*Time.deltaTime,0,0);
	}
}
