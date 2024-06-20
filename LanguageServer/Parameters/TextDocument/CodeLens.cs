namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// 代码镜头表示应该与源文本一起显示的命令，如引用的数量、运行测试的方式等。
    /// 
    /// 当没有命令与代码透镜关联时，代码透镜是_unresolved_。
    /// 出于性能原因，代码镜头的创建和解析应该分两个阶段完成。
    /// </summary>
    /// <param name="range"></param>
    public class CodeLens(Range range)
    {
        /// <summary>
        /// 此代码镜头有效的范围。应该只跨一行。
        /// </summary>
        public Range range = range;

        /// <summary>
        /// 这个代码镜头所代表的命令。
        /// </summary>
        public Command? command;

        /// <summary>
        /// 在代码透镜和代码透镜解析请求之间的代码透镜项上保留的数据输入字段。
        /// </summary>
        public dynamic? any;
    }
}
