using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace electv1
{
	public class Bullet : MonoBehaviour 
	{
		[SerializeField] float m_Speed = 12f;

		void Update()
		{
			Movement();
			OffScreen();
		}

		void Movement()
		{
			transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
            
		}

		void OffScreen()
		{
			if (transform.position.z > 110f)
				Destroy(gameObject);
		}

        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Enemy")) 
            {
                Debug.Log("ASTEROID COLLIDED");
                Gameplay.instance.UpdateScore();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
		}
	}
}