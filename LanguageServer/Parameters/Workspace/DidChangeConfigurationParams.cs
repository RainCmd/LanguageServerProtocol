﻿namespace LanguageServer.Parameters.Workspace
{
    public class DidChangeConfigurationParams(dynamic settings)
    {
        /// <summary>
        /// 实际更改的设置
        /// </summary>
        public dynamic settings = settings;
    }
}
