using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    RiverFight riverFight;
    BattleEnemy battleEnemy;
    [SerializeField]
    bool isPlayerTurn = true;
    [SerializeField]
    GameObject Enemygameobject;
    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();
    public static BattleManager instance;
    [SerializeField]
    GameObject gameOverCanvas;
    [SerializeField]
    Button btnRetry;
    [SerializeField]
     GameObject WinCanvas;
    [SerializeField]
    Button btnContinue;
    [SerializeField]
    int maxVida = 100;
    void Awake()
    {
        instance = this;
        btnRetry.onClick.AddListener(Retry);
        btnContinue.onClick.AddListener(Continue);
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemygameobject = enemies[Random.Range(0, enemies.Count - 1)];
        riverFight = GameObject.FindWithTag("Player").GetComponent<RiverFight>();
        battleEnemy = Instantiate(Enemygameobject, new Vector2(-riverFight.transform.position.x, riverFight.transform.position.y),
        transform.rotation).GetComponent<BattleEnemy>();
        CheckForEnemyTurn();
        gameOverCanvas.SetActive(false);
        WinCanvas.SetActive(false);
    }

    public void CheckForEnemyTurn() => StartCoroutine(CheckForEnemyTurnCorutine());

    IEnumerator CheckForEnemyTurnCorutine()
    {
        while (true)
        {
            if(!IsPlayerTurn)
            {
                GetBattleEnemy.Attack();
                break;
            }
            yield return null;
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
    public void Win()
    {
        WinCanvas.SetActive(true);
    }

    void Retry()
    {
        GameManager.instance.GetHealthBar.SetMaxHealth(maxVida);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Continue()
    {
        SceneManager.LoadScene(GameManager.instance.LastSceneName, LoadSceneMode.Single);
    }

    public RiverFight GetRiverFight => riverFight;
    public BattleEnemy GetBattleEnemy => battleEnemy;
    public bool IsPlayerTurn{get => isPlayerTurn; set => isPlayerTurn = value;}
    public void ChangeTurn() => IsPlayerTurn = !IsPlayerTurn;
}
