using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Reports.PDFs
{
    internal class DailySalesReport
    {
        public void Generate(string filePath)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.Margin(20);

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Element(ComposeHeader);

                            column.Item()
                                .PaddingTop(10);

                            column.Item()
                                .Text("DAILY SALES REPORT")
                                .FontSize(16)
                                .Bold();
                        });

                    page.Content()
                        .Text("Sample Report");

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(filePath);
        }//generate

        public void ComposeHeader(IContainer container)
        {
            ShopService shopService = new ShopService();
            DataTable shopData = shopService.GetShop();

            string shopName = shopData.Rows[0]["name"].ToString();
            string shopAddress = shopData.Rows[0]["address"].ToString();
            string shopPhone = shopData.Rows[0]["phone"].ToString();
            string shopLogoPath = shopData.Rows[0]["shop_logo"].ToString();

            container.Row(row =>
            {
                row.ConstantItem(60)
                    .Height(60)
                    .Image(shopLogoPath)
                    .FitHeight();

                row.RelativeItem()
                    .PaddingLeft(10)
                    .Column(column =>
                    {
                        column.Item()
                            .Text(shopName)
                            .FontSize(18)
                            .Bold();

                        column.Item()
                            .Text(shopAddress);

                        column.Item()
                            .Text("Tel: " + shopPhone);

                    });
            });
        }

    }//class
}
