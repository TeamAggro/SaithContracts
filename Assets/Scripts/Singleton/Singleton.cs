using UnityEngine;

namespace Aggro.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Properties and Variables

        private static bool _applicationIsQuitting;
        protected static bool applicationIsQuitting { get { return _applicationIsQuitting; } }

        private static object _lock = new object();
        protected static T _instance;

        public static T instance
        {
             get
            {
                if (applicationIsQuitting)
                {
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {

                        _instance = (T)FindObjectOfType(typeof(T));
                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {

                        }
                        if (_instance == null)
                        {
                            string singletonName = "(singleton) " + typeof(T).Name;
                            _instance = new GameObject(singletonName).AddComponent<T>();
                        }
                    }
                    return _instance;
                } 

            }
        }

        #endregion Properties and Variables

        #region MonoBehavior
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Debug.LogWarning("Destroying duplicate " + this.name);
                Destroy(gameObject);
            }
        }

       /// <summary>
       /// buggy ghost object will stay on editor, this stops it
       /// </summary.>


        protected virtual void OnApplicationQuit()
        {
            _applicationIsQuitting = true;
        }

        #endregion MonoBehavior

    }
}
