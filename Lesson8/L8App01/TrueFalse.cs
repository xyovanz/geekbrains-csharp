using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace L8App01
{
    public class TrueFalse
    {

        #region Private Fields

        private List<Question> list;
        private string fileName;

        #endregion

        #region Public Properties

        public string FileName
        {
            set { fileName = value; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }


        public int Count
        {
            get { return list.Count; }
        }

        #endregion

        #region Constructors

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Добавление нового вопроса в коллекцию
        /// </summary>
        /// <param name="text"></param>
        /// <param name="trueFalse"></param>
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question() { Text = text, TrueFalse = trueFalse });
        }

        /// <summary>
        /// Удаление вопроса из коллекции
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }


        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = (List<Question>)xmlSerializer.Deserialize(stream);
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
        }

        #endregion

    }
}
