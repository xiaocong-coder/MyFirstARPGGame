using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public abstract class CustomSingleton<T> where T : new()
    {
        public static T Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    if (_singleton == null)
                    {
                        _singleton = new T();
                    }
                }

                return _singleton;
            }

            set { _singleton = value; }
        } 
        private static T _singleton;
    }

    public abstract class CustomSynchronousSingleton<T> where T : new()
    {
        private static T _singleton;
        private static object mutex = new object();

        public static T Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (mutex)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new T();
                        }
                    }
                }

                return _singleton;
            }
        } 
    }

    public class UnitySingleton<T> : MonoBehaviour where T : Component
    {
        private static T _singleton = null;

        public static T Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = FindObjectOfType(typeof(T)) as T;
                    if (_singleton == null)
                    {
                        GameObject obj = new GameObject();
                        _singleton = (T)obj.AddComponent(typeof(T));
                        obj.hideFlags = HideFlags.DontSave;
                        obj.name = typeof(T).Name;
                    }
                }

                return _singleton;
            }
        }

        public virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (_singleton == null)
            {
                _singleton = this as T;
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}