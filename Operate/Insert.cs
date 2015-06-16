using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Insert : Locator
    {
        private Dictionary<string, string> insertMap = new Dictionary<string, string>(); //需要新建的键值映射


        public object Do(Dictionary<string, object> ndb, string path, String updateValue)
        {
            insertMap = convertValueMap(updateValue);

            Locate(ndb, path, true);

            return ndb;
        }

        protected override void DoAction(object item)
        {
            if (item != null && item is Dictionary<string, object>){
				Dictionary<string, object> map = (Dictionary<string, object>)item;
				
				foreach (string key in insertMap.Keys){
                    if (map.ContainsKey(key))
                    {
                        map.Remove(key);
                    }
					map.Add(key, insertMap[key]);
				}
			}
        }
    }
}
