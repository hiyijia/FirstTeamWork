﻿using UnityEngine;
using System.Collections;

public class SphereTrigger : MonoBehaviour {

	public Vector3 buf = new Vector3(0,0,0);
	public Cell Super_cell;
	// Use this for initialization
	void Start () {
		Super_cell = GameObject.FindGameObjectWithTag("Cell").GetComponent<Cell>();
	}

	void OnTriggerStay(Collider col)
	{
		float time = 0;
		if(col.tag == "Cub" || col.tag == "Current")
		{
			Cube tmp = this.transform.parent.GetComponent<Cube>();
			if(tmp.ind !=0){
			
				Vector3 force = Super_cell.calcInfluence(tmp.ind,this.transform.parent.position);
				buf = new Vector3(this.transform.parent.position.x - col.transform.position.x,0
				                  ,this.transform.parent.position.z - col.transform.position.z);
				buf.x = 1.9f / buf.x;
				buf.z = 1.9f / buf.z;
				if (Mathf.Abs(buf.x) * 2F > 10F) {
					buf.x = 10F * Mathf.Sign(buf.x);
				}
				if (Mathf.Abs(buf.z) * 2f > 10F) {
					buf.z = 10F * Mathf.Sign(buf.z);
				}
				buf.x += Random.Range(-1,1) / 5f + time * Mathf.Sign(buf.x);
				buf.z += Random.Range(-1,1) / 5f + time * Mathf.Sign(buf.z);
				this.transform.parent.constantForce.force = force;
				this.transform.parent.constantForce.force += buf * 5f;
			}
		}
		time += 0.001f;
	}
	
	// Update is called once per frame
	void Update () {

	}
}