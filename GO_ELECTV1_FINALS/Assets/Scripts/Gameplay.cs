using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace electv1
{
	public class Gameplay : MonoBehaviour 
	{
		public static Gameplay instance;
		public const float X_BOUND = 4.15f;
		public static Vector2 Y_BOUND;

		int m_Score;
		[SerializeField] Text m_ScoreTxt;
		[SerializeField] GameObject m_Enemy;

		void Awake()
		{
			instance = this;
			Y_BOUND = new Vector2(-0.78f, 2.22f);
			Application.targetFrameRate = 60;
		}

		void OnDestroy()
		{
			instance = null;
		}

		void Start()
		{
			m_Enemy.SetActive(false);
			UpdateScore(_ToNormalize: true);
			StartCoroutine(CreateEnemies());
		}

		public void UpdateScore(bool _ToNormalize = false)
		{
			if (_ToNormalize)
				m_Score = 0;
			else
				m_Score++;

			m_ScoreTxt.text = m_Score.ToString();
		}

		IEnumerator CreateEnemies()
		{
			yield return new WaitForSeconds(0.5f);

			while (true)
			{
				for (int i = 0; i < Random.Range(1, 5); i++)
				{
					GameObject _e = Instantiate(m_Enemy, new Vector3(Random.Range(-X_BOUND, X_BOUND), Random.Range(Y_BOUND.x, Y_BOUND.y), 110f), Quaternion.identity);
					_e.SetActive(true);
				}

				yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
			}
		}
	}
}