using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    #region Points
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
        }
    }

    public void UpdatePoints(float numberOfPoints)
    {
        Points += numberOfPoints;
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
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetTimer();
        ResetTimerImage();
        

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
                dayFinished = true;
                ResetTimer();
                AddAnotherDay();
                ReturnAllItems();

                foreach (PoolManager pool in pools)
                {
                    pool.enableSpawn = false;
                }

                Invoke("BeginAnotherDay", 1f);

      
            }
        }
    }
    public void BeginAnotherDay()
    {
        dayFinished = false;
        playerCharacter.transform.position = playerCharacter.originalPosition;

        foreach (PoolManager pool in pools)
        {
            pool.enableSpawn = true;
        }
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



}
