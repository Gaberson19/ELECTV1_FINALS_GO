using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace electv1
{
	public class Enemy : MonoBehaviour 
	{
		[SerializeField] float m_Speed = 50f;

		void Update()
		{
			Movement();
			OffScreen();
		}

		void OffScreen()
		{
			if (transform.position.z <= -10f)
				Destroy(gameObject);
		}
		
		void Movement()
		{
			transform.Translate(-Vector3.forward * m_Speed * Time.deltaTime);
		}
	}
}