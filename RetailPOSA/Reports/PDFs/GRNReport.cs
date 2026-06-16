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
        CommonPDF commonPdf = new CommonPDF();
        GrnHeaderService headerService = new GrnHeaderService();

        public void Generate(string filePath, int grnHeaderID)
        {
            //get header data
            DataTable headerData = headerService.GetGrnHeaderByID(grnHeaderID);
            string invoiceNo = headerData.Rows[0]["invoice_no"].ToString();

            Document.Create(container => {
                container.Page(page => {
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.Margin(20);

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Element(commonPdf.ComposeHeader);
                         
                            column.Item()
                                .PaddingTop(10);

                            column.Item()
                                .Text("GRN Purchase Report")
                                .FontSize(16)
                                .Bold();
                        });
                    //page.Content()
                    //    .Table(table => { 
                            
                    //    });
                });
            }).GeneratePdf(filePath);
        }//generate

    }//class
}
