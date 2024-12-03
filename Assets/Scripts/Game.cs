using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public  enum Game_Status
    {
        Ready,
        InGame,
        GameOver
    }

    private Game_Status status;

    public Game_Status Status
    {
        get { return status; }
        set { status = value; }
    }

    public GameObject ReadyPanel;
    public GameObject InGamePanel;
    public GameObject OverPanel;
    public List<Button> StartGameBtn;
    public GameObject player;

    public PiepLineManager pipeLineManager;

    // Start is called before the first frame update
    void Start()
    {
        this.ReadyPanel.SetActive(true);
    }
    private void OnEnable()
    {
        for (int i = 0; i < StartGameBtn.Count; i++)
        {
            StartGameBtn[i].onClick.AddListener(StartGame);
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < StartGameBtn.Count; i++)
        {
            StartGameBtn[i].onClick.RemoveListener(StartGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        this.status = Game_Status.InGame;
        UpdateUI();
        pipeLineManager.StartRun();
        player.GetComponent<Player>().Fly();
        player.GetComponent<Animator>().applyRootMotion = true;
        
    }
    public void UpdateUI()
    {
        this.ReadyPanel.SetActive(this.status==Game_Status.Ready);
        this.InGamePanel.SetActive(this.status==Game_Status.InGame);
        this.OverPanel.SetActive(this.status==Game_Status.GameOver);
    }
}
