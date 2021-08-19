using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TouchInuputManager : MonoBehaviour
{
    [Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [SerializeField] float delay = 2;

    [SerializeField] UnityEvent onTouch;
    [SerializeField] UnityEvent onTouchCancel;
    [SerializeField] AnimationCurve timeUpdateCurve;
    [SerializeField] FloatEvent onTouchTimerUpdate;
    [SerializeField] UnityEvent onTouchTimerEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            switch( Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    timer = 0;
                    onTouch.Invoke();
                    break;
                case TouchPhase.Ended:
                    Cancel();
                    break;
                default:
                    timer += Time.deltaTime;
                    onTouchTimerUpdate.Invoke(timeUpdateCurve.Evaluate(Mathf.InverseLerp(0, delay, timer)));
                    if (timer > delay)
                    {
                        onTouchTimerEnd.Invoke();
                    }
                    break;
            }
        }
    }

    void Cancel()
    {
        timer = 0;
        onTouchTimerUpdate.Invoke(timeUpdateCurve.Evaluate(Mathf.InverseLerp(0, delay, timer)));
        onTouchCancel.Invoke();
    }

    private void OnDisable()
    {
        if(Input.touchCount > 0)
        {
            Cancel();
        }
        
    }
}
