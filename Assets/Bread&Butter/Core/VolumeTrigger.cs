using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BreadAndButter


{
    [RequireComponent(typeof(Rigidbody))]

    public class VolumeTrigger : Trigger
    {
        // Start is called before the first frame update
        void Start()
        {
            Collider collider = gameObject.GetComponent<Collider>();
            if (collider == null)
                collider = gameObject.AddComponent<BoxCollider>();

            collider.isTrigger = true;

            //prevents this rigidbody from moving at all using physics
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        private void OnTriggerEnter(Collider other) => Fire();


    }
}