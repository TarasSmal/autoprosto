using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace EasyMachanics
{
	public class ImageHelper 
	{
		/// <summary>
		/// Зберігає зображення у вказаним шляхом
		/// </summary>
		/// <param name="Image">файл зображення</param>
		/// <param name="ServerPath">шлях збереження</param>
		/// <param name="Replace">true, якщо хочем замінити файл(defaul false)</param>
		/// <returns></returns>
		public static string Save(HttpPostedFileBase Image, string ServerPath, bool Replace = false)
		{
			//переконвертовуємо файл в зображення
			var img = new WebImage(Image.InputStream);

			var filename = Path.GetFileName(Image.FileName);

				//якщо така фотка існує, треба додати до початку назви якусь цифру
				if (Replace && System.IO.File.Exists(Path.Combine(ServerPath, filename)))
				{
					Random RAND = new Random();
					filename = RAND.Next(0, 999999999) + filename;
				}

			var path = Path.Combine(ServerPath, filename);

			//зберігаємо зображення
			img.Save(path);
			return filename;
		}

        public static string SaveVideo(HttpPostedFileBase Image, string ServerPath, bool Replace = false)
        {
            //переконвертовуємо файл в зображення
            //var img = new WebImage(Image.InputStream);

            var filename = Path.GetFileName(Image.FileName);

            //якщо така фотка існує, треба додати до початку назви якусь цифру
            if (Replace && System.IO.File.Exists(Path.Combine(ServerPath, filename)))
            {
                Random RAND = new Random();
                filename = RAND.Next(0, 999999999) + filename;
            }

            var path = Path.Combine(ServerPath, filename);

            //зберігаємо зображення
            Image.SaveAs(path);
            return filename;
        }
    }
}