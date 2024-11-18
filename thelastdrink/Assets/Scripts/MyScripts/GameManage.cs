using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManage : MonoBehaviour
{
	public static GameManage instance {  get; private set; }
	public GameObject NPCtalk;
	public GameObject interactButton;
	public GameObject talkButton;
	public GameObject shootButton;

	public bool isCrossMark = false;//�Ƿ�Խ��Ŀ��
	public bool isInBackYard = false;//�Ƿ��ڿ��Ƶĵط�
	public bool isNPCtalk = false;//�Ƿ����̸����
	public bool lightDark = false;
	private void Start()
	{
		instance = this;
		NPCtalk.SetActive(false);
		interactButton.SetActive(false);
		talkButton.SetActive(false);
		shootButton.SetActive(false);
	}
	public void SetCrossMark()
	{
		if (!isCrossMark)
		{
			isCrossMark = true;
			shootButton.SetActive(true);
		}
		else
		{
			isCrossMark = false;
			shootButton.SetActive(false);
		}
	}
	public void SetInBackYard()
	{
		if (!isInBackYard)
		{
			isInBackYard = true;
			interactButton.SetActive(true);
		}
		else
		{
			isInBackYard = false;
			interactButton.SetActive(false);
		}
	}
	public void SetNPCtalk()
	{
		if (!isNPCtalk)
		{
			isNPCtalk = true;
			talkButton.SetActive(true);
		}
		else
		{
			isNPCtalk = false;
			talkButton.SetActive(false);
		}
	}
}
