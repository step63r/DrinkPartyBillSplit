using PCLStorage;
using System.Threading;
using System.Threading.Tasks;

namespace DrinkPartyBillSplit.Common
{
    /// <summary>
    /// PCL操作系クラス
    /// </summary>
    public static class PCLManager
    {
        /// <summary>
        /// 排他制御のためのセマフォオブジェクト
        /// </summary>
        static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// オブジェクトをPCLストレージのXMLファイルに保存する（非同期）
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="obj">オブジェクト</param>
        /// <param name="subFolderName">サブフォルダ名</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static async Task SaveXmlAsync<T>(T obj, string subFolderName, string fileName)
        {
            // ロックを取得
            await _semaphore.WaitAsync();

            try
            {
                // ユーザーデータ保存フォルダ
                var localFolder = FileSystem.Current.LocalStorage;

                // サブフォルダを作成または取得
                var subFolder = await localFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.OpenIfExists);

                // ファイルを作成または取得
                var file = await subFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                // テキストをファイルに書き込む
                await XmlConverter.SerialzeAsync(obj, file.Path);
            }
            finally
            {
                // ロックを解放
                _semaphore.Release();
            }
        }

        /// <summary>
        /// XMLファイルをPCLストレージから読み込む（非同期）
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="subFolderName">サブフォルダ名</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static async Task<T> LoadXmlAsync<T>(string subFolderName, string fileName)
        {
            // ロックを取得
            await _semaphore.WaitAsync();

            try
            {
                // ユーザーデータ保存フォルダ
                var localFolder = FileSystem.Current.LocalStorage;

                // サブフォルダを作成または取得
                var subFolder = await localFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.OpenIfExists);

                // ファイルを取得
                var file = await subFolder.GetFileAsync(fileName);

                // ファイルからオブジェクトを取得
                return await XmlConverter.DeserializeAsync<T>(file.Path);
            }
            finally
            {
                // ロックを解放
                _semaphore.Release();
            }
        }
    }
}
