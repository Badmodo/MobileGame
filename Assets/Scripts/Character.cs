using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BreadAndButter.Mobile
{
    public class Character : MonoBehaviour
    {
        //player speed variable
        [SerializeField] private float speed = 5;
        //player private rb
        private Rigidbody rb;

        public bool canPlayerMove = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            // if the game is running on Android
            // Initialise the Joystick Mobile Input as the default player controller
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        if (!MobileInput.Initialised)
           MobileInput.Initialise();
#endif
        }

        private void FixedUpdate()
        {
            if (!canPlayerMove)
                return;

            // Switch between Mobile and PC input
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        // Mobile Inputs
        float moveHorizontal = MobileInput.GetJoystickAxis(JoystickAxis.Horizontal);
        float moveVertical = MobileInput.GetJoystickAxis(JoystickAxis.Vertical);
#else
            //keyboard inputs
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
#endif

            //movement for both inputs
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = (movement) * speed;
        }
    }
}