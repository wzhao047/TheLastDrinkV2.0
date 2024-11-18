using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterControl : MonoBehaviour
{
	public GameObject LightDarkObject;
	bool isInBackYard = false;
	public void OnClickInteract()
	{
		if (!isInBackYard)
		{
			LightDarkObject.SetActive(true);
			isInBackYard = true;
			GameManage.instance.lightDark = true;
		}
		else
		{
			LightDarkObject.SetActive(false);
			isInBackYard = false;
			GameManage.instance.lightDark = false;
		}
	}
	public void OnClickShoot()
	{
		if (GameManage.instance.lightDark)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		}
	}
	public void OnClickTalk()
	{
		if (!GameManage.instance.isNPCtalk)
		{
			GameManage.instance.NPCtalk.SetActive(true);
			GameManage.instance.isNPCtalk = true;
		}
		else
		{
			GameManage.instance.NPCtalk.SetActive(false);
			GameManage.instance.isNPCtalk = false;
		}
	}
}
