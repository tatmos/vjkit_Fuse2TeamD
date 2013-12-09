using UnityEngine;
using System.Collections;

public class YukaMove : MonoBehaviour {
	
	TrailRenderer tr;
	
	// Use this for initialization
	void Start () {
	 tr = GetComponent<TrailRenderer>();
	}
	
	public float speed = 0.1f;
	public float rotateSpeed = 0.1f;
	public float rotateDistance = 0;
	
	public float lifeTime = 6f;
	
	public float bpm = 107;
	
	void Update () {
		
		float bpmGain =  (bpm)/60;
		float timeSinceLevelLoadCustom = Time.timeSinceLevelLoad*bpmGain;
		
		float tmpSpeed = speed *  Mathf.Cos(timeSinceLevelLoadCustom);
		
		this.transform.Translate(tmpSpeed*rotateDistance,tmpSpeed*rotateDistance,tmpSpeed*rotateDistance,Space.Self);		
		this.transform.Rotate(4+ tmpSpeed*rotateDistance*0.01f,0,0,Space.Self);
		
		rotateDistance += (Time.deltaTime* 0.4f)* Mathf.Abs( Mathf.Sin(Time.timeSinceLevelLoad));
		
		lifeTime -= Time.deltaTime;
		
		this.renderer.material.SetColor("_Color",new Color(1,1,lifeTime,lifeTime));
		
		tr.startWidth = lifeTime;
		
		if(	lifeTime < 0){
			//PhotonNetwork.Destroy(this.gameObject);
			GameObject.Destroy(this.gameObject);
		}
	}
}
