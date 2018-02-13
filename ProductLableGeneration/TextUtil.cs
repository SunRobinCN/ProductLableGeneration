using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;

namespace ProductLableGeneration
{
    public class TextUtil
    {
        public void ArchiveProducts(string path, List<Product> list)
        {
            var json = JsonConvert.SerializeObject(list);
            WriteToFile(path, json);
        }

        public void WriteToFile(string path, string message)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, false))
            {
                writer.Write(message);
            }
        }

        public List<Product> GetProducts(string path)
        {
            List<Product> list;
            if (!File.Exists(path))
            {
                Stream fileStream = null;
                try
                {
                    fileStream = File.Create(path);
                }
                catch (Exception)
                {
                    if (fileStream != null) fileStream.Close();
                    throw;
                }
                finally
                {
                    if (fileStream != null) fileStream.Close();
                }
            }
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string content = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return list ?? new List<Product>();
        }
    }
}
