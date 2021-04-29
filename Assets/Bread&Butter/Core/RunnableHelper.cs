using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreadAndButter
{
    public class RunnableHelper
    {
        /// <summary>
        /// Attemps to retrieve the runnable behaviour from the passed gameObject or its children
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_runnable"></param>
        /// <param name="_from"></param>
        /// <returns></returns>
        public static bool Validate<T>(ref T _runnable, GameObject _from) where T : IRunnable
        {
            // if the passed runnable is already true return true
            if(_runnable != null)
            {
                return true;
            }

            if(_runnable == null)
            {
                _runnable = _from.GetComponent<T>();

                if(_runnable != null)
                {
                    return true;
                }
            }

            //if the runnable is still not set attempt to get it from the gaeobjects children
            if (_runnable == null)
            {
                _runnable = _from.GetComponent<T>();

                if(_runnable != null)
                {
                    return true;
                }
            }

            // we failed to get any instance of the runnable, so return false
            return false;
        }

        /// <summary>
        /// attempts to validate then setup the IRunnable, return weather or not it succedded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_runnable"></param>
        /// <param name="_from"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        public static bool Setup<T>(ref T _runnable, GameObject _from, params object[] _params) where T : IRunnable
        {
            // Validate the component, if we can, set it up and return true
            if(Validate(ref _runnable, _from))
            {
                _runnable.Setup(_params);
                return true;
            }
            //we failed to validate the component, so return false
            return false;
        }

        /// <summary>
        /// attemps to validate the runnable and if successful, run it using the information provided
        /// </summary>
        /// <param name="_runnable">the runnable being run</param> 
        /// <param name="_from">the gameobject is attached to</param>
        /// <param name="_params">any aditional information the runnable run function may need</param>
        public static void Run<T>(ref T _runnable, GameObject _from, params object[] _params) where T : IRunnable
        {
            if(Validate(ref _runnable, _from))
            {
                _runnable.Run(_params);
            }
        }
    }
}
