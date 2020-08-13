using UnityEngine;
using UnityEditor;

public class ObjData 
{
    public int aoi_id;
    public string res_id;
    public virtual string AssetId {
        get {
            return res_id.ToString();
        }
        set {
            res_id = value;
        }
    }


}