using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour 
{
	public Image m_Img;
	public AnimationCurve m_Curve;

	private void Start()
	{
		StartCoroutine (FadeIn ());
	}

	public void FateTo(string FadeOutToScene)
	{
		StartCoroutine (FadeOut (FadeOutToScene));
	}

	private IEnumerator FadeIn()
	{
		float time = 1f;

		while (time > 0f) 
		{
			time -= Time.deltaTime;

			float alpha = m_Curve.Evaluate (time);

			m_Img.color = new Color (0f, 0f, 0f, alpha);

			yield return 0;
		}
	}

	private IEnumerator FadeOut(string scene)
	{
		float time = 0f;

		while (time < 1f) 
		{
			time += Time.deltaTime;

			float alpha = m_Curve.Evaluate (time);

			m_Img.color = new Color (0f, 0f, 0f, alpha);

			yield return 0;
		}

		SceneManager.LoadScene (scene);
	}

}
