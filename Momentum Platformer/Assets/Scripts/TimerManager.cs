using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    [Header("Time Thresholds")]
    public float startingTime;
    public float bronzeScoreTime;
    public float silverScoreTime;
    public float goldScoreTime;

    private float currentTime;
    private bool isTimerPaused;
    private string recievedMedal;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI completionTimeText;
    public TextMeshProUGUI medalText;
    public TextMeshProUGUI medalThresholdsText;
    public GameObject completionText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        completionText.SetActive(false);
        StartTimer();
    }

    void Update()
    {
        if (!isTimerPaused)
        {
            currentTime -= Time.deltaTime;
            //ToString("F1") rounds the time to the first decimal place
            timerText.text = "Time: " + currentTime.ToString("F1");
        }
    }

    public void StartTimer()
    {
        isTimerPaused = false;
        currentTime = startingTime;
    }

    public void PauseTimer()
    {
        isTimerPaused = !isTimerPaused;
    }

    public void CompleteLevel()
    {
        isTimerPaused = true;

        if (currentTime >= goldScoreTime)
        {
            Debug.Log("Completed level: Gold medal recieved");
            recievedMedal = "Gold";
        } else if (currentTime >= silverScoreTime)
        {
            Debug.Log("Completed level: Silver medal recieved");
            recievedMedal = "Silver";
        } else if (currentTime >= bronzeScoreTime)
        {
            Debug.Log("Completed level: Bronze medal recieved");
            recievedMedal = "Bronze";
        } else
        {
            Debug.Log("Completed level: No medal recieved");
            recievedMedal = "None";
        }

        completionText.SetActive(true);
        completionTimeText.text = "Final Time: " + currentTime.ToString("F1");
        medalText.text = " Medal Recieved: " + recievedMedal;

    }
}
