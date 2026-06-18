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

                    //page.Content()
                    //    .Table(table =>
                    //    {
                            
                    //    });
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
