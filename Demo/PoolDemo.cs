using UnityEngine;
using UnityEngine.UI;
using WB.Pool;

public class PoolDemo : MonoBehaviour
{
    [SerializeField,Header("プールのサイズ")] private int poolObjNumber = 5;
    [SerializeField,Header("プールに入れるオブジェクト")] private GameObject poolObjPrefab;
    [SerializeField,Header("リストのTransform")] private Transform layoutGroupTrn;
    
    //　PoolObjのインスタンスを入れるプール
    private Pool<PoolObj> pool;
    void Start()
    {
        //class PoolObj 用のプールを生成
        pool = WBPool.MakePool
            (
                //プールのサイズ
                poolObjNumber,
                
                //インスタンス化の方法を教える
                InstantiatePoolObj
            );
    }

    /// <summary>
    /// PoolObjのインスタンス化の方法
    /// </summary>
    /// <returns></returns>
    private PoolObj InstantiatePoolObj()
    {
        var poolObj = Instantiate(poolObjPrefab).GetComponent<PoolObj>();
        
        //ボタンがクリックされたとき、プールに返却するように設定
        poolObj.GetComponent<Button>().onClick.AddListener(() => pool.Return(poolObj));
        
        return poolObj;
    }
    
    /// <summary>
    /// リストに追加ボタンが押された際の挙動
    /// </summary>
    public void AddObjectButton()
    {
        //PoolObjのインスタンスを取得
        PoolObj gotPoolObj = pool.Rent();
        
        //オブジェクトをリストに追加
        gotPoolObj.transform.SetParent(layoutGroupTrn);
    }
}
