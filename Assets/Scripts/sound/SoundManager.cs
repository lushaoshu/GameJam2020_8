using FMODUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// Fmod音效管理器
/// </summary>
public static class SoundManager
{
    //音效大小
    public static float Volume_Sound
    {
        get {
            return 1;
        }
    }
    //音乐大小
    public static float Volume_Music
    {
        get
        {
            return 1;
        }
    }

    static GameObject _root;
    static Transform _target;

    public static bool InitOK
    {
        get {
            return _root && _baseBankLoadOk;
        }
    }
    private static bool _baseBankLoadOk =false;
    static List<StudioEventEmitter> _3dstudioEventList = new List<StudioEventEmitter>();
    //初始化
    public static void Init()
    {
        _root = new GameObject("SoundManager");
        _root.AddComponent<RuntimeManager>();

        //加载Bank
        //RuntimeManager.LoadBank("BankA");
        //RuntimeManager.LoadBank("Master");
        //RuntimeManager.LoadBank("Master.strings");
        _baseBankLoadOk = true;
    }

    public static void LateUpdate()
    {
        if (_target)
        {
            _root.transform.position = _target.transform.position + new Vector3(0,0,0);
            _root.transform.rotation = _target.transform.rotation;
            RuntimeManager.SetListenerLocation(_root.transform);//每帧设置收听者的位置
        }
    }
    //所有音乐暂停和恢复(安卓)
    public static void OnAppPause(bool pause)
    {
        RuntimeManager.PauseAllEvents(pause);
        if (pause)
        {//暂停
            RuntimeManager.CoreSystem.mixerSuspend();
        }
        else
        {//恢复
            RuntimeManager.CoreSystem.mixerResume();
        }
    }

    //所有音乐暂停和恢复(苹果)
    public static void OnAppFocus(bool pause)
    {
        RuntimeManager.PauseAllEvents(!pause);
        if (!pause)
        {//暂停
            RuntimeManager.CoreSystem.mixerSuspend();
        }
        else
        {//恢复
            RuntimeManager.CoreSystem.mixerResume();
        }
    }

    //停止所有音乐
    public static void StopAllSound()
    {
        var fmodList = _root.GetComponentsInChildren<StudioEventEmitter>();
        for (int i = 0; i < fmodList.Length; i++)
        {
            fmodList[i].Stop();
            GameObject.Destroy(fmodList[i].gameObject);
        }
    }
    //停止指定的音乐
    public static void StopMusic(string eventName)
    {
        var eventNameGo = eventName.Replace('/', '_');
        var studioEvent = _root.FindChild<StudioEventEmitter>(eventNameGo);
        if (studioEvent)
        {
            studioEvent.Stop();
            UnityEngine.Object.Destroy(studioEvent.gameObject);
        }
    }
    //停止当前音乐
    public static string StopCurrentMusic()
    {
        string currentMusic = _current_music;
        StopMusic(currentMusic);
        _current_music = "";
        return currentMusic;
    }

    private static string _current_music = "";
    //播放音乐
    public static void PlayMusic(string eventName)
    {
        if (!InitOK) return;
        if (!string.IsNullOrEmpty(_current_music))
                StopMusic(_current_music);
        _current_music = eventName;
        _playSoundDo(eventName);
    }



    public static void _playSoundDo(string eventName,GameObject voicer=null) {
        StudioEventEmitter studioEvent = null;
        if (!voicer)
        {
            var eventNameGo = eventName.Replace('/','_');
            studioEvent = _root.FindChild<StudioEventEmitter>(eventNameGo);
            if (!studioEvent)
            {
                var go = new GameObject(eventNameGo);
                go.name = eventNameGo;
                go.transform.SetParent(_root.transform);
                go.transform.localPosition = Vector3.zero;
                studioEvent = go.GetMissComponent<StudioEventEmitter>();
                studioEvent.OverrideAttenuation = true;
                studioEvent.OverrideMaxDistance = int.MaxValue;
                studioEvent.OverrideMinDistance = int.MaxValue;
                studioEvent.SetVolume(Volume_Music);
            }
        }
        else
        {
            studioEvent = voicer.GetMissComponent<StudioEventEmitter>();
            if (studioEvent.IsPlaying())
                studioEvent.Stop();
            studioEvent.OverrideAttenuation = true;
            studioEvent.OverrideMaxDistance = 20;
            studioEvent.OverrideMinDistance = 3;
            studioEvent.SetVolume(Volume_Music);
            if (!_3dstudioEventList.Contains(studioEvent))
                _3dstudioEventList.Add(studioEvent);
        }
        studioEvent.Event = eventName;
        studioEvent.Play();
    }

    //播放音效
    public static void Play2DSound(string eventName)
    {
        if (!InitOK) return;
        _PlaySound(eventName, null);
    }
    //播放音效
    public static void Play3DSound(string eventName, GameObject voicer)
    {
        if (!InitOK) return;
        _PlaySound(eventName, voicer);
    }

    private static void _PlaySound(string eventName,GameObject voicer)
    {
        if (string.IsNullOrEmpty(eventName))
            return;
        if (voicer)
        {
            RuntimeManager.PlayOneShotAttached(eventName,voicer, Volume_Sound);
        }
        else
        {
            RuntimeManager.PlayOneShot(eventName,default, Volume_Sound);
        }
    }

}