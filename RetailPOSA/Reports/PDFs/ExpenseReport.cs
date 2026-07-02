using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RetailPOSA.Reports.ReportServices;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Reports.PDFs
{
    internal class ExpenseReport
    {
        public void Generate(string filePath, string startDate, string endDate)
        {
            SalesReportService service = new SalesReportService();
            DataTable salesData = service.GetExpenses(startDate, endDate);

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
                                .Padding(8)
                                .Text("Expenses between " + startDate + " and " + endDate)
                                .FontSize(10);
                        });

                    page.Content()
                        .Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(30);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(70);
                            });
                            table.Header(header => {
                                header.Cell().BorderBottom(2).Text("#").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Date Time").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Category").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Description").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Amount").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("User").FontSize(10);
                            });//header

                            int i = 1;
                            decimal total = 0;
                            foreach (DataRow row in salesData.Rows)
                            {
                                total += Convert.ToDecimal(row["amount"]);

                                table.Cell().Padding(4).Text(i.ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["datetime"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["category_name"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["description"].ToString()).FontSize(10);
                                table.Cell().Padding(4).AlignRight().Text(row["amount"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["username"].ToString()).FontSize(10);
                                i++;
                            }//foreach

                            table.Cell()
                                .ColumnSpan(5)
                                .AlignRight()
                                .Padding(8)
                                .Text("Total")
                                .FontSize(12)
                                .Bold();

                            table.Cell()
                                .AlignRight()
                                .Padding(8)
                                .Text(total.ToString())
                                .FontSize(12)
                                .Bold();
                        });//table

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

        private void ComposeHeader(IContainer container)
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
                    .FitWidth();

                row.RelativeItem()
                    .PaddingLeft(10)
                    .AlignCenter()
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

                row.RelativeItem()
                    .Padding(5)
                    .Text("Expenses Report")
                    .AlignCenter()
                    .FontSize(18)
                    .Bold();
            });
        }//Header


    }//class
}
