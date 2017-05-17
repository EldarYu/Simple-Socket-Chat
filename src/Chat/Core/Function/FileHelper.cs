using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core.Function
{
    /// <summary>
    /// 串行化与反串行化操作
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 串行化对象写入到文件中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Save<T>(List<T> list, string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, list);
                }
                return true;
            }
            catch (IOException e)
            {
                new Exceptions.IOException(e);
            }
            catch (Exception e)
            {
                new Exceptions.UnknowException(e);
            }
            return false;
        }

        /// <summary>
        /// 反串行化对象读取到程序中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<T> Load<T>(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<T> data = (List<T>)bf.Deserialize(stream);
                    return data;
                }
            }
            catch (IOException e)
            {
                new Exceptions.IOException(e);
            }
            catch (Exception e)
            {
                new Exceptions.UnknowException(e);
            }
            return null;
        }
    }
}
