using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Cleaner
    {
        public Dictionary<string, object> clean(Dictionary<string, object> ndb)
        {
            Dictionary<string, object> ndbResult = new Dictionary<string, object>();

            foreach (string key in ndb.Keys)
            {
                object value = ndb[key];

                if (value is string)
                {
                    ndbResult.Add(key, value);
                }
                else if (value is List<object>)
                {
                    List<object> list = (List<object>)value;

                    List<object> _list = new List<object>();

                    foreach (object item in list)
                    {
                        if (item is string)
                        {
                            if (item != null && !((string)item).Trim().Equals(""))
                            {
                                _list.Add(item);
                            }
                        }
                        else if (item is Dictionary<string, object>)
                        {
                            Dictionary<string, object> map = (Dictionary<string, object>)item;
                            if (map.Count > 0)
                            {
                                _list.Add(clean((Dictionary<string, object>)item));
                            }
                        }
                    }
                    if (_list.Count > 0)
                    {
                        ndbResult.Add(key, _list);
                    }
                }
                else if (value is Dictionary<string, object>)
                {
                    Dictionary<string, object> map = (Dictionary<string, object>)value;
                    if (map.Count == 0)
                    {
                        ndbResult.Remove(key);
                    }
                    else
                    {
                        ndbResult.Add(key, clean((Dictionary<string, object>)value));
                    }

                }
            }
            return ndbResult;
        }
    }
}
