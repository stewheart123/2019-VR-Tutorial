using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this to stop errors if the script is added to a component without renderer
[RequireComponent (typeof (Renderer))]


public class MaterialGradientModifier : MonoBehaviour
{
    Renderer _renderer;

    [SerializeField] Gradient gradient;

    float _gradientPosition = -1;
    public float gradientPosition
    {
        get { return _gradientPosition; }
        set
        {
            if (_gradientPosition != value)
            {
                _gradientPosition = value;
                _renderer.material.color = gradient.Evaluate(_gradientPosition);
            }
        }
    }

    //void SetGradientPosition(float position)
    //{
    //    if(position == gradientPosition)
    //    {
    //        return;
    //    }
    //    gradientPosition = position;
    //    _renderer.material.color = gradient.Evaluate(gradientPosition);                
    //}

   // public Color myColor;
    
    //starts prior to awake
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        //SetGradientPosition(0);
        gradientPosition = 0;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    SetGradientPosition(Mathf.Sin (( (Time.time)) * 0.5f ) + 0.5f);
    //}
}
