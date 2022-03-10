using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace electv1
{
	public class Player : MonoBehaviour 
	{
		[SerializeField] float m_Speed = 5.5f;
		[SerializeField] GameObject m_Bullet;
		bool canShoot { get;set; }

        void Start()
		{
			m_Bullet.SetActive(false);
			canShoot = true;
		}

		void Update()
		{
			Shoot();
			Movement();
			Bound();
		}

		void Shoot()
		{
			if (Input.GetKey(KeyCode.Space) && canShoot)
			{
				GameObject _b = Instantiate(m_Bullet, transform.position, Quaternion.identity);
				_b.SetActive(true);
				canShoot = false;
				Invoke("CanShootAgain", 0.15f);
			}
		}

		void CanShootAgain()
		{
			canShoot = true;
		}

		void Movement()
		{
            
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * m_Speed, Input.GetAxis("Vertical") * Time.deltaTime * m_Speed, 0f);
		}

		void Bound()
		{
			float _xbound = Gameplay.X_BOUND;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xbound, _xbound), Mathf.Clamp(transform.position.y, Gameplay.Y_BOUND.x, Gameplay.Y_BOUND.y), -1.43f);
		}
	}
}