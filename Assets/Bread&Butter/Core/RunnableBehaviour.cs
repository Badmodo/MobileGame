using UnityEngine;

using InvalidOperationException = System.InvalidOperationException;

namespace BreadAndButter
{
    public abstract class RunnableBehaviour : MonoBehaviour, IRunnable
    {
        public bool Enabled { get; set; }

        public bool isSetup = false;

        public void Run(params object[] _params)
        {
            //if the runnible is enabled, run its OnRun function with the passed values
            if(Enabled)
            {
                OnRun(_params);
            }
        }

        public void Setup(params object[] _params)
        {
            //If runnable is already set up, throw and exception
            if(isSetup)
            {
                throw new InvalidOperationException("Runnible already setup.");
            }

            OnSetup(_params);
            isSetup = true;
        }

        protected abstract void OnSetup(params object[] _params);
        protected abstract void OnRun(params object[] _params);
    }
}
