using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Update : Locator
    {
        private Dictionary<string, string> updateMap = new Dictionary<string, string>(); //需要更新的键值映射


        public object Do(Dictionary<string, object> ndb, string path, String updateValue)
        {
            updateMap = convertValueMap(updateValue);

            Locate(ndb, path, false);
            return ndb;
        }

        protected override void DoAction(object item)
        {
            if (item != null && item is Dictionary<string, object>){
				Dictionary<string, object> map = (Dictionary<string, object>)item;
				
				foreach (string key in updateMap.Keys){
                    if (map.ContainsKey(key))
                    {
                        map.Remove(key);
                    }
					map.Add(key, updateMap[key]);
				}
			}
        }
    }
}
