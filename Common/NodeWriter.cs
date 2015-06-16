using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ndb4vs.Common
{
    class NodeWriter
    {

        public void Write(string filename, string rootNode, Dictionary<string, object> ndb)
        {
            String content = Print(rootNode, ndb);
            if (content != null && content.Length > 0)
            {
                File.WriteAllText(filename, content);
            }
        }

        public string Print(string rootNode, Dictionary<string, object> ndb)
        {
            List<string> ndbInfo = new List<string>();

            ndbInfo.Add(rootNode + "{\n");

            foreach (string nodeKey in ndb.Keys)
            {
                object nodeValue = ndb[nodeKey];
                if (nodeValue is List<object>)
                {
                    List<object> list = (List<object>)nodeValue;
                    foreach (object item in list)
                    {
                        if (item is Dictionary<string, object>)
                        {
                            ndbInfo.Add(Print(nodeKey, (Dictionary<string, object>)item));
                        }
                        else
                        {
                            ndbInfo.Add(string.Format("{0}:{1}\n", nodeKey, item.ToString()));
                        }
                    }
                }
                else if (nodeValue is Dictionary<string, object>)
                {
                    ndbInfo.Add(Print(nodeKey, (Dictionary<string, object>)nodeValue));
                }
                else
                {
                    ndbInfo.Add(string.Format("{0}:{1}\n", nodeKey, nodeValue.ToString()));
                }
            }
            ndbInfo.Add("}\n");

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string line in ndbInfo)
            {
                stringBuilder.Append(line);
            }
            return stringBuilder.ToString();
        }
    }
}
