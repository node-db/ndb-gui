using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ndb4vs.Operate
{
    class Locator
    {
        /**
        * 定位对象
        * 
        * 查询语句表示方法为：A->B->C:Value
        * 如果首次开始，A为当前项，B->C:Value为子查询，如果当前项=子查询，则证明已经进入最后一个查询
        * 
        * @param ndb 需要查询的ndb对象
        * @param query 查询语句
        * @param isCreate 当查询项不存在时，是否进行创建
        * 
        */
        protected void Locate(object ndb, string query, bool isCreate)
        {

            if (query == null || query.Equals(""))
            {
                return;
            }

            string queryKey = query; //当前项
            string subQuery = query; //子查询

            if (ndb is List<object>)
            {
                List<object> ndbNodeList = (List<object>)ndb;

                foreach (object ndbItem in ndbNodeList)
                {
                    Locate(ndbItem, subQuery, isCreate);
                }

            }
            else if (ndb is Dictionary<string, object>)
            {

                if (query.IndexOf("->") > 0)
                {
                    int pathSymIndex = query.IndexOf("->");
                    queryKey = query.Substring(0, pathSymIndex).Trim();
                    subQuery = query.Substring(pathSymIndex + 2, query.Length - pathSymIndex - 2);
                }

                Dictionary<string, object> ndbMap = (Dictionary<string, object>)ndb;

                if (isCreate && !ndbMap.ContainsKey(queryKey))
                {
                    ndbMap.Add(queryKey, new Dictionary<string, object>());
                }
                if (!subQuery.Equals(queryKey) || queryKey.StartsWith(":"))
                {
                    if (queryKey.StartsWith(":"))
                    { //根据路径进行查询
                        string exp = queryKey.Substring(1);

                        foreach (string key in ndbMap.Keys)
                        {
                            if (CheckValue(key, exp))
                            {
                                if (subQuery.StartsWith(":"))
                                {
                                    Locate(ndbMap, key, isCreate);
                                }
                                else
                                {
                                    Locate(ndbMap[key], subQuery, isCreate);
                                }

                            }
                        }
                    }
                    else
                    {
                        Locate(ndbMap[queryKey], subQuery, isCreate);
                    }
                }
                else
                {
                    if (subQuery.IndexOf(":") > 0)
                    { //根据值进行查询
                        subQuery = subQuery.Replace("&&", "&");
                        string[] matchItems = subQuery.Split('&');

                        bool matchResult = true;
                        foreach (string matchItem in matchItems)
                        {
                            string[] items = matchItem.Trim().Split(':');
                            if (items.Length == 2)
                            {
                                string key = items[0];
                                string exp = items[1];

                                object value = ndbMap[key];

                                if (!CheckValue(value, exp))
                                {
                                    matchResult = false;
                                }
                            }
                        }

                        if (matchResult)
                        {
                            DoAction(ndbMap);
                        }
                    }
                    else
                    {
                        object result = ndbMap[queryKey];
                        //创建模式
                        if (isCreate)
                        {
                            if (result is List<object>)
                            {
                                List<object> list = (List<object>)result;

                                Dictionary<string, object> item = new Dictionary<string, object>();
                                DoAction(item);
                                list.Add(item);
                            }
                            else if (result is Dictionary<string, object>)
                            {
                                Dictionary<string, object> item = (Dictionary<string, object>)result;
                                if (item.Count == 0)
                                {
                                    DoAction(item);
                                }
                                else
                                {
                                    Dictionary<string, object> newItem = new Dictionary<string, object>();
                                    DoAction(newItem);

                                    List<object> list = new List<object>();
                                    list.Add(item);
                                    list.Add(newItem);

                                    ndbMap.Add(queryKey, list);
                                }

                            }
                        }
                        else
                        {
                            if (result is List<object>)
                            {
                                List<object> list = (List<object>)result;
                                foreach (object item in list)
                                {
                                    DoAction(item);
                                }
                            }
                            else
                            {
                                DoAction(result);
                            }
                        }
                    }
                }
            }

        }

        private bool CheckValue(object value, string exp)
        {
            if (exp.StartsWith("/") && exp.EndsWith("/"))
            { //正则表达式判断
                string regex = exp.Substring(1, exp.Length - 1);
                if (value != null && value is string)
                {
                    Match result = Regex.Match(value.ToString(), regex);
                    return true;
                }
            }
            else if (exp.StartsWith("[") && exp.EndsWith("]") && exp.IndexOf(",") > 0)
            { //值域判断
                string[] region = exp.Substring(1, exp.Length - 1).Split(',');
                if (value != null && value is string && region.Length == 2)
                {

                    int min = Convert.ToInt32(region[0].Trim()); //值域中最小值
                    int max = Convert.ToInt32(region[1].Trim()); //值域中最大值
                    int intValue = Convert.ToInt32(((string)value).Trim());
                    if (intValue >= min && intValue <= max)
                    { //值域匹配
                        return true;
                    }
                }
            }
            else if (exp.StartsWith("^"))
            {
                string StartsWith = exp.Substring(1);
                if (value != null && value.ToString().StartsWith(StartsWith))
                {
                    return true;
                }
            }
            else if (exp.EndsWith("$"))
            {
                string EndsWith = exp.Substring(0, exp.Length - 1);
                if (value != null && value.ToString().EndsWith(EndsWith))
                {
                    return true;
                }
            }
            else
            {
                if (value != null && value.Equals(exp))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void DoAction(object item)
        {
        }

        protected Dictionary<string, string> convertValueMap(string updateValue){
		    Dictionary<string, string> updateValueMap = new Dictionary<string, string>();

		    string[] values = updateValue.Split(',');
		    foreach (string value in values){
                string[] valuePair = value.Split('=');
			    if (valuePair.Length == 2){
				    updateValueMap.Add(valuePair[0].Trim(), valuePair[1].Trim());
			    }
		    }

		    return updateValueMap;
	    }
    }
}
