using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IGButton : MonoBehaviour
{
    public UnityEvent onButtonDown, onButtonUp;
    
    [SerializeField] private float pressThreshold = .1f;
    [SerializeField] private float deadZone = 0.025f;

    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    private bool isDisabled = false; 

    SpawnBall spawnBall;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPressed && GetValue() + pressThreshold >= 0.75f)
            Depressed();
        if (isPressed && GetValue() - pressThreshold <= 0f)
            Released();


    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPosition, transform.localPosition / joint.linearLimit.limit);

        if (Mathf.Abs(value) < 0)
            value = 0;

        return Mathf.Clamp(value, - 1f, 1f);
    }


    private void Depressed() 
    {
       
        isPressed = true;
        onButtonDown.Invoke();
        Debug.Log("Button is Pressed");
        Instantiate(ball, spawnPoint);    

    }

    private void Released()
    {
        isPressed = false;
        onButtonUp.Invoke();
        Debug.Log("Button is Released");
    }

}
