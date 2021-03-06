﻿using UnityEngine;
using System.Collections;

public class RotateShip : MonoBehaviour {

	public float Rotationspeed = 90f;
	public float shiprotationspeed = 90f;
	public float minrotation = -60f;
	public float maxrotation = 60f;
	private float targetHrotation = 0;
	private float targetVrotation = 0;
	public float settlespeed = 0.5f;
	private float minyrotation = -720f;
	private float maxyrotation = 720f;
	private float targetyrotation =0;

	public float shipspeed = 30f;

	private bool dobarrel =false;
	private float barrelrotation = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		if(Mathf.Abs(h) >= 0.1f)
		{

			targetHrotation += -1 * h * Time.deltaTime * Rotationspeed;
			targetHrotation = Mathf.Clamp(targetHrotation,minrotation,maxrotation);
	
		}
		else {
			targetHrotation = Mathf.Lerp(targetHrotation, 0f, Time.deltaTime / settlespeed);
		}

	    float v = Input.GetAxis("Vertical");
	    if(Mathf.Abs(v) >= 0.1f)
	    {
			targetVrotation += -1 * v * Time.deltaTime * Rotationspeed;
				targetVrotation = Mathf.Clamp(targetVrotation,minrotation,maxrotation);
			
		}
		else {
				targetVrotation = Mathf.Lerp(targetVrotation, 0f, Time.deltaTime / settlespeed);
			}

		float ry = Input.GetAxis ("Horizontal");

		if(Mathf.Abs(ry) >= 0.1f)
		{
			targetyrotation += 1 * ry * Time.deltaTime * shiprotationspeed;
			//targetyrotation = Mathf.Clamp(targetyrotation,minyrotation,maxyrotation);
			
		}
//	else {
//		targetyrotation = Mathf.Lerp(targetyrotation, 0f, Time.deltaTime / settlespeed);
//		}

	/*	float goforward = Input.GetAxis("Forward");

		if(Mathf.Abs (goforward)>= 0.1f)
		{
			this.gameObject.transform.Translate(0,0,shipspeed * goforward*Time.deltaTime);
		}
		else 
		{
	*/		this.gameObject.transform.Translate(0,0,10f*Time.deltaTime);
	//	}

		if (dobarrel)
		{
			barrelrotation += Time.deltaTime * 720f;

			if(barrelrotation >= 1080f)
			{
				dobarrel = false;
				barrelrotation = 0f;
			}
			else
			{
				//targetHrotation += barrelrotation;
			}
		}

		else if(Input.GetButton("BarrelRow"))
		{
			dobarrel = true;
			barrelrotation = 0f;
		}
		
		Quaternion newangle = Quaternion.identity;
		newangle.eulerAngles = new Vector3 (targetVrotation,targetyrotation,targetHrotation + barrelrotation);
		this.gameObject.transform.localRotation = newangle;

	}
}
