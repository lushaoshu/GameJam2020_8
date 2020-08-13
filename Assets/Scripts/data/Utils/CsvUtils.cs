using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using TinyJson;

public static class CsvUtils
{
    public static int TITLE_LINE_IDX = 1;
    public static int BREAK_COUNT_FOR_LINE = 200;

    public static async Task DeserializeAsync(List<List<string>> datas, string typename,Type csType,IList ret) {
        //解析整个文件
        List<List<string>> lint_list = datas;
       
        if (lint_list == null || lint_list.Count <= TITLE_LINE_IDX + 1) return;
        Type type = csType;
        //分析字段名
        List<string> title = lint_list[TITLE_LINE_IDX];//第一行标题
        List<MemberInfo> field_list = new List<MemberInfo>();
        ParseInfoList(type,title,ref field_list);

        //分析每行数据
        for (int i= TITLE_LINE_IDX+1;i< lint_list.Count;i++) {
            List<string> data = lint_list[i];

            var obj = ParseObj(field_list,title,data,type);
            if (obj != null)
                ret.Add(obj);

            if (i % BREAK_COUNT_FOR_LINE == 0) await Task.Delay(10);//每超过200条，则等待10毫秒
        }
    }

    public static IEnumerator _DeserializeAsync(List<List<string>> datas, string typename, Type csType, IList ret)
    {
        //解析整个文件
        List<List<string>> lint_list = datas;

        if (lint_list == null || lint_list.Count <= TITLE_LINE_IDX + 1) yield break;
        Type type = csType;
        //分析字段名
        List<string> title = lint_list[TITLE_LINE_IDX];//第一行标题
        List<MemberInfo> field_list = new List<MemberInfo>();
        ParseInfoList(type, title, ref field_list);

        //分析每行数据
        for (int i = TITLE_LINE_IDX + 1; i < lint_list.Count; i++)
        {
            List<string> data = lint_list[i];

            var obj = ParseObj(field_list, title, data, type);
            if (obj != null)
                ret.Add(obj);

            if (i % BREAK_COUNT_FOR_LINE == 0) yield return new WaitForSeconds(0.01f);//每超过200条，则等待10毫秒
        }
    }
    

    //解析字段名
    public static void ParseInfoList(Type type, List<string> line, ref List<MemberInfo> field_list) {

        foreach (string name in line) {
            string name2 = Regex.Replace(name,@"__\w+$","");
            MemberInfo info = type.GetField(name2);
            if (info == null)
            {
                info = type.GetProperty(name2);
                if (info == null)
                {
                    Console.WriteLine("Warning: type{0} lost field {1}",type.Name,name2);
                }
            }
            field_list.Add(info);
        }
    }
    //反射生成对象
    public static object ParseObj(List<MemberInfo> info_list,List<string> title,List<string> data,Type type) {
        //创建对象
        var obj = Activator.CreateInstance(type);
        var iTypeName = type.Name;
        //解析每个字段
        int cout = Math.Min(data.Count, title.Count);
        for (int i=0;i<cout;i++) {
            var info = info_list[i];
            if (info == null) continue;
            var value = data[i];

            try
            {
                //类型转换
                object value2;
                //转换
                if (info is FieldInfo)
                    value2 = ChangeType4Csv(value,(info as FieldInfo).FieldType);
                else
                    value2 = ChangeType4Csv(value, (info as PropertyInfo).PropertyType);


                if (info is FieldInfo) 
                    (info as FieldInfo).SetValue(obj,value2);
                else
                     (info as PropertyInfo).SetValue(obj, value2);

                }
            catch (Exception e)
            {
                //类型转换错误
                Debug.LogError($"{iTypeName}类型转换错误,{e.ToString()}");
            }
        }
        return obj;
    }
    
    /// <summary>
    /// 转换CSV类型
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static object ChangeType4Csv(string value,Type type) {
        if (value != null && value.GetType() == type) return value;
        if (value == "") value = null;

        if (type == typeof(string))
        {
            if (value == null) return "";
            return value;
        }
        if (type == typeof(Int32))
        {
            if (string.IsNullOrEmpty(value)) return 0;
            int ret = 0;
            if (value.Contains(".")) value = value.Substring(0,value.IndexOf('.'));
            if (int.TryParse(value, out ret))
                return ret;
            else
                return 0;
        }
        if (type == typeof(float))
        {
            if (string.IsNullOrEmpty(value)) return 0f;
            int ret = 0;
            if (int.TryParse(value, out ret))
                return ret;
            else
                return 0f;
        }
        if (type == typeof(uint))
        {
            uint ret = 0;
            if (string.IsNullOrEmpty(value)) return ret;

            if (value.Contains(".")) value = value.Substring(0, value.IndexOf('.'));
            if (uint.TryParse(value, out ret))
                return ret;
            else
                return 0;
        }
        if (type == typeof(long))
        {
            long ret = 0;
            if (string.IsNullOrEmpty(value)) return ret;

            if (value.Contains(".")) value = value.Substring(0, value.IndexOf('.'));
            if (long.TryParse(value, out ret))
                return ret;
            else
                return 0L;
        }
        if (type == typeof(ulong))
        {
            ulong ret = 0;
            if (string.IsNullOrEmpty(value)) return ret;

            if (value.Contains(".")) value = value.Substring(0, value.IndexOf('.'));
            if (ulong.TryParse(value, out ret))
                return ret;
            else
                return 0L;
        }
        if (type == typeof(byte))
        {
            byte ret = 0;
            if (string.IsNullOrEmpty(value)) return ret;

            byte.TryParse(value, out ret);
            return ret;

        }
        if (type == typeof(bool))
        {
            bool ret = false;
            if (string.IsNullOrEmpty(value)) return ret;

            bool.TryParse(value, out ret);
            return ret;

        }
        if (type == typeof(Vector3))
        {
            return null;
            //TODO
        }
        if (string.IsNullOrEmpty(value)) return null;
        return value.FromJson(type);
    }
}
