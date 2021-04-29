using UnityEngine;

using NullReferenceException = System.NullReferenceException;


namespace BreadAndButter
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance
        {
            get
            {
                //the internal instance isnt set, so attemot to find it from the scene
                if(instance == null)
                {
                    instance = FindObjectOfType<T>();

                    //no instance was found so throw a NullReferencexception detailing what singleton caused the error
                    if(instance == null)
                    {
                        throw new NullReferenceException(string.Format("No object of type: {0} was found.", typeof(T).Name));
                    }
                }

                return instance;
            }
        }

        private static T instance = null;

        /// <summary>
        /// Has the Singleton been generated?
        /// </summary>
        /// <returns></returns>
        public static bool IsSingletonValid() => instance != null;


        /// <summary>
        /// Find the instance within the scene
        /// </summary>
        /// <returns></returns>
        protected T CreateInstance() => Instance;

        public static void FlagAsPersistant() => DontDestroyOnLoad(Instance.gameObject);
    }
}
