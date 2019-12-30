using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SoundInTheory.DynamicImage;
using SoundInTheory.DynamicImage.Layers;
using SoundInTheory.DynamicImage.Filters;

namespace Journal.Areas.Admin.Models
{
    public class Media
    {
        public HttpPostedFileBase file;
        public string savePath;

        public void Add(HttpPostedFileBase file)
        {
            Dictionary<string, string> saveResult = SaveFile(file, savePath);
            Resize(saveResult);
        }

        public Dictionary<string, string> SaveFile(HttpPostedFileBase file, string savePath)
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

            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "savePath", pathToSave },
                { "fileName", fileName }
            };

            return result;
        }

        public void Resize(Dictionary<string, string> saveResult)
        {
            Composition composition = new Composition();
            composition.Layers.Add(new ImageLayer
            {
                SourceFileName = saveResult["savePath"],
                Filters =
                    {
                        new ResizeFilter
                        {
                           Width = new Unit(1000),
                           Height = new Unit(1000),
                           Mode = ResizeMode.UniformFill
                        }
                    }
            });

            SaveResized(composition, saveResult["fileName"]);
        }

        public void SaveResized(Composition composition, string fileName)
        {
            GeneratedImage generatedImage = composition.GenerateImage();

            string thumbPath = savePath + @"thumbnails/";

            if (!Directory.Exists(thumbPath))
            {
                Directory.CreateDirectory(thumbPath);
            }

            generatedImage.Save(thumbPath + fileName);
        }
    }
}