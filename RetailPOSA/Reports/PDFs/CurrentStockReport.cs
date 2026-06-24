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
    internal class CurrentStockReport
    {
        public void Generate(string filePath)
        { 
            InventoryReportService service = new InventoryReportService();
            DataTable inventoryData = service.GetCurrentStock();

            Document.Create(container => {
                container.Page(page => {
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
                                columns.ConstantColumn(60);
                                columns.ConstantColumn(60);
                                columns.ConstantColumn(60);
                                columns.RelativeColumn();
                            });
                            table.Header(header => {
                                header.Cell().BorderBottom(2).Text("#").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Barcode").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Product").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Ini.Qty").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Cur.Qty").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Pur.Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Sel.Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Discount").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Fin.Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(8).Text("Total.Price").FontSize(10);
                            });//header

                            int i = 1;
                            foreach (DataRow row in inventoryData.Rows)
                            {
                                string initialQty = Convert.ToDecimal(row["initial_qty"]).ToString("0.###");
                                string currentQty = Convert.ToDecimal(row["current_qty"]).ToString("0.###");

                                table.Cell().Padding(4).Text(i.ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["barcode"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["name"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(initialQty).FontSize(10);
                                table.Cell().Padding(4).Text(currentQty).FontSize(10);
                                table.Cell().Padding(4).Text(row["purchase_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["selling_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["discount"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["final_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["purchase_total"].ToString()).FontSize(10);

                                i++;
                            }//foreach
                        });
                });
            }).GeneratePdf(filePath);
        }

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
                    .Text("Current Stock Report")
                    .AlignCenter()
                    .FontSize(18)
                    .Bold();
            });
        }//Header

    }//class
}
