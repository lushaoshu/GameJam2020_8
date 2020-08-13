# 项目简介

## 项目框架

* 全局管理

  * LogicMM
  * 游戏入口:GameMng

* mvc

  * M和C都是单例模式，可以理解为静态

  * SmartControl

    * 写逻辑层

  * SmartModel

    * 写数据层

  * 可覆写的方法

    * ```c#
      public virtual void OnAppInit() { }//全局初始化
      public virtual void OnFrameUpdate() { }//每帧调用
      ```

  * 例子：

    * TalksControl

* 数据存储

  * ```c#
    public static class DB 
    ```

* 音效

  * ``` c#
    public static class SoundManager
    ```

  * 有注释，可以自己先试下，不懂了再来问我

* UI写法

  * 步骤

    * 继承MyPanel类

    * 创建构造函数，并赋值_panelResName为资源名

    * 覆写方法

      * ``` c#
        void OnInit();//第一次创建调用
        void OnShow();//显示时调用
        void OnDestroy();//销毁时调用
        void Display(bool b);//显示隐藏时调用
        bool IsVisible { get; }//是否显示
        public virtual void OnClick(MonoBehaviour behaviour)；//按钮按下时调用
        public void RunUITask(IEnumerator e);//调用协程
        ```

    * 获取并创建panel

      * ```c#
        var _task_panel = MyGUIManager.GetInstance().GetOrCreatePanel<MainTaskTipsPanel>();
        _task_panel.InitData(config, Vector2.zero);
        _task_panel.Display(true);
        ```

  * 例子:MainTaskTipsPanel

  * 最好是模仿写一下

* 插件

  * Dotween
    * 去官网学习API:
      * <http://dotween.demigiant.com/documentation.php>
  * Fmod
    * 去官网:
      * <https://www.fmod.com/resources/documentation-api?version=2.1&page=studio-api.html>