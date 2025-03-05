using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class DataService<T>
    {
        private readonly string _filePath;
        public DataService(string fileName)
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }
        public void SaveData(List<T> data)
        {
            string json = JsonConvert.SerializeObject(data,Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
        public List<T> GetData()
        {
            if(!File.Exists(_filePath))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

    }
}
