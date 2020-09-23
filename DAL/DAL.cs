using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BE;

namespace DAL
{
    public class DAL : IDAL
    {
        static Work work = new Work();
        string path = "WorkXML.xml";
        public DAL()
        {
            work = loadDataFromXML(path);
        }
        ~DAL()
        {
            saveDataToXML(work, path);
        }
        public Work getWork()
        {
            return work;
        }
        public void setWork(Work _work)
        {
            work = _work;
        }
        
        //XML
        public static void saveDataToXML(Work work, string path)
        {
            XmlSerializer x = new XmlSerializer(work.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, work);
        }

        public static Work loadDataFromXML(string path)
        {
            Work work;
            XmlSerializer x = new XmlSerializer(typeof(Work));
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            work = (Work)x.Deserialize(fs);
            return work;

        }


    }
}
