using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BreadAndButter;
using BreadAndButter.Mobile;

public class RunnableTest : RunnableBehaviour
    {
    [SerializeField]
    private TextMesh nameplate;
    [SerializeField, Tag]
    private string groundTag;
    [SerializeField, SceneFields]
    private string otherLevel;

        protected override void OnRun(params object[] _params)
        {
            transform.position += transform.forward * MobileInput.GetJoystickAxis(JoystickAxis.Vertical) * Time.deltaTime * 25;
            transform.position += transform.right * MobileInput.GetJoystickAxis(JoystickAxis.Horizontal) * Time.deltaTime * 25;
        }

        protected override void OnSetup(params object[] _params)
        {
            string username = (string)_params[0];
            Vector3 spawnPoint = (Vector3)_params[1];

            nameplate.text = username;
            transform.position = spawnPoint;

            MobileInput.Initialise();
        }
    }
