using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public WaypointManager waypointManager;
    public List<CarController> playerCars;
    public List<CarAIController> aiCars;
    public int laps = 3;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI positionText;

    private float timer = 0f;
    private bool raceStarted = false;
    private Dictionary<CarBaseController, int> carLapCount;

    void Start()
    {
        if (!waypointManager)
        {
            Debug.LogError("WaypointManager non assigné. Veuillez l'ajouter dans l'inspecteur.");
        }

        carLapCount = new Dictionary<CarBaseController, int>();

        foreach (CarController car in playerCars)
        {
            car.SetWaypointManager(waypointManager);
            carLapCount.Add(car, 0);
            car.enabled = false;
        }

        foreach (CarAIController car in aiCars)
        {
            car.SetWaypointManager(waypointManager);
            carLapCount.Add(car, 0);
            car.enabled = false;
        }


        countdownText.gameObject.SetActive(true);
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (raceStarted)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }

        if (Input.GetKeyDown(KeyCode.R) && !raceStarted) // Changez cette ligne
        {
            StartCoroutine(StartCountdown());
        }
    }


    private IEnumerator StartCountdown()
    {
        int countdownValue = 3;
        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1);
            countdownValue--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
        StartRace();
    }

    private void StartRace()
    {
        raceStarted = true;
        foreach (CarController car in playerCars)
        {
            car.enabled = true;
            UpdateLapText(car);
        }

        foreach (CarAIController car in aiCars)
        {
            car.enabled = true;
        }
    }

    public void CarCompletedLap(CarBaseController car)
    {
        carLapCount[car]++;
        if (carLapCount[car] >= laps)
        {
            Debug.Log(car.name + " a fini la course !");
            car.enabled = false; // Désactive le contrôle de la voiture à la fin de la course.
        }
        else
        {
            UpdateLapText(car);
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        int milliseconds = Mathf.FloorToInt((timer - minutes * 60 - seconds) * 100);
        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }

    private void UpdateLapText(CarBaseController car)
    {
        lapText.text = $"Tour {carLapCount[car]} / {laps}";
    }
}
