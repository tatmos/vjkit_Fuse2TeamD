using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PhotonView))]
//public class YukaManager: Photon.MonoBehaviour {
public class YukaManager: MonoBehaviour {	
	
	public GameObject yuka;
	public float yGain = 1f;
	public float yOffset = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	float lastTime = 0;
	float lastNote = 0;
	float yukaSize = 2;
	float yukaSizeReduce = 0;
	public float noteLife = 6f;
	
	public float rotSpeed = 4;	
	public float bpm = 107;
	
	public float beatCount  =0;
	public float barCount  =0;
	public int drumCount = 0;
	
	void YukaBorn (float note) {		
		//Debug.Log("note =  " + note.ToString());		
		
		float bpmGain =  (bpm)/60;
		float timeSinceLevelLoadCustom = Time.timeSinceLevelLoad*bpmGain;
		beatCount = (int)timeSinceLevelLoadCustom;
		barCount = (int)timeSinceLevelLoadCustom/4;
		
		if(lastTime + 0.05f < timeSinceLevelLoadCustom)
		{
			if(yukaSize-yukaSizeReduce > 0){
				
				Vector3 pos = new Vector3(
					transform.position.x ,
					transform.position.y + (note)*yGain+yOffset,
					transform.position.z);
				
				//GameObject go = PhotonNetwork.Instantiate(yuka.name, pos, Quaternion.identity, 0) as GameObject;
				GameObject go = GameObject.Instantiate(yuka,pos,Quaternion.identity) as GameObject;
				
				go.transform.parent = this.transform;
				
				//go.transform.localPosition = pos;//new Vector3(transform.localPosition.x ,transform.localPosition.y + (note)*yGain+yOffset,transform.localPosition.z);
				//go.transform.Rotate(new Vector3(transform.localRotation.x+Time.timeSinceLevelLoad,transform.localRotation.y,transform.localRotation.z));		
				go.transform.localScale = new Vector3( yukaSize-yukaSizeReduce,1,0.1f);
				
				go.transform.localRotation = this.transform.localRotation;
				
				YukaMove yukamove = go.GetComponent<YukaMove>();
				
				yukamove.rotateSpeed = Mathf.Sin(timeSinceLevelLoadCustom);
				yukamove.speed = Mathf.Abs( Mathf.Cos(timeSinceLevelLoadCustom));
				
				if(barCount > 8){
					yukamove.lifeTime = noteLife + barCount/8;
					yukamove.speed = ((int)(barCount/8))*0.1f;
				} else {
					yukamove.lifeTime = noteLife;
				}
				
				
				//GameObject.Destroy(go,6f);
			}
			
			lastTime = timeSinceLevelLoadCustom;	
			
			if(lastNote == note)
			{
				yukaSizeReduce += 0.2f;
			} else {
				yukaSizeReduce = 0;
				lastNote = note;
			}
			
		}
	}
	
	void DrumOn(float v)
	{
		//this.transform.localScale.Scale(new Vector3(1+v*10f,1,1));
		drumCount++;
	}
		
}
