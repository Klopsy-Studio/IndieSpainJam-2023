using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Boxophobic;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    
    public GravityAttractor planetAttractor;

    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI currentDayText;
    [SerializeField] Image timerImage;


    public float Timer;
    public float _timer;


    bool dayFinished;

    #region GameStates
    private GameStates _currentGameState;
    public GameStates CurrentGameState
    {
        get
        {
            return _currentGameState;
        }

        set
        {
            _currentGameState = value;

            switch (_currentGameState)
            {
                case GameStates.Night:
                    ChangeToNight();
                    break;
                case GameStates.Shop:
                    ChangeToShop();
                    break;
                case GameStates.Pause:
                    ChangeToPause();
                    break;
                case GameStates.GameOver:
                    ChangeToGameOver();
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangeToNight()
    {
        if(playerCharacter._playerCharacterMovement!= null)
        playerCharacter._playerCharacterMovement.ChangeToMoveSpeed();
    }

    public void ChangeToShop()
    {
        dayFinished = true;
        ReturnAllItems();

        foreach (PoolManager pool in pools)
        {
            pool.enableSpawn = false;
        }

        RenderSettings.skybox = dayMaterial;
        playerCharacter._playerCharacterMovement.ChangeToStopSpeed();
        Invoke("OpenShop", 1f);
    }

    public void ChangeToPause()
    {
        playerCharacter._playerCharacterMovement.ChangeToStopSpeed();
    }

    public void ChangeToGameOver()
    {

    }

    #endregion

    #region Points

    public float pointsMultiplier = 1f;

    [SerializeField]
    private float _points;

    public float Points
    {
        get
        {
            return _points;
        }

        set
        {
            _points = value;
            pointsText.SetText(_points.ToString());
            pointsShop.SetText(_points.ToString());
        }
    }

    public void UpdatePoints(float numberOfPoints)
    {
        Points += numberOfPoints*pointsMultiplier;
    }
    #endregion

    #region Days
    private float _day = 1;

    public float Day
    {
        get
        {
            return _day;
        }

        set
        {
            _day = value;
            currentDayText.SetText("Day: " + _day);
        }
    }

    public void AddAnotherDay()
    {
        Day++;
    }

    #endregion

    public string gameScene;


    public List<FallingObject> objectsInPlanet = new List<FallingObject>();
    public List<PoolManager> pools = new List<PoolManager>();
    public PlayerCharacter playerCharacter;

    public Material nightMaterial;
    public Material dayMaterial;


    [SerializeField] GameObject shopCanvas;
    [SerializeField] TextMeshProUGUI pointsShop;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetTimer();
        ResetTimerImage();
        SetGameState(GameStates.Night);

        foreach(PoolManager pool in pools)
        {
            pool.enableSpawn = true;
        }
    }
    public void Update()
    {
        if(!dayFinished)
        {
            _timer -= Time.deltaTime;

            SetTimerFillAmmount();

            if (_timer <= 0)
            {
                SetGameState(GameStates.Shop);         
            }
        }
    }

    public void OpenShop()
    {
        shopCanvas.gameObject.SetActive(true);
    }

    public void BeginAnotherDay()
    {
        dayFinished = false;
        ResetTimer();
        ResetWeight();
        AddAnotherDay();
        shopCanvas.gameObject.SetActive(false);
        playerCharacter.transform.position = playerCharacter.originalPosition;
        RenderSettings.skybox = nightMaterial;

        foreach (PoolManager pool in pools)
        {
            pool.ChangeValuesFromPools();
            pool.enableSpawn = true;
        }

        SetGameState(GameStates.Night);
    }
    public void AddObjectToList(FallingObject o)
    {
        objectsInPlanet.Add(o);
    }

    public void RemoveObjectFromList(FallingObject o)
    {
        objectsInPlanet.Remove(o);
    }

    public void SetTimerFillAmmount()
    {
        float fraction = _timer / Timer;

        timerImage.fillAmount = fraction;
    }

    public void ReturnAllItems()
    {
        foreach(FallingObject o in objectsInPlanet)
        {
            if(o.markerInGame != null)
            {
                Destroy(o.markerInGame);
            }

            o.DeactivateItself();
        }

        objectsInPlanet.Clear();
    }
    public void ResetTimerImage()
    {
        timerImage.fillAmount = 1;
    }
    public void ResetTimer()
    {
        _timer = Timer;
        timerImage.fillAmount = 1f;
    }

    public void ResetWeight()
    {
        playerCharacter.transform.localScale = new Vector3(1, 1, 1);
        Points = 0;       
    }


    public void SetGameState(GameStates newState)
    {
        CurrentGameState = newState;
    }

}
