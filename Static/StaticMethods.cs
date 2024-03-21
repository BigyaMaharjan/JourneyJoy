using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JourneyJoy.Static
{
    public static class StaticMethods
    {
        public static T MapObject<T>(this object item)
        {
            T sr = default(T);
            if (item != null)
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                sr = JsonConvert.DeserializeObject<T>(obj);
            }
            return sr;
        }
        public static List<T> MapObjects<T>(this object item)
        {
            List<T> sr = default(List<T>);
            if (item != null)
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                sr = JsonConvert.DeserializeObject<List<T>>(obj);
            }
            return sr;
        }

        public static string Encryption(string plainText)
        {
            string key = "Z947421as8OslwoS788qqw";
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                aes.Mode = CipherMode.ECB;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array, 0, array.Length);
        }

        public static object CreateDropdownList(Dictionary<string, string> dbResponse)
        {
            var response = new Dictionary<string, string>();
            dbResponse.ForEach(item => { response.Add(item.Key, item.Value); });
            return response;
        }

        public static void ForEach<TObject>(this IEnumerable<TObject> collection, Action<TObject> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (collection == null)
            {
                return;
            }

            foreach (TObject item in collection)
            {
                item.IfNotNull(delegate (TObject i)
                {
                    action(i);
                });
            }
        }

        public static void ResizeImage(HttpPostedFileBase file, string toStream)//double scaleFactor,
        {
            if (file.ContentLength > 1 * 1024 * 1024)//1 MB
            {
                var image = Image.FromStream(file.InputStream);
                var newWidth = (int)(600);
                var newHeight = (int)(600);
                var thumbnailBitmap = new Bitmap(newWidth, newHeight);

                var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbnailGraph.DrawImage(image, imageRectangle);

                thumbnailBitmap.Save(toStream, image.RawFormat);//image.RawFormat

                thumbnailGraph.Dispose();
                thumbnailBitmap.Dispose();
                image.Dispose();
            }
            else
            {
                file.SaveAs(toStream);
            }
        }

    }
}