using System.IO;

public class XMLHelper_pcq
{
    /// <summary>
    /// 将定义的类生成XML并保存到本地文件中
    /// </summary>
    /// <typeparam name="T">自定义类类型</typeparam>
    /// <param name="wi">自定义对象</param>
    /// <param name="path">文件保存路径</param>
    public static void Analysis<T>(T wi,string path)
    {
        StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8, 102400000);
        sw.Write(XMLAnalysis.SerializeXML(wi));
        sw.Dispose();
        //XMLAnalysis.SerializeXML(wi);
    }
    
   /// <summary>
   /// 本地读取XML对象
   /// </summary>
    /// <typeparam name="T">自定义类类型</typeparam>
    /// <param name="path">文件读取路径</param>
   /// <returns></returns>
    public static T ReadXML<T>(string path)
    {
        StreamReader sr = new StreamReader(path);
        string xml = sr.ReadToEnd();
        sr.Dispose();
        T LGdata = XMLAnalysis.DeserializeXML<T>(xml);
        return LGdata;
    }

    /// <summary>
    /// 读取XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="webXML"></param>
    /// <param name="path">文件读取的路径</param>
    /// <returns></returns>
    public static T SetScenceInfo<T>(string webXML,string path)
    {
        T wsi = ReadXML<T>(path);
        return wsi;
    }
}
