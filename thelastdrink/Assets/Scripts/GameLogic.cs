using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 添加这一行以使用 SceneManager
using TMPro;  // 引入TextMeshPro命名空间


public class GameLogic : MonoBehaviour
{
    // 场景中的主要对象
    public GameObject backdoor;
    public GameObject backYardOff; // 停电后的后院
    public GameObject barRoomOff;  // 停电后的酒吧
    public Transform backYardParent;
    public Transform barRoomParent;
    public Transform playerTransform;       // 玩家
    public Transform backYardOffPosition;   // 停电后的后院位置
    public Transform barRoomOffPosition;    // 酒吧停电后的位置
    public GameObject roomLight;  //房间亮时的精灵


    // 保存玩家和相机的初始位置
    private Vector3 previousPlayerPosition;
    private Vector3 previousCameraPosition;

    // 游戏状态标记
    public bool talkedToNPC = false;    // 标记玩家是否与 NPC 交谈
    public bool lightsOff = false;      // 标记关灯状态
    private bool gameCompleted = false;

    public GameObject dialogueTextBox;   // 对话框
    public TMP_Text dialogueText;        // 对话框中的文本


    public MusicManager musicManager;


    // 初始化
    void Start()
    {
        // 确保BackDoor在游戏开始时不可用
        backdoor.SetActive(false);

        if (dialogueTextBox == null || dialogueText == null)
        {
            Debug.LogError("dialogueTextBox or dialogueText is not assigned in the Inspector!");
            return;
        }

        dialogueTextBox.SetActive(false);  // 游戏开始时隐藏对话框
    }

    public void TalkToNPC()
    {
        // 检查对话框是否已经存在
        if (dialogueTextBox.activeSelf)
        {
            // 如果对话框已经存在，则隐藏它
            dialogueTextBox.SetActive(false);
            Debug.Log("NPC text hidden.");
        }
        else
        {
            // 如果对话框不存在，则显示对话框并设置文本
            dialogueTextBox.SetActive(true);
            dialogueText.text = "Last week, someone deliberately turned off the switch at the back door of the residential building next door, causing a power outage in the entire building.";
            Debug.Log("NPC text shown.");
        }
    }



    // 玩家和后门（BackDoor）交互：移动到后院
    public void InteractWithBackDoor()
    {
        Debug.Log("Interacting with BackDoor. Moving to BackYard...");

        // 检查 BackYardOffPosition 是否有效
        if (backYardOffPosition == null)
        {
            Debug.LogError("BackYardOffPosition is not assigned!");
            return;
        }

        // 保存原始位置
        previousPlayerPosition = playerTransform.position;
        previousCameraPosition = Camera.main.transform.position;

        // 移动玩家和相机到 BackYardOff 的位置
        playerTransform.position = backYardOffPosition.position;
        Camera.main.transform.position = new Vector3(backYardOffPosition.position.x, backYardOffPosition.position.y, previousCameraPosition.z);

        Debug.Log("Player and Camera moved to BackYard.");
    }

    // 玩家在后院触发LightsOff逻辑
    public void InteractWithBackYard()
    {
		
		Debug.Log("Player interacted with BackYard. Lights off sequence starts!");
        StartCoroutine(LightsOff());

    }

    // 处理关灯后的逻辑
    public IEnumerator LightsOff()
    {
        if (!lightsOff)  // 确保 lightsOff 只执行一次
        {
			lightsOff = true;
            Debug.Log("Lights are now off. Interactions will no longer trigger alerts.");
			roomLight.SetActive(false);
			//// 检查玩家是否按下交互按钮
			//bool isInteracted = false;

			//while (!isInteracted)
			//{
			//    // 等待玩家按下交互按钮
			//    if (Input.GetButtonDown("Interact")) // 假设 "Interact" 是交互按钮的输入名称
			//    {
			//        Debug.Log("Player pressed the interact button. Proceeding with LightsOff sequence...");
			//        isInteracted = true;

			//        // 替换 BarRoom 和 BackYard 为关灯后的状态
			//        ReplaceGameObjects();

			//        // 立即让玩家和相机返回 BarRoomOff
			//        BackToBarRoomOff();

			//        // 开始 15 秒倒计时，若未完成游戏，则加载失败场景
			//        StartCoroutine(LightsOffCountdown(15f));
			//    }

			//    yield return null; // 等待下一帧
			//}
		}
        else
        {
            Debug.Log("Lights are already off, skipping replacement.");
        }

        yield return null;
    }

    // 替换房间和后院为停电后的状态
    void ReplaceGameObjects()
    {
        // 销毁当前的 BackYard 和 BarRoom 对象，并替换成停电后的状态
        if (backYardOff && barRoomOff)
        {
            // 在需要的地方实例化替代对象
            Instantiate(backYardOff, backYardOffPosition.position, Quaternion.identity, backYardParent);
            Instantiate(barRoomOff, barRoomOffPosition.position, Quaternion.identity, barRoomParent);
        }
        else
        {
            Debug.LogError("BackYardOff or BarRoomOff is not assigned in the Inspector.");
        }
    }

    private void BackToBarRoomOff()
    {
        // 玩家和相机立即返回到酒吧的停电状态
        playerTransform.position = previousPlayerPosition;
        Camera.main.transform.position = new Vector3(previousCameraPosition.x, previousCameraPosition.y, previousCameraPosition.z);

        Debug.Log("Player and Camera returned to BarRoomOff immediately.");
    }

    // 倒计时结束后加载失败场景
    IEnumerator LightsOffCountdown(float countdownTime)
    {
        yield return new WaitForSeconds(countdownTime);

        if (!GameCompleted()) // 若游戏未完成，加载失败场景
        {
            LoadTimeoutScene();
        }
    }

    void LoadTimeoutScene()
    {
        Debug.Log("Mission failed! Loading timeout scene...");
        SceneManager.LoadScene("TimesOutScene");
    }

    // 与玻璃互动时判定胜利
    public void InteractWithGlass()
    {
        // 只有在关灯状态下交互才算胜利
        if (lightsOff)
        {
            Debug.Log("Player interacted with glass during lights off. Victory!");
            LoadVictoryScene();
        }
        else
        {
            Debug.Log("Player interacted with glass, but lights are still on. No victory yet.");
        }
    }

    // 加载胜利场景
    public void LoadVictoryScene()
    {
        Debug.Log("Loading EndScene. Game won!");
        SceneManager.LoadScene("EndScene");
    }

    bool GameCompleted()
    {
        return gameCompleted;
    }
}