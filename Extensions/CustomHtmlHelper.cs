using Microsoft.AspNetCore.Html;
using System;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc.Rendering {
    public static class MyHtmlHelperExtensions {
        public static IHtmlContent ColorfulHeading(this IHtmlHelper htmlHelper, int level, string color, string content) {
            level = level < 1 ? 1 : level;
            level = level > 6 ? 6 : level;
            var tagName = $"h{level}";
            var tagBuilder = new TagBuilder(tagName);
            tagBuilder.Attributes.Add("style", $"color:{color ?? "green"}");
            tagBuilder.InnerHtml.Append(content ?? string.Empty);
            return tagBuilder;
        }

        public static IHtmlContent TableExample(this IHtmlHelper htmlHelper, string[] columns, string[,] content) {
            var tableBuilder = new TagBuilder("table");
            tableBuilder.Attributes.Add("border", "1");
            var headerBuilder = new TagBuilder("tr");
            foreach (var cn in columns) {
                var headerCellBuilder = new TagBuilder("th");
                headerCellBuilder.InnerHtml.Append(cn);
                headerBuilder.InnerHtml.AppendHtml(headerCellBuilder);
            }
            tableBuilder.InnerHtml.AppendHtml(headerBuilder);

            int colCount = columns.Length;
            int rowCount = content.Length / colCount;
            for (int r = 0; r < rowCount; r++) {
                var rowBuilder = new TagBuilder("tr");
                for (int c = 0; c < colCount; c++) {
                    var cellBuilder = new TagBuilder("td");
                    cellBuilder.InnerHtml.Append(content[r, c]);
                    rowBuilder.InnerHtml.AppendHtml(cellBuilder);
                }
                tableBuilder.InnerHtml.AppendHtml(rowBuilder);
            }
            return tableBuilder;
        }

        public static IHtmlContent Calendar(this IHtmlHelper htmlHelper, IGrouping<DayOfWeek, DateTime>[] content) {

            var tableBuilder = new TagBuilder("table");
            tableBuilder.Attributes.Add("border", "1");
            var headerBuilder = new TagBuilder("tr");
            
            foreach (var cn in content) {
                var headerCellBuilder = new TagBuilder("th");
                headerCellBuilder.InnerHtml.Append(cn.Key.ToString());
                headerBuilder.InnerHtml.AppendHtml(headerCellBuilder);
            }
            tableBuilder.InnerHtml.AppendHtml(headerBuilder);
            var days = content.SelectMany(g => g).OrderBy(d => d.Day).ToList();

            int columnCount = content.Length;
            TagBuilder rowBuilder = null;
            for(int i = 0; i < days.Count; i++){
                if(i%columnCount == 0)
                    rowBuilder = new TagBuilder("tr");
                var cellBuilder = new TagBuilder("td");
                cellBuilder.InnerHtml.Append(days[i].Day.ToString());
                rowBuilder.InnerHtml.AppendHtml(cellBuilder);
                if(i%columnCount == 0)
                    tableBuilder.InnerHtml.AppendHtml(rowBuilder);
            }
            
            return tableBuilder;
        }
    }
}