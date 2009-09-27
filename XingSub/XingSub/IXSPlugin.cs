namespace XingSub
{
    interface IXSPlugin
    {
        /// <summary>
        /// 获取插件类型
        /// </summary>
        /// <returns>0=导入;1=普通导出;2=特效导出</returns>
        int GetPluginType();

        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <returns>文件类型描述</returns>
        string GetFileType();

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <returns>文件扩展名(包含“.”)</returns>
        string GetFileExt();

        /// <summary>
        /// 把文本保存写入文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="text">文本内容</param>
        /// <returns>返回 0 表示成功</returns>
        int SaveFromText(string fileName, string text);

        /// <summary>
        /// 把字幕对象写入文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="subtitle">字幕对象</param>
        /// <returns>返回 0 表示成功</returns>
        int SaveFromSubtitle(string fileName, AdvancedSubStationAlpha subtitle);

        /// <summary>
        /// 读取文件为纯文本
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>纯文本格式的文件内容</returns>
        string ReadAsText(string fileName);

        /// <summary>
        /// 读取文件为字幕对象
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>字幕对象</returns>
        AdvancedSubStationAlpha ReadAsSubtitle(string fileName);
    }
}
