using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using iTextSharp.text;

using iTextSharp.text.pdf;

using System.IO;

public partial class _Default : System.Web.UI.Page

{

    protected void Page_Load(object sender, EventArgs e)

    {

    }

    protected void btnShow_OnClick(object sender, EventArgs e)

    {

        //server folder path which is stored your PDF documents

        string path = Server.MapPath("PDF-Files");

        string imagepath = Server.MapPath("Upload");

        string filename = path + "/Doc3.pdf";







        //Create new PDF document

        Document document = new Document(PageSize.A4, 20, 20, 20, 20);

        try

        {
            //PdfReader reader = new PdfReader(new FileStream(filename, FileMode.Open, FileAccess.Read));
            var a=PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            document.Open();

            Chunk chunk = new Chunk("Go to page 2");
            var des = new PdfDestination(PdfDestination.XYZ, 0, document.PageSize.Height, 1.40f);
            PdfAction action = PdfAction.GotoLocalPage(2, des, a);
            chunk.SetAction(action);
            Paragraph p5 = new Paragraph();
            p5.Add(chunk);
            document.Add(p5);






            //Font link = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, new Color(0, 0, 255));

            //Anchor anchor = new Anchor("www.mikesdotnetting.com", link);

            //anchor.Reference = "http://www.mikesdotnetting.com";

            //document.Add(anchor);

            //Anchor click = new Anchor("Click to go to Target");

            //click.Reference = "#target";

            //Paragraph p1 = new Paragraph();

            //p1.Add(click);

            //document.Add(p1);



            Paragraph p2 = new Paragraph();

            p2.Add(new Chunk("\n\n\n\n\n\n\n\n"));

            document.Add(p2);
                                                    
                            
                            
            Anchor target = new Anchor("This is the Target");

            target.Name = "target";

            Paragraph p3 = new Paragraph();

            p3.Add(target);

            document.Add(p3);


            Chapter chapter1 = new Chapter(new Paragraph("This is Chapter 1"), 1);

            Section section1 = chapter1.AddSection(20f, "Section 1.1", 2);

            Section section2 = chapter1.AddSection(20f, "Section 1.2", 2);

            Section subsection1 = section2.AddSection(20f, "Subsection 1.2.1", 3);

            Section subsection2 = section2.AddSection(20f, "Subsection 1.2.2", 3);

            Section subsubsection = subsection2.AddSection(20f, "Sub Subsection 1.2.2.1", 4);

            Chapter chapter2 = new Chapter(new Paragraph("This is Chapter 2"), 1);

            Section section3 = chapter2.AddSection("Section 2.1", 2);

            Section subsection3 = section3.AddSection("Subsection 2.1.1", 3);

            Section section4 = chapter2.AddSection("Section 2.2", 2);

            chapter1.BookmarkTitle = "Changed Title";

            chapter1.BookmarkOpen = true;

            chapter2.BookmarkOpen = false;

            document.Add(chapter1);

            document.Add(chapter2);


            //iTextSharp.text.Document doc = new iTextSharp.text.Document();
            
            document.Close();


            //Chunk chunk = new Chunk("Go to page 3");
            //PdfAction action = PdfAction.GotoLocalPage(3, new PdfDestination(0), a);
            //chunk.SetAction(action);

            //document.Add(chunk);

            //Chunk chunk = new Chunk("Go to page 3");
            //var des = new PdfDestination(PdfDestination.XYZ, 0, document.PageSize.Height, 0.95f);
            //PdfAction action = PdfAction.GotoLocalPage(2, des, a);
            //chunk.SetAction(action);
            //Paragraph p5 = new Paragraph();
            //p5.Add(chunk);
            //pdfDoc.Add(p5);

        }

        catch (Exception ex)

        {

        }

        finally

        {

            document.Close();

            ShowPdf(filename);

        }

    }

    public void ShowPdf(string filename)

    {

        //Clears all content output from Buffer Stream

        Response.ClearContent();

        //Clears all headers from Buffer Stream

        Response.ClearHeaders();

        //Adds an HTTP header to the output stream

        Response.AddHeader("Content-Disposition", "inline;filename=" + filename);

        //Gets or Sets the HTTP MIME type of the output stream

        Response.ContentType = "application/pdf";

        //Writes the content of the specified file directory to an HTTP response output stream as a file block

        Response.WriteFile(filename);

        //sends all currently buffered output to the client

        Response.Flush();

        //Clears all content output from Buffer Stream

        Response.Clear();

    }
    //private PdfPTable CreatePDFTable(DataTable dt)
    //{
    //    if (dt != null)
    //    {  
    //        PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
    //        PdfPCell PdfPCell = null;
    //        //Add Header of the pdf table
    //        PdfPCell = new PdfPCell(new Phrase(new Chunk("ID")));
    //        PdfTable.AddCell(PdfPCell);
    //        PdfPCell = new PdfPCell(new Phrase(new Chunk("Name")));
    //        PdfTable.AddCell(PdfPCell);
    //        //How add the data from datatable to pdf table
    //        for (int rows = 0; rows < dt.Rows.Count; rows++)
    //        {
    //            for (int column = 0; column < dt.Columns.Count; column++)
    //            {
    //                PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString())));
    //                PdfTable.AddCell(PdfPCell);
    //            }
    //        }
    //        PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table
    //        return PdfTable;

    //        //doc.Add(paragraph);// add paragraph to the document

    //        //doc.Add(PdfTable); // add pdf table to the document


    //    }

    //}
}

