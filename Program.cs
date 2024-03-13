using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using ZennoLab.CommandCenter;
using ZennoLab.Emulation;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoLab.InterfacesLibrary.ProjectModel.Enums;

namespace Telegraph
{
    /// <summary>
    /// Класс для запуска выполнения скрипта
    /// </summary>
    public class Program : IZennoExternalCode
    {
        /// <summary>
        /// Метод для запуска выполнения скрипта
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        /// <returns>Код выполнения скрипта</returns>		
        public int Execute(Instance instance, IZennoPosterProjectModel project)
        {
            var t = new MyTelegraph(project);

            t.CreateAccount("Автоматизация");

            var arrImg = new[] {
                "https://images.wallpaperscraft.ru/image/single/bmw_avtomobil_bamper_191131_1280x720.jpg",
                "https://images.wallpaperscraft.ru/image/single/bmw_m3_sportivnyj_94739_1280x720.jpg",
                "https://images.wallpaperscraft.ru/image/single/bmw_vid_speredi_fary_168002_1280x720.jpg"
            };

            var creator = t.ContentBuilder;

            for (int i = 0; i < arrImg.Length; i++)
            {
                creator.AddImg(arrImg[i])
                    .AddText("Какойто текст для картинки " + (i + 1));
            }
            
            var content = creator
                .AddText("")
                .AddLink("https://images.wallpaperscraft.ru/image/single/bmw_avtomobil_bamper_191131_1280x720.jpg", "Ссылка")
                .Create();

            var pageUrl = t.CreatePage("Постинг статей на автомате. Автоматизация Telegra.ph", content);

            instance.ActiveTab.Navigate(pageUrl);




            return 0;
        }
    }
}