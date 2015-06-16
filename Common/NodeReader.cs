using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ndb4vs.Common
{
    class NodeReader
    {
        private long linenum = 0;

        public Dictionary<string, object> Read(string filename)
        {
            string[] content = File.ReadAllLines(filename);
            return Parse(content);
        }

        private Dictionary<string, object> Parse(string[] fileContent)
        {
            Dictionary<String, Object> ndb = new Dictionary<string, object>();

            while (linenum < fileContent.Length)
            {

                string line = fileContent[linenum].Trim();

                linenum++;

                if (line == null || line.Equals("") || line.StartsWith("#"))
                {
                    continue;
                }

                if (line.EndsWith("{"))
                {
                    string nodeName = line.Substring(0, line.IndexOf("{"));
                    Dictionary<String, Object> nodeValue = Parse(fileContent);

                    object node = null;
                    if (!ndb.ContainsKey(nodeName))
                    {
                        ndb.Add(nodeName, nodeValue);
                    }
                    else
                    {
                        node = ndb[nodeName];

                        List<object> nodeList = new List<object>();
                        if (node is List<object>)
                        {
                            nodeList = (List<object>)node;
                        }
                        else
                        {
                            nodeList.Add(node);
                        }
                        nodeList.Add(nodeValue);

                        if (ndb.ContainsKey(nodeName))
                        {
                            ndb.Remove(nodeName);
                        }
                        ndb.Add(nodeName, nodeList);
                    }


                }
                else if (line.EndsWith("}"))
                {
                    return ndb;
                }
                else
                {
                    string[] items = new string[2];
                    if (line.IndexOf(":") > 0)
                    {
                        int splitSym = line.IndexOf(":");
                        items[0] = line.Substring(0, splitSym).Trim();
                        items[1] = line.Substring(splitSym + 1, line.Length - splitSym - 1);
                    }

                    Object itemValue = null;
                    if (ndb.ContainsKey(items[0]))
                    {
                        itemValue = ndb[items[0]];

                        List<object> itemValueList = new List<object>();
                        if (itemValue is List<object>)
                        {
                            itemValueList = (List<object>)itemValue;
                        }
                        else
                        {
                            itemValueList.Add(itemValue);
                        }
                        itemValueList.Add(items[1]);

                        if (ndb.ContainsKey(items[0]))
                        {
                            ndb.Remove(items[0]);
                        }
                        ndb.Add(items[0], itemValueList);
                    }
                    else
                    {
                        ndb.Add(items[0], items[1]);
                    }
                }
            }

            return ndb;
        }
    }
}
