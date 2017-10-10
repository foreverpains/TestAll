using UnityEngine;
using System.Collections;

    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {

        static T _instance;

        /// <summary>
        /// 判断访问此单例类的实例时此实例是否之前就已在场景中实例化
        /// </summary>
        public static bool IsExistInstance
        {
            get { return _instance != null; }
        }

        /// <summary>
        /// 解决同步用
        /// </summary>
        private static object lockObject = new object();
        /// <summary>
        /// 访问此实例的唯一的属性
        /// </summary>
        public static T instance
        {
            get
            {
                if (applicationQuit)
                {
                    _instance = null;
                    Debug.LogError("The Application is quit ,but you already to access it!");
                    return null;
                }

                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType(typeof(T)) as T;

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] something went really wrong!" +
                                "-there should never be more than 1 singleton!" +
                                "Reopening the scene might fix it.");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(Singleton)" + typeof(T).ToString();
                            _instance.CreateNewInstanceSuccessful();
                            DontDestroyOnLoad(singleton);
                            // Debugger.Log("Create a new singleton that name is : " + singleton.name + ".");
                        }
                        else
                        {
                            // Debugger.Log("The singleton that name is : " + _instance.gameObject.name + ".");
                        }
                    }

                    return _instance;

                }
            }
        }

        /// <summary>
        /// 新实例创建成功（子类实现）
        /// </summary>
        public virtual void CreateNewInstanceSuccessful()
        {

        }


        void OnDestroy()
        {
            OnInstanceDestroy();

            _instance = null;
        }

        /// <summary>
        /// 销毁实例(子类实现)
        /// </summary>
        public virtual void OnInstanceDestroy()
        {

        }

        public virtual void Destroy()
        {
            Object.Destroy(this.gameObject);
        }

        public void DestroyImmediate()
        {
            Object.DestroyImmediate(this.gameObject);
        }

        private static bool applicationQuit = false;
        void OnApplicationQuit()
        {
            applicationQuit = true;
        }

    }