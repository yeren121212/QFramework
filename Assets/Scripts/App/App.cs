using UnityEngine;
using System;
using System.Collections;

// https://mp.weixin.qq.com/s?__biz=MzU3ODgxOTczNg==&mid=2247484055&idx=1&sn=66d26b5f7bcdecf6161bf0bc4c16a7fc&chksm=fd6ec160ca19487674c6a8f17aa8a7ccd19bbae485c3dad7b19bee8e888719670e53223f9e5c&cur_album_id=1507507258161758209&scene=189#rd
// 不懂,以后再看
namespace QFramework
{
    public class App : QMonoSingleton<App>
    {
        public AppMode mode = AppMode.Developing;
        private App() {}
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            // 进入欢迎界面
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            // CoroutineMgr.Instance().StartCoroutine(ApplicationDidFinishLaunching);
        }

        // 进入游戏
        IEnumerator ApplicationDidFinishLaunching()
        {
            // // 配置文件加载,类似PlayerPrefs
            // QSetting.Load();
            // // 日志输出
            // QLog.Instance();

            // yield return GameManager.Instance().Init();

            // // 进入测试逻辑
            // if(App.Instance().mode == AppMode.Developing){
            //     ResMgr.Instance().LoadRes("TestRes", delegate(string resName, Object resObject)
            //     {
            //         if(resObj != null){
            //             GameObject.Instantiate(resObject);
            //         }
            //         // 进入目标界面等
            //     });
            //     yield return null;
            // }else{
            //     yield return GameManager.Instance().Launch();
            // }

            yield return null;
        }
    }
}