using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Delete : Locator
    {
        private bool clear = false; //是否全部清除
        private string[] columns = null; //需要清除的字段名称

        /**
         * 删除数据
         * 
         * @param path 需要删除的路径
         * @param ndb 需要处理的ndb数据
         * @param column 需要删除的列，如果忽略列则删除整个节点
         * 
         * @return 处理后的ndb数据
         */
        public Object Do(Dictionary<string, object> ndb, String path, String column)
        {
            if (column != null)
            {
                if (column.StartsWith("[") && column.EndsWith("]"))
                {
                    column = column.Trim().Substring(1, column.Length - 1);
                    this.columns = column.Split(',');
                }
                else if (column.Equals("block", StringComparison.OrdinalIgnoreCase))
                {
                    clear = true;
                }
            }

            Locate(ndb, path, false);

            return ndb;
        }

        protected override void DoAction(object item)
        {

            if (item != null && item is Dictionary<string, object>)
            {
                Dictionary<string, object> map = (Dictionary<string, object>)item;
                if (clear)
                {
                    map.Clear();
                }
                else
                {
                    if (columns != null && columns.Length > 0)
                    {
                        foreach (String column in columns)
                        {
                            map.Remove(column.Trim());
                        }
                    }
                }
            }
        }
    }
}
