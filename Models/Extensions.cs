using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pluritechDemo.Models
{
	public static class Extensions
	{
		public static string GetFileSize( this System.IO.FileInfo file)
		{
			try
			{
				double sizeinbytes = file.Length;
				double sizeinkbytes = Math.Round((sizeinbytes / 1024));
				double sizeinmbytes = Math.Round((sizeinkbytes / 1024));
				double sizeingbytes = Math.Round((sizeinmbytes / 1024));
				if (sizeingbytes > 1)
					return string.Format("{0} GB", sizeingbytes); //размер в гигабайтах
				else if (sizeinmbytes > 1)
					return string.Format("{0} MB", sizeinmbytes); //возвращает размер в мегабайтах, если размер файла менее одного гигабайта
				else if (sizeinkbytes > 1)
					return string.Format("{0} KB", sizeinkbytes); //возвращает размер в килобайтах, если размер файла менее одного мегабайта
				else
					return string.Format("{0} B", sizeinbytes); //возвращает размер в байтах, если размер файла менее одного килобайта
			}
			catch { return "Ошибка получения размера файла"; } //перехват ошибок и возврат сообщения об ошибке
		}
	}
}
