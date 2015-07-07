using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Cleaner
    {
        public Dictionary<string, object> clean(Dictionary<string, object> ndb)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (string key in ndb.Keys)
            {
                object value = ndb[key];

                if (value is string)
                {
                    result.Add(key, value);
                }
                else if (value is List<object>)
                {
                    List<object> list = (List<object>)value;

                    List<object> tmpList = new List<object>();

                    foreach (object item in list)
                    {
                        if (item is string)
                        {
                            if (item != null && !((string)item).Trim().Equals(""))
                            {
                                tmpList.Add(item);
                            }
                        }
                        else if (item is Dictionary<string, object>)
                        {
                            Dictionary<string, object> map = (Dictionary<string, object>)item;
                            if (map.Count > 0)
                            {
                                tmpList.Add(clean((Dictionary<string, object>)item));
                            }
                        }
                    }
                    if (tmpList.Count > 0)
                    {
                        result.Add(key, tmpList);
                    }
                }
                else if (value is Dictionary<string, object>)
                {
                    Dictionary<string, object> map = (Dictionary<string, object>)value;
                    if (map.Count == 0)
                    {
                        result.Remove(key);
                    }
                    else
                    {
                        result.Add(key, clean((Dictionary<string, object>)value));
                    }

                }
            }
            return result;
        }
    }
}
