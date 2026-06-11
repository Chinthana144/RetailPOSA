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
using System.Windows.Forms;

namespace RetailPOSA.Reports.PDFs
{
    internal class DailySalesReport
    {
        public void Generate(string filePath, string startDate, string endDate)
        {
            SalesReportService service = new SalesReportService();
            DataTable salesData = service.GetDailySales(startDate, endDate);

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
                        .Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(30);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(50);
                                //columns.RelativeColumn();
                                //columns.RelativeColumn();
                            });
                            table.Header(header => { 
                                header.Cell().BorderBottom(2).Text("#").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Date Time").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Invoice").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Items").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Total").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Discount").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Returns").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("SubTotal").FontSize(10);
                                //header.Cell().BorderBottom(2).Padding(8).Text("Paymethod");
                                //header.Cell().BorderBottom(2).Padding(8).Text("User");
                            });//header

                            int i = 1;
                            foreach (DataRow row in salesData.Rows)
                            {
                                table.Cell().Padding(8).Text(i.ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["issued_date"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["invoice_no"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["item_count"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["total"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["discounts"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["return_amount"].ToString()).FontSize(10);
                                table.Cell().Padding(8).Text(row["sub_total"].ToString()).FontSize(10);
                                i++;
                            }//foreach

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
                    .FitWidth();

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
