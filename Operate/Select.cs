using System;
using System.Collections.Generic;
using System.Text;

namespace ndb4vs.Operate
{
    class Select : Locator
    {
        private List<object> resultList = new List<object>(); //查询结果


        public object Do(Dictionary<string, object> ndb, string path)
        {

            Locate(ndb, path, false);

            return resultList;
        }

        protected override void DoAction(object item)
        {

            if (item != null)
            {
                resultList.Add(item);
            }
        }
    }
}
