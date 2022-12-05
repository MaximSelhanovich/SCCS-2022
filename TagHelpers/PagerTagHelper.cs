﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WEB_053502_Selhanovich.TagHelpers
{
    public class PagerTagHelper: TagHelper
    {
        LinkGenerator _linkGenerator;
        public int PageCurrent { get; set; }
        public int PageTotal { get; set; }
        public string PagerClass { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int? GroupId { get; set; }

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)

        {
            // контейнер разметки пейджера
            output.TagName = "nav";
            // пейджер
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);
            for (int i = 1; i <= PageTotal; i++)
            {
                // получение Url для одной кнопки пейджера
                var url = _linkGenerator.GetPathByAction(Action,
                Controller,

                new
                {
                    pageNumber = i,
                    category = GroupId == 0
                ? null
                : GroupId
                });

                // получение разметки одной кнопки пейджера
                var item = GetPagerItem(

                url: url,
                text: i.ToString(),
                active: i == PageCurrent
                //disabled: i == PageCurrent
                );
                // добавить кнопку в разметку пейджера
                ulTag.InnerHtml.AppendHtml(item);
            }
            // добавить пейджер в контейнер
            output.Content.AppendHtml(ulTag);
        }

        /// <summary>
        /// Генерирует разметку одной кнопки пейджера
        /// </summary>
        /// <param name="url">адрес</param>
        /// <param name="text">текст кнопки пейджера</param>
        /// <param name="active">признак текущей страницы</param>
        /// <returns>объект класса TagBuilder</returns>
        private TagBuilder GetPagerItem(string url, string text,
        bool active = false)

        {
            // создать тэг <li>
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");
            //liTag.AddCssClass(disabled ? "disabled" : "");
            // создать тэг <a>
            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);
            // добавить тэг <a> внутрь <li>
            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }
    }
}