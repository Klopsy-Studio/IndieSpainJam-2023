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
    private float _day;

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
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetTimer();
        ResetTimerImage();
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
            }
        }
    }


    public void SetTimerFillAmmount()
    {
        float fraction = _timer / Timer;

        timerImage.fillAmount = fraction;
    }

    public void ResetTimerImage()
    {
        timerImage.fillAmount = 1;
    }
    public void ResetTimer()
    {
        _timer = Timer;
    }



}
