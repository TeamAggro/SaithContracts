using UnityEngine;

namespace Aggro.Singleton
{

    public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour 
    {
        protected override void Awake()
        {
            base.Awake();
            if (this != _instance) { return; }

            Object.DontDestroyOnLoad(this.gameObject);
        }

    }
}
