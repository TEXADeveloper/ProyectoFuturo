using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    [HideInInspector] public bool isFastTime = false;
    [Header("Speed Settings")]
        [SerializeField] private float maxAcceleration = 4f;
        [SerializeField] private float accelerationSpeed = 1f;
        [SerializeField] private float deaccelerationSpeed = 2f;
    [Header("Time Settings")]
        [SerializeField] private float maxTimeAccelerating = 8f;
    private float timeAccelerating = 0;
    private bool passedTime;
    private Slider accelerationSlider;
    private Slider timeSlider;
    private int input;

    public void Input(int value) { input = value; }

    void Start()
    {
        accelerationSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        accelerationSlider.maxValue = maxAcceleration;
        timeSlider.minValue = maxTimeAccelerating * -1;
        timeSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        updateSliders();
        readInput();
    }

    private void updateSliders()
    {
        if (isFastTime && Time.unscaledTime >= timeAccelerating)
            passedTime = true;
        if (input == 1 && !passedTime)
        {
            timeSlider.value = (timeAccelerating - Time.unscaledTime) * -1;
            timeSlider.gameObject.SetActive(true);
        } else 
        {
            timeSlider.value = 0f;
            timeSlider.gameObject.SetActive(false);
        }
    }

    private void readInput()
    {
        if (input == 1 && !passedTime)
        {
            if (Time.unscaledTime >= timeAccelerating)
                timeAccelerating = Time.unscaledTime + maxTimeAccelerating;
            accelerate();
        } else if (input == 0 || passedTime)
            deaccelerate();
    }

    private void accelerate()
    {
        if (Time.timeScale > maxAcceleration)
            return;
        Time.timeScale += accelerationSpeed * Time.deltaTime;
        isFastTime = true;
        accelerationSlider.value = Time.timeScale;
    }

    private void deaccelerate()
    {
        if (Time.timeScale > 1)
        {
            Time.timeScale -= deaccelerationSpeed * Time.deltaTime;
            isFastTime = false;
            accelerationSlider.value = Time.timeScale;
            return;
        } 
        Time.timeScale = 1;
        passedTime = false;
    }
}
