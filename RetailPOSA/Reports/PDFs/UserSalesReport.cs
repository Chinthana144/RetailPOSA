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
    internal class UserSalesReport
    {
        public void Generate(string filePath, string startDate, string endDate)
        {
            SalesReportService service = new SalesReportService();
            DataTable salesData = service.GetUserSales(startDate, endDate);

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
                                .Text("Sales between " + startDate + " and " + endDate)
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
                                columns.RelativeColumn();
                                columns.ConstantColumn(70);
                            });
                            table.Header(header => {
                                header.Cell().BorderBottom(2).Text("#").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("User").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Invoices").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Sale").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Discounts").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Returns").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("SubTotal").FontSize(10);
                            });//header

                            int i = 1;
                            decimal total = 0;
                            foreach (DataRow row in salesData.Rows)
                            {
                                total += Convert.ToDecimal(row["sub_total"]);

                                table.Cell().Padding(4).Text(i.ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["username"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["row_count"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["sale_total"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["total_discounts"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["total_returns"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["sub_total"].ToString()).FontSize(10);
                                i++;
                            }//foreach

                            table.Cell()
                                .ColumnSpan(6)
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
                    .Text("User Sales Report")
                    .AlignCenter()
                    .FontSize(18)
                    .Bold();
            });
        }//Header


    }//class
}
