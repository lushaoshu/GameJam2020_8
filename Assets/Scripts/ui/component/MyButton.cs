using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
namespace UnityEngine.UI
{
    //如果按键没响应，看下是否有加EventSystem组件，
    //该组件身上包括EventSystem和Standalone Input Module
    //这三种都可以
    //public class MyButton:Button,IPointerDownHandler,IPointerUpHandler
    //public class MyButton:Button, IPointerClickHandler
    [Serializable]
    public class MyButton:Button, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField]
        public string sound_click_event = "";
        [SerializeField]
        public string sound_exit_event = "";
        [SerializeField]
        public string sound_enter_event = "";
        //public override void OnPointerDown(PointerEventData eventData)
        //{
        //    SendMessageUpwards("__OnPointerDown",this);
        //}
        //public override void OnPointerUp(PointerEventData eventData)
        //{
        //    SendMessageUpwards("__OnPointerUp", this);
        //}
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            SendMessageUpwards("OnClickEvent", this);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            SendMessageUpwards("OnPointerExit", this);
        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            SendMessageUpwards("OnPointerEnter", this);
        }
    }
}
