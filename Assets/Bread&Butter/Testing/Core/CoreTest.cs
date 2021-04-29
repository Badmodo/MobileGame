using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreadAndButter;

    public class CoreTest : MonoSingleton<CoreTest>
    {
        [SerializeField]
        private RunnableTest RunnableText;

    [SerializeField]
    private bool testEnabled = true;


        // Start is called before the first frame update
    void Start()
        {
            CreateInstance();
            FlagAsPersistant();

        RunnableHelper.Setup(ref RunnableText, gameObject, "Sally", new Vector3(1, 1, 1));
        }

        // Update is called once per frame
    void Update()
        {
            RunnableText.Enabled = testEnabled;
        RunnableHelper.Run(ref RunnableText, gameObject);
        }
    }
