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
    internal class GRNReport
    {
        GrnHeaderService headerService = new GrnHeaderService();

        public void Generate(string filePath, int grnHeaderID)
        {
            //get header data
            DataTable headerData = headerService.GetGrnHeaderByID(grnHeaderID);
            string invoiceNo = headerData.Rows[0]["invoice_no"].ToString();            
            string submittedDate = headerData.Rows[0]["date_submitted"].ToString();
            string userName = headerData.Rows[0]["username"].ToString();

            string companyName = headerData.Rows[0]["company_name"].ToString();
            string supplierName = headerData.Rows[0]["supplier_name"].ToString();
            string supplierContact = headerData.Rows[0]["contact_no"].ToString();

            //get details
            GrnDetailService detailService = new GrnDetailService();
            DataTable detailData = detailService.GetGrnDetailsByGrnHeaderID(grnHeaderID);

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
                                .PaddingTop(5);

                            column.Item().Row(row => {
                                row.RelativeItem().Column(col => {
                                    col.Item().Text("Invoice No: " + invoiceNo);
                                    col.Item().Text("Date: " + submittedDate);
                                    col.Item().Text("User: " + userName);
                                });
                                row.RelativeItem().Column(col => {
                                    col.Item().Text("Company: " + companyName);
                                    col.Item().Text("Supplier: " + supplierName);
                                    col.Item().Text("Contact: " + supplierContact);
                                });
                            });
                        });

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(30);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(50);//qty
                                columns.ConstantColumn(50);//free qty
                                columns.ConstantColumn(50);//purchase price
                                columns.ConstantColumn(50);//selling price
                                columns.ConstantColumn(50);//discount
                                columns.ConstantColumn(50);//final price
                                columns.ConstantColumn(75);//total price
                            });
                            table.Header(header => {
                                header.Cell().BorderBottom(2).Text("#").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Barcode").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Product").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Qty").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Free").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Pur.Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Sel.Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Disc").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Price").FontSize(10);
                                header.Cell().BorderBottom(2).Padding(4).Text("Total").FontSize(10);

                            });

                            int i = 1;
                            decimal purchaseTotal = 0;
                            foreach (DataRow row in detailData.Rows)
                            {
                                //decimal qty = Convert.ToDecimal(row["qty"].ToString());
                                string displayQty = Convert.ToDecimal(row["qty"]).ToString("0.###");
                                string freeQty = Convert.ToDecimal(row["free_qty"]).ToString("0.###");

                                table.Cell().Padding(4).Text(i.ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["barcode"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["product_name"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(displayQty).FontSize(10);
                                table.Cell().Padding(4).Text(freeQty).FontSize(10);
                                table.Cell().Padding(4).Text(row["purchase_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["selling_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["discount"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["final_price"].ToString()).FontSize(10);
                                table.Cell().Padding(4).Text(row["purchase_total"].ToString()).FontSize(10);

                                purchaseTotal += Convert.ToDecimal(row["purchase_total"]);
                                i++;
                            }//foreach

                            table.Cell()
                                .ColumnSpan(9)
                                .AlignRight()
                                .Padding(8)
                                .Text("Purchase Total")
                                .FontSize(12)
                                .Bold();

                            table.Cell()
                                .AlignRight()
                                .Padding(8)
                                .Text(purchaseTotal.ToString())
                                .FontSize(12)
                                .Bold();
                        });
                });
            }).GeneratePdf(filePath);
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
                    .Text("Grn Purchase Report")
                    .AlignCenter()
                    .FontSize(18)
                    .Bold();
            });
        }//Header

    }//class
}
