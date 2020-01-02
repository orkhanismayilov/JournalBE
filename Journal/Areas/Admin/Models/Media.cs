using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using SoundInTheory.DynamicImage;
using SoundInTheory.DynamicImage.Layers;
using SoundInTheory.DynamicImage.Filters;
using Journal.Models;

namespace Journal.Areas.Admin.Models
{
    public class Media
    {
        JournalEntities db = new JournalEntities();

        public HttpPostedFileBase file;
        public int width;
        public int height;
        public string savePath;

        public Image Add()
        {
            IDictionary<string, string> saveResult = SaveFile(file, savePath);
            Resize(saveResult);

            Image image = new Image
            {
                filename = saveResult["fileName"],
                date = DateTime.Now,
                width = width,
                height = height,
                file_dir = Globals.MediaUploadsPath + DateTime.Today.ToString("yyyy/MM/dd") + "/"
            };

            db.Images.Add(image);
            db.SaveChanges();

            return image;
        }

        public IDictionary<string, string> SaveFile(HttpPostedFileBase file, string savePath)
        {
            string fileName = file.FileName;
            string pathToCheck = savePath + fileName;
            string tempFileName = "";

            if (File.Exists(pathToCheck))
            {
                int counter = 2;
                while (File.Exists(pathToCheck))
                {
                    tempFileName = counter.ToString() + "_" + fileName;
                    pathToCheck = savePath + tempFileName;
                    counter++;
                }

                fileName = tempFileName;
            }


            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string pathToSave = savePath + fileName;
            file.SaveAs(pathToSave);

            IDictionary<string, string> result = new Dictionary<string, string>
            {
                { "savePath", pathToSave },
                { "fileName", fileName }
            };

            width = System.Drawing.Image.FromFile(pathToSave).Width;
            height = System.Drawing.Image.FromFile(pathToSave).Height;

            return result;
        }

        public void Resize(IDictionary<string, string> saveResult)
        {
            string folderName = "";

            foreach (KeyValuePair<string, int[]> sizes in Globals.MediaSizes)
            {
                Composition composition = new Composition();
                composition.Layers.Add(new ImageLayer
                {
                    SourceFileName = saveResult["savePath"],
                    Filters =
                    {
                        new ResizeFilter
                        {
                           Width = new Unit(sizes.Value[0]),
                           Height = new Unit(sizes.Value[1]),
                           Mode = ResizeMode.UniformFill
                        }
                    }
                });

                folderName = sizes.Key;

                SaveResized(composition, saveResult["fileName"], folderName);
            }
        }

        public void SaveResized(Composition composition, string fileName, string folderName)
        {
            GeneratedImage generatedImage = composition.GenerateImage();

            string finalPath = savePath + folderName + @"/";

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            generatedImage.Save(finalPath + fileName);
        }

        public string GetMediaPath()
        {
            return Globals.MediaUploadsPath + DateTime.Today.ToString("yyyy/MM/dd") + "/";
        }
    }
}