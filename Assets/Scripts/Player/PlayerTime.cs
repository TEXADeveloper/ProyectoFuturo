using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerTime : MonoBehaviour
{
    [HideInInspector] public bool isFastTime = false;
    [Header("General Settings")]
        [SerializeField] private TimeArea timeArea;
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
    private SliderAnimation accelerationSliderAnim;
    private SliderAnimation timeSliderAnim;
    private int input;

    public void Input(int value) { input = value; }

    void Start()
    {
        accelerationSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        timeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        accelerationSliderAnim = accelerationSlider.gameObject.GetComponent<SliderAnimation>();
        timeSliderAnim = timeSlider.gameObject.GetComponent<SliderAnimation>();
        accelerationSlider.maxValue = maxAcceleration;
        timeSlider.minValue = maxTimeAccelerating * -1;
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
            timeSliderAnim.Trigger("In");
        } else if (!timeSliderAnim.GetOut())
            timeSliderAnim.Trigger("Out");
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
        if (timeArea.TimeMultiplier > maxAcceleration)
            return;
        timeArea.TimeMultiplier += accelerationSpeed * Time.deltaTime * timeArea.TimeMultiplier;
        isFastTime = true;
        timeArea.gameObject.SetActive(true);
        accelerationSliderAnim.Trigger("In");
        accelerationSlider.value = timeArea.TimeMultiplier;
    }

    private void deaccelerate()
    {
        if (timeArea.TimeMultiplier > 1)
        {
            timeArea.TimeMultiplier -= deaccelerationSpeed * Time.deltaTime * timeArea.TimeMultiplier;
            isFastTime = false;
            accelerationSlider.value = timeArea.TimeMultiplier;
            return;
        } 
        accelerationSliderAnim.Trigger("Out");
        timeArea.gameObject.SetActive(false);
        timeArea.TimeMultiplier = 1;
        passedTime = false;
    }
}
