using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UsersPool
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        private static readonly object _locker = new object();
        private static readonly string path = "pool.xml";


        /// <summary>
        /// Фамилия
        /// </summary>
        public string Fam { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Im { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Om { get; set; }

        /// <summary> 
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// сохраняет текущего пользователя в файл по умолчанию
        /// </summary>
        public void SaveInXML()
        {
            lock (_locker)
            {
                //открываем или создаем, если нет такого файла
                XDocument doc;
                try
                {
                    doc = XDocument.Load(path);
                }
                catch (FileNotFoundException )
                {
                    Logger.WriteInEventLog("Файл отсутствует. Создан новый");
                    doc = new XDocument(new XElement("Root"));
                }

                //создаем элемент с атрибутами
                XElement el = new XElement("User");
                el.Add(
                    new XAttribute("Fam", this.Fam),
                    new XAttribute("Im", this.Im),
                    new XAttribute("Ot", this.Om),
                    new XAttribute("Login", this.Login),
                    new XAttribute("Pass", this.Pass) //так с паролями нельзя, но ведь это тестовое задание =)
                    );


                doc.Root.Add(el);
                //сохраняем
                doc.Save(path);
            }
        }


        /// <summary>
        /// Выгружает всех пользователей из файла по умолчанию
        /// </summary>
        public static List<User> GetAll()
        {
            var list = new List<User>();
            XDocument doc;
            try
            {
                lock (_locker)
                {
                    doc = XDocument.Load(path);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            if (doc.Root == null)
            {
                return null;
            }

            foreach (var el in doc.Root.Elements())
            {
                var user = new User
                {
                    Fam = el.Attribute("Fam")?.Value,
                    Im = el.Attribute("Im")?.Value,
                    Om = el.Attribute("Ot")?.Value,
                    Login = el.Attribute("Login")?.Value
                };
                list.Add(user);
            }
            return list;
            
        }
    }
}
