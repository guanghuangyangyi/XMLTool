//文件名称（File Name）                 XmlTool.cs
//作者(Author)                          yjq
//日期（Create Date）                   2017.5.1
//修改记录(Revision History)
//    R1:
//        修改作者:
//        修改日期:
//        修改原因:
//    R2:
//        修改作者:
//        修改日期:
//        修改原因:
//**************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Xml
{
    /// <summary>
    /// XML工具类
    /// </summary>
    public static class XmlTool
    {
        #region 获取XmlDocument对象
        /// <summary>
        /// 根据xml字符获取XmlDocument对象
        /// </summary>
        /// <param name="xmlContent">xml内容字符串</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument GetXmlDocumentByXmlContent(string xmlContent)
        {
            XmlDocument xDoc = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(xmlContent))
                {
                    xDoc = new XmlDocument();
                    xDoc.LoadXml(xmlContent);
                }
                else
                {
                    throw new Exception(string.Format("xml内容字符串{0}为空", xmlContent));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xDoc;
        }
        /// <summary>
        /// 根据xml文件的路径获取XmlDocument对象
        /// </summary>
        /// <param name="xmlFilePath">xml文件路径</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument GetXmlDocumentByFile(string xmlFilePath)
        {
            XmlDocument xDoc = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(xmlFilePath))
                {
                    if (File.Exists(xmlFilePath))
                    {
                        xDoc = new XmlDocument();
                        xDoc.LoadXml(xmlFilePath);
                    }
                    else
                    {
                        throw new Exception(string.Format("xml文件{0}不存在", xmlFilePath));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml文件路径{0}为空", xmlFilePath));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xDoc;
        }
        #endregion

        #region 取Xml节点
        /// <summary>
        /// 获取父节点下的所有子节点列表
        /// </summary>
        /// <param name="parentXmlNod">父节点</param>
        /// <returns></returns>
        public static XmlNodeList GetChildNodes(XmlNode parentXmlNode)
        {
            XmlNodeList xmlNodeList = null;
            try
            {
                if (parentXmlNode != null)
                {
                    xmlNodeList = parentXmlNode.ChildNodes;
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xmlNodeList;
        }

        /// <summary>
        /// 获取父节点下的第一个子节点
        /// </summary>
        /// <param name="parentXmlNode"></param>
        /// <returns></returns>
        public static XmlNode GetFirstChildNode(XmlNode parentXmlNode)
        {
            XmlNode xmlNode = null;
            try
            {
                if (parentXmlNode != null)
                {
                    XmlNodeList xmlNodeList = null;
                    xmlNodeList = parentXmlNode.ChildNodes;
                    if (xmlNodeList != null && xmlNodeList.Count > 0)
                    {
                        xmlNode = xmlNodeList[0];
                    }
                    else
                    {
                        throw new Exception(string.Format("xml父节点{0}不存在子节点", parentXmlNode));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xmlNode;
        }
        /// <summary>
        /// 获取父节点下指定节点名称的子节点列表
        /// </summary>
        /// <param name="parentXmlNode">父节点</param>
        /// <param name="childNodeName">子节点名称</param>
        /// <returns></returns>
        public static XmlNodeList GetChildNodesByName(XmlNode parentXmlNode, string childNodeName)
        {
            XmlNodeList xmlNodeList = null;
            try
            {
                if (parentXmlNode != null)
                {
                    if (string.IsNullOrWhiteSpace(childNodeName))
                    {
                        xmlNodeList = parentXmlNode.SelectNodes(string.Format(".//{0}", childNodeName)); ;
                    }
                    else
                    {
                        throw new Exception(string.Format("子节点{0}名称为空", childNodeName));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xmlNodeList;
        }

        /// <summary>
        /// 获取父节点下的第一个满足指定名称的子节点
        /// </summary>
        /// <param name="parentXmlNode">父节点</param>
        /// <param name="childNodeName">子节点名称</param>
        /// <returns></returns>
        public static XmlNode GetFirstChildNodeByName(XmlNode parentXmlNode, string childNodeName)
        {

            XmlNode xDoc = null;
            try
            {
                XmlNodeList childXmlNodes = GetChildNodes(parentXmlNode);

                if (parentXmlNode != null)
                {
                    if (!string.IsNullOrWhiteSpace(childNodeName))
                    {
                        xDoc = parentXmlNode.SelectSingleNode(string.Format(".//{0}", childNodeName));
                    }
                    else
                    {
                        throw new Exception(string.Format("子节点{0}名称为空", childNodeName));
                    }
                }
                else
                {
                    throw new Exception(string.Format("父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xDoc;
        }

        /// <summary>
        /// 获取父节点下满足xpathExpr表达式的XML子节点列表
        /// </summary>
        /// <param name="parentXmlNode">父节点</param>
        /// <param name="xPathExpr">表达式</param>
        /// <returns></returns>
        public static XmlNodeList GetChildNodesByXPathExpr(XmlNode parentXmlNode, string xPathExpr)
        {
            XmlNodeList xmlNodeList = null;
            try
            {
                if (parentXmlNode != null)
                {
                    if (string.IsNullOrWhiteSpace(xPathExpr))
                    {
                        xmlNodeList = parentXmlNode.SelectNodes(xPathExpr);
                        //parentXmlNode.SelectSingleNode(xPathExpr);
                    }
                    else
                    {
                        throw new Exception(string.Format("表达式{0}为空", xPathExpr));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xmlNodeList;
        }
        #endregion

        #region 读取节点属性
        /// <summary>
        /// 读取节点指定的属性名的属性值
        /// </summary>
        /// <param name="xmlNode">节点</param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        public static string ReadAttrValue(XmlNode xmlNode, string attrName)
        {
            string attrValue = null;
            try
            {
                if (xmlNode != null)
                {
                    if (string.IsNullOrWhiteSpace(attrName))
                    {
                        XmlElement xmlElement = xmlNode as XmlElement;
                        attrValue = xmlElement.GetAttribute(attrName);
                    }
                    else
                    {
                        throw new Exception(string.Format("属性名{0}为空", attrName));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml节点{0}为空", xmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return attrValue;
        }

        /// <summary>
        /// 读取父节点下的指定名称的子节点的指定属性
        /// </summary>
        /// <param name="parentXmlNode">父节点</param>
        /// <param name="childNodeName">子节点名称</param>
        /// <param name="attrName">属性名称</param>
        /// <returns></returns>
        public static string[] ReadAttrValues(XmlNode parentXmlNode, string childNodeName, string attrName)
        {
            string[] attrValues = null;
            try
            {
                if (parentXmlNode != null)
                {
                    if (string.IsNullOrWhiteSpace(childNodeName))
                    {
                        if (string.IsNullOrWhiteSpace(attrName))
                        {
                            string xpathExpr = string.Format("//{0}[{1}]", childNodeName, attrName);
                            XmlNodeList xmlNodes = GetChildNodesByXPathExpr(parentXmlNode, xpathExpr);
                            if (xmlNodes != null && xmlNodes.Count > 0)
                            {
                                int size = xmlNodes.Count;
                                attrValues = new string[size];
                                for (int i = 0; i < size; i++)
                                {
                                    attrValues[i] = ((XmlElement)xmlNodes[i]).GetAttribute(attrName);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("属性名{0}为空", attrName));
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("子节点名称{0}为空", childNodeName));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return attrValues;
        }
        #endregion

        #region 读取节点的文本内容
        /// <summary>
        /// 读取xml节点文本
        /// </summary>
        /// <param name="xmlNode">节点</param>
        /// <returns></returns>
        public static string ReadNodeText(XmlNode xmlNode)
        {
            string nodeText = null;
            try
            {
                if (xmlNode != null)
                {
                    nodeText = xmlNode.InnerText;
                }
                else
                {
                    throw new Exception(string.Format("xml节点{0}为空", xmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return nodeText;
        }

        /// <summary>
        /// 读取父节点下的所有子节点的文本数组
        /// </summary>
        /// <param name="parentXmlNode">父节点</param>
        /// <returns></returns>
        public static string[] ReadChindNodeTexts(XmlNode parentXmlNode)
        {
            string[] nodeTexts = null;
            try
            {
                if (parentXmlNode != null)
                {
                    XmlNodeList xmlNodes = GetChildNodes(parentXmlNode);
                    if (xmlNodes != null & xmlNodes.Count > 0)
                    {
                        int size = xmlNodes.Count;
                        for (int i = 0; i < size; i++)
                        {
                            nodeTexts[i] = xmlNodes[i].InnerText;
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return nodeTexts;
        }

        public static string[] ReadChindNodeTextsByName(XmlNode parentXmlNode, string childNodeName)
        {
            string[] nodeTexts = null;
            try
            {
                if (parentXmlNode != null)
                {
                    if (!string.IsNullOrWhiteSpace(childNodeName))
                    {
                        string xpathExpr = string.Format(".//{0}", childNodeName);
                        XmlNodeList xmlNodes = GetChildNodesByXPathExpr(parentXmlNode, xpathExpr);
                        if (xmlNodes != null & xmlNodes.Count > 0)
                        {
                            int size = xmlNodes.Count;
                            for (int i = 0; i < size; i++)
                            {
                                nodeTexts[i] = xmlNodes[i].InnerText;
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("xml父节点{0}不存在子节点", parentXmlNode));
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("子节点{0}名称为空", childNodeName));
                    }
                }
                else
                {
                    throw new Exception(string.Format("xml父节点{0}为空", parentXmlNode));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return nodeTexts;
        }
        #endregion

        #region 增加节点
        #endregion

        #region 增加节点属性
        #endregion

        #region 增加节点文本
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">序列化的对象</param>
        /// <returns></returns>
        public static string Serialize(Type type, object obj)
        {
            string xml = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(type);
                xs.Serialize(ms, obj);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                xml = sr.ReadToEnd();
                sr.Dispose();
                ms.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return xml;
        }
        #endregion

        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            object obj = null;
            try
            {
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    obj = xmldes.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return obj;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">xml流</param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream xml)
        {
            object obj = null;
            try
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                obj = xmldes.Deserialize(xml);
            }
            catch (Exception e)
            {
                throw e;
            }
            return obj;
        }
        #endregion
    }
}
