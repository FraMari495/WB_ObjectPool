

namespace WB.Pool
{
    /// <summary>
    /// オブジェクトプールを使用したいクラスは
    /// 必ずこのinterfaceを実装する
    /// </summary>
    public interface IPoolObject
    {
        /// <summary>
        /// オブジェクトがインスタンス化された際に1度だけ呼ばれるメソッド
        /// </summary>
        /// <param name="id">id(何番目に生成されたか)</param>
        void SetId(int id);
        
        /// <summary>
        /// プールに入った際(インスタンス化直後 & プールに返却された際)に呼ばれるメソッド
        /// </summary>
        void Initialize();
        
    }
}
