using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
	public float moveSpeed = 5; 
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		float hor = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(hor, 0) * moveSpeed;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Target")
		{
			GameManage.instance.SetCrossMark();
		}
		if(collision.tag == "BackYard")
		{
			GameManage.instance.SetInBackYard();
		}
		if(collision.tag == "NPC")
		{
			GameManage.instance.SetNPCtalk();
		}
	}
}
