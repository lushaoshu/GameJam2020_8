using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 1.有字体自动打印功能
/// </summary>
namespace UnityEngine.UI {
  
    public class MyText : Text
    {
        private bool isAutoPoint=false;

        //bool isRuning;//是否正在打印
        //string scrouText;
        //char[] scrouTexts;
        public float waitTime=0.2f;
        public float waitAllTime=0;

        public bool IsAutoPoint { get => isAutoPoint;set { isAutoPoint = value; }}

 
        public string my_text
        {
            get
            {
                return base.text;
            }

            set
            {
                if (isAutoPoint)
                {
                    base.text = "";
                    //this.DOText(value, waitTime).SetLoops(-1);
                    //计算每个字所花的时间
                    if (!string.IsNullOrEmpty(value))
                    {
                        waitAllTime = JIexiChar(value).Length * waitTime;
                        this.DOText(value, waitAllTime);
                    }
                    
                }
                else
                    base.text = value;
            }
        }

      
        protected override void Start()
        {
            base.Start();

            //JIexiChar();
            //if (isAutoPoint)
            //    StarPoint();
        }

        protected override void OnDestroy()
        {
            StopAllCoroutines();
        }
        //解析
        char[] JIexiChar(string _text)
        {
            //将字体解析出来，去除<>
            string result = Regex.Replace(_text, @"<.*?>", "");
            result = Regex.Replace(result, @"\n", "");
            return result.ToCharArray();
        }

        //打印
        //public void StarPoint()
        //{
        //    //StartCoroutine(Point());
        //    this.DOText(text, 10f).SetLoops(-1);
        //}

        //IEnumerator Point()
        //{
        //    string text = "";
        //    for (int n = 0; n < scrouTexts.Length; n++)
        //    {
        //        text += scrouTexts[n];
        //        base.text = text;
        //        yield return new WaitForSeconds(waitTime);
        //    }
        //}
    }
}

