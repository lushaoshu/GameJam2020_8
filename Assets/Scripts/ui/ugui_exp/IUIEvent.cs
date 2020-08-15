using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine.UI
{
    public class IUIEvent : MonoBehaviour
    {
        public Action<MonoBehaviour> EventOnClick;
        public Action<MonoBehaviour> EventOnPointerExit;
        public Action<MonoBehaviour> EventOnPointerEnter;
        public Action<MyDragData> EventOnDrag;
        public Action<MyDragData> EventOnDragStart;
        public Action<MyDragData> EventOnDragEnd;


        void OnClickEvent(MonoBehaviour behaviour) { EventOnClick?.Invoke(behaviour); }
        void OnPointerExit(MonoBehaviour behaviour) { EventOnPointerExit?.Invoke(behaviour); }
        void OnPointerEnter(MonoBehaviour behaviour) { EventOnPointerEnter?.Invoke(behaviour); }
        void OnDragEvent(MyDragData myDragData) { EventOnDrag?.Invoke(myDragData); }
        void OnDragStartEvent(MyDragData myDragData) { EventOnDragStart?.Invoke(myDragData); }
        void OnDragEndEvent(MyDragData myDragData) { EventOnDragEnd?.Invoke(myDragData); }

    }
}
