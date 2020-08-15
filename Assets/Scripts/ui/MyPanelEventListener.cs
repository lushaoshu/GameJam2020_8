using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine.UI
{
    public class MyPanelEventListener
    {
        PanelBase _event;
        IUIEvent _eventBase;
        public void OnInit(PanelBase panel, IUIEvent eventBase)
        {
            _event = panel;
            _eventBase = eventBase;

            _eventBase.EventOnClick += OnClickEvent;
            _eventBase.EventOnPointerExit += OnPointerExit;
            _eventBase.EventOnPointerEnter += OnPointerEnter;
            _eventBase.EventOnDrag += OnDragEvent;
            _eventBase.EventOnDragStart += OnDragStartEvent;
            _eventBase.EventOnDragEnd += OnDragEndEvent;
        }

        void OnClickEvent(MonoBehaviour behaviour)
        {
            //播放fmod
            var btn = behaviour as MyButton;
            if(!string.IsNullOrEmpty(btn.sound_click_event))
                SoundManager.Play2DSound(btn.sound_click_event);

            _event.OnClick(behaviour);
        }

        void OnPointerExit(MonoBehaviour behaviour)
        {
            //播放fmod
            var btn = behaviour as MyButton;
            if (!string.IsNullOrEmpty(btn.sound_exit_event))
                SoundManager.Play2DSound(btn.sound_exit_event);

            _event.OnPointerExit(behaviour);
        }

        void OnPointerEnter(MonoBehaviour behaviour)
        {
            //播放fmod
            var btn = behaviour as MyButton;
            if (!string.IsNullOrEmpty(btn.sound_enter_event))
                SoundManager.Play2DSound(btn.sound_enter_event);

            _event.OnPointerEnter(behaviour);
        }

        void OnDragEvent(MyDragData myDragData)
        {
            _event.OnDrag(myDragData);
        }
        void OnDragStartEvent(MyDragData myDragData)
        {
            _event.OnDragStart(myDragData);
        }
        void OnDragEndEvent(MyDragData myDragData)
        {
            _event.OnDragEnd(myDragData);
        }

    }




}
