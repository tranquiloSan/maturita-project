using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	#region Variables


    [Header("Game over")]
	public GameObject gameOverUI;
	public GameObject winLevelUI;

    [Header("Blink")]
    public RawImage blinkActive;
	public Image cooldownBlinkImage;

    [Header("Invisibility")]
    public RawImage invisibilityActive;
	public Image cooldownInvisibilityImage;
	public Image durationInvisibilityImage;


	//can bee reached from every class (only one game manager)
	public static Game instance;
	//dev/cheat mode
	public static bool dev = false;
	#endregion

	#region Unity Methods
	private void Awake()
    {
        Player.PlayerHasEnteredFinish += LoadSceneOnLevelFinish;
		Guard.OnGuardHasSpottedPlayer += ShowGameOverUI;
    }

	private void Start()
	{
		instance = this;
	}

	private void Update()
	{
		//changing scenes
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//DEV MODE (load next scene)
			if (dev)
			{
				LoadSceneOnLevelFinish();
			}
		}

		//dev (cheat) mode activated/deactivated
		if (Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.M))
		{
			dev = !dev;
			print("devMode = " + dev);
		}
	}

	private void OnDestroy()
    {
        Guard.OnGuardHasSpottedPlayer -= ShowGameOverUI;
		Player.PlayerHasEnteredFinish -= LoadSceneOnLevelFinish;
    }

	#endregion
    void LoadSceneOnLevelFinish()
    {
		winLevelUI.SetActive(true);
    }

    void ShowGameOverUI()
    {
		gameOverUI.SetActive(true);
    }

}
