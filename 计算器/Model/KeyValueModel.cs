namespace 计算器.Model
{
    /// <summary>
    /// 运算服务和值的模型
    /// </summary>
    public class KeyValueModel
    {
        /// <summary>
        /// 字符存储
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 数值存储
        /// </summary>
        public long Value { get; set; }

        public new string ToString()
        {
            return this.Value.ToString() + this.Key;
        }
    }
}
