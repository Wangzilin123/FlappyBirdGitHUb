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
        set 
        {
            status = value;
            UpdateUI();
        }
    }

    public GameObject ReadyPanel;
    public GameObject InGamePanel;
    public GameObject OverPanel;
    public List<Button> StartGameBtn;
    public GameObject player;
    public Button reStartBtn;
    private int score;
    public Text UIscore;
    public int Score
    {
        get { return score; }
        set 
        { 
            this.score = value;
            UIscore.text = "»ý·Ö£º"+ score;
        }
    }

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
        reStartBtn.onClick.AddListener(Restart);
    }
    private void OnDisable()
    {
        for (int i = 0; i < StartGameBtn.Count; i++)
        {
            StartGameBtn[i].onClick.RemoveListener(StartGame);
        }
        reStartBtn.onClick.RemoveListener(Restart);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        Score = 0;
        this.Status = Game_Status.InGame;
        pipeLineManager.StartRun();
        player.GetComponent<Player>().Fly();
        player.GetComponent<Animator>().applyRootMotion = true;
        this.player.GetComponent<Player>().onDeath += Player_Ondeah;
        player.GetComponent<Player>().OnScore += OnPlayerScore;
    }

    void OnPlayerScore(int scorer)
    {
        this.Score += score;
    }
    public void UpdateUI()
    {
        this.ReadyPanel.SetActive(Status == Game_Status.Ready);
        this.InGamePanel.SetActive(Status == Game_Status.InGame);
        this.OverPanel.SetActive(Status == Game_Status.GameOver);
    }

    private void Player_Ondeah ()
    {
        Status = Game_Status.GameOver;
        pipeLineManager.Stop();
    }

    public void Restart()
    {
        Status = Game_Status.Ready;
        pipeLineManager.Init();
        player.GetComponent<Player>().Init();
    }
}
