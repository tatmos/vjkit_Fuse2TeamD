using UnityEngine;
using System.Collections;

public class YukaManager: MonoBehaviour {
	
	public GameObject yuka;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void YukaBorn (float note) {
		if(note > 0){
			GameObject go = GameObject.Instantiate(yuka) as GameObject;
			go.transform.localPosition = new Vector3(-8,note-8,0);
			
			GameObject.Destroy(go,4f);
		}
	}
}
