using System;
using System.Collections.Generic;
using System.Text;


namespace ndb4vs
{
    public class Statement
    {
        public Dictionary<string, object> Read(string filename)
        {
            return new Common.NodeReader().Read(filename);
        }

        public void Write(string filename, string rootNode, Dictionary<string, object> ndb)
        {
            new Common.NodeWriter().Write(filename, rootNode, ndb);
        }

        public string Print(string rootNode, Dictionary<string, object> ndb)
        {
            return new Common.NodeWriter().Print(rootNode, ndb);
        }

        public object Execute(object ndb, string query)
        {
            object result = ndb;

            string command = query;
            if (query.IndexOf(":") > -1)
            {
                int splitSym = query.IndexOf(":");
                command = query.Substring(0, splitSym).Trim();
                query = query.Substring(splitSym + 1, query.Length - splitSym - 1).Trim();
            }

            query = query.Replace("!!", "!");
            string[] queryItems = query.Split('!');

            if (queryItems != null)
            {
                string path = null, value = null;

                if (queryItems.Length > 0)
                {
                    path = queryItems[0].Trim();
                }
                if (queryItems.Length > 1)
                {
                    value = queryItems[1].Trim();
                }

                List<object> resultList = new List<object>();

                if (ndb is List<object>)
                {
                    List<object> ndbList = (List<object>)ndb;
                    foreach (object ndbItem in ndbList)
                    {
                        if (ndbItem is Dictionary<string, object>)
                        {
                            resultList.Add(Execute((Dictionary<string, object>)ndbItem, command, path, value));
                        }
                    }
                }
                else if (ndb is Dictionary<string, object>)
                {
                    return Execute((Dictionary<string, object>)ndb, command, path, value);
                }

                if (resultList.Count > 0)
                {
                    return resultList;
                }
            }

            return result;
        }

        private object Execute(Dictionary<string, object> ndb, string command, string path, string value)
        {
            object result = ndb;

            if (command != null)
            {

                if (command.Equals("select", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Select().Do(ndb, path);
                }
                else if (command.Equals("one", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Select().Do(ndb, path);

                    if (result is List<object> && ((List<object>)result).Count > 0)
                    {
                        result = ((List<object>)result)[0];
                    }
                }
                else if (command.Equals("update", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Update().Do(ndb, path, value);
                }
                else if (command.Equals("delete", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Delete().Do(ndb, path, value);
                }
                else if (command.Equals("insert", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Insert().Do(ndb, path, value);
                }
                else if (command.Equals("clean", StringComparison.OrdinalIgnoreCase))
                {
                    result = new Operate.Cleaner().clean(ndb);
                }
            }
            return result;
        }

    }
}
