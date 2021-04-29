using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreadAndButter.Mobile;

public class MobileTest : MonoBehaviour
{

    [SerializeField]
    private bool TestJoystick = false;
    [SerializeField]
    private bool testSwipe = false;

    // Start is called before the first frame update
    void Start()
    {
        MobileInput.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestJoystick)
        {
            transform.position += transform.forward * MobileInput.GetJoystickAxis(JoystickAxis.Vertical) * Time.deltaTime;
            transform.position += transform.right * MobileInput.GetJoystickAxis(JoystickAxis.Horizontal) * Time.deltaTime;
        }

        if (testSwipe)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

#else

            if(Input.GetMouseButtonDown(0))
            {
                //get inputs from SwipeInput.script
            }

            if(Input.GetMouseButton(0))
            {

            }

            if(Input.GetMouseButtonUp(0))
            {

            }

            Vector2 touchPos = Input.mousePosition;

#endif
        }
    }
}
