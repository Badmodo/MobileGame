using UnityEngine;
using System.Collections.Generic;

using InvalidOperationException = System.InvalidOperationException;
using NullReferenceException = System.NullReferenceException;

namespace BreadAndButter.Mobile
{
    public class MobileInput : MonoBehaviour
    {
        //Has the mobile input system been initilized
        public static bool Initialised => instance != null;

        //Singleton reference instance
        private static MobileInput instance = null;

        /// <summary>
        /// if the system isnt already set up, this will instantiate the mobile input prefab and assign the static reference.
        /// </summary>
        public static void Initialise()
        {
            //if the mobile input is already initilised, throw an Exception to tell the user they done mucked up.
            if (Initialised)
            {
                throw new InvalidOperationException("Mobile Input already initilised");
            }

            // Load the Mobile Input Prefab and instantiate it in
            MobileInput prefabInstance = Resources.Load<MobileInput>("MobileInputPrefab");
            instance = Instantiate(prefabInstance);

            // Changed the instantiate objects name and mark it not to be destoryed
            instance.gameObject.name = "Mobile Input";
            DontDestroyOnLoad(instance.gameObject);
        }

        public static float GetJoystickAxis(JoystickAxis _axis)
        {
            if (!Initialised)
            {
                throw new InvalidOperationException("Mobile Input not initilised");
            }
            if (instance.joystickInput == null)
            {
                throw new NullReferenceException("Joystick Input reference not set");
            }

            //Switch on the passed axis and return the appropriate value

            switch (_axis)
            {
                case JoystickAxis.Horizontal: return instance.joystickInput.Axis.x;
                case JoystickAxis.Vertical: return instance.joystickInput.Axis.y;
                default: return 0;
            }
        }

        //used for swipe input
        public static SwipeInput.Swipe GetSwipe(int _index)
        {

            if (!Initialised)
            {
                throw new InvalidOperationException("Mobile Input not initilised");
            }
            if (instance.swipeInput == null)
            {
                throw new NullReferenceException("Swipe Input reference not set");
            }

            return instance.swipeInput.GetSwipe(_index);
        }

        //used for flick input
        public static void GetFlickData(out float _flickPower, out Vector2 _flickDirection)
        {
            if (!Initialised)
            {
                throw new InvalidOperationException("Mobile Input not initilised");
            }
            if (instance.swipeInput == null)
            {
                throw new NullReferenceException("Swipe Input reference not set");
            }

            _flickPower = instance.swipeInput.FlickPower;
            _flickDirection = instance.swipeInput.FlickDirection;
        }


        [SerializeField]
        private JoystickInput joystickInput;
        [SerializeField]
        private SwipeInput swipeInput;
    }
}
