using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;

namespace ProductLableGeneration
{
    public class PDFGenerator
    {
        private const int TITLE_FONT_SIZE = 7;
        private const int CONTENT_FONT_SIZE = 14;
        // 1cm = 37.7777778f
        private const float UNIT = 37.7777778f;

        private const float HEIGHTFORTABLE1 = 30f;
        private const float HEIGHTFORTABLE2 = 30f;
        private const float HEIGHTFORTABLE3 = 30f;

        public void Excecute()
        {
            var path = @"C:\Users\robin.sun\Desktop\MyFirstPDF" + DateTime.Now.Millisecond + ".pdf";
            var list = new List<Label>();
            list.Add(new Label
            {
                Product = new Product
                {
                    STWPN = "LZ600-1665 A",
                    PartNumber = "7356076060",
                    QuantiryUp = 30.ToString(),
                    QuantityDown = 36.ToString(),
                    SupplierCode = "0086205",
                    EngineeringChange = "01593",
                    Receiver = "FIAT AUTO SATA MELFI",
                    SupplierAddress = "New Thai Wheel LZ600",
                    NetWeight = "282",
                    GrossWeight = "307",
                    Boxes = "1",
                    Description = "Aolly Wheel"
                },
                FixedQuantity = 30.ToString(),
                Date = "D140203",
                SerialNumber = "20140131001",
                BatchNumber = "201401311",
                TotalAmount = "1056"
            });
            //list.Add(new Label
            //{
            //    Product = new Product
            //    {
            //        STWPN = "LZ600-1665 A",
            //        PartNumber = "7356076060",
            //        QuantiryUp = 30.ToString(),
            //        QuantityDown = 36.ToString(),
            //        SupplierCode = "0086205",
            //        EngineeringChange = "01593",
            //        Receiver = "FIAT AUTO SATA MELFI",
            //        SupplierAddress = "New Thai Wheel LZ600",
            //        NetWeight = "282",
            //        GrossWeight = "307",
            //        Boxes = "1",
            //        Description = "Aolly Wheel"
            //    },
            //    FixedQuantity = 30.ToString(),
            //    Date = "D140203",
            //    SerialNumber = "20140131001",
            //    BatchNumber = "201401311",
            //    TotalAmount = "1056"
            //});
            Excecute(path, list);
        }


        public void ExcecuteAll(Dictionary<string, List<Label>> dic)
        {
            foreach (var keyValuePair in dic)
            {
                var filePath = keyValuePair.Key;
                var list = keyValuePair.Value;
                Excecute(filePath, list);
            }
        }

        public void Excecute(string path, List<Label> list)
        {
            var doc = new Document(PageSize.A4);
            var output = new FileStream(path, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();

            for (var i = 0; i < list.Count; i++)
            {
                if (i != 0 && i % 2 == 0)
                {
                    doc.NewPage();
                }
                var label = list[i];
                var imagePartNumberPDF417Code = GeneratePDF417BarCode(label.Product.PartNumber + "P");

                var table1 = new PdfPTable(2);
                table1.SpacingBefore = 10;
                if (i % 2 != 0)
                {
                    table1.SpacingBefore = 40;
                }
                table1.DefaultCell.Border = 0;
                table1.WidthPercentage = 100;
                table1.DefaultCell.FixedHeight = HEIGHTFORTABLE1;


                var cell11 = new PdfPCell();
                cell11.Colspan = 1;
                cell11.AddElement(new Paragraph("RECEIVER:",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                var p = new Paragraph(label.Product.Receiver,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE + 1, BaseColor.BLACK));
                p.SpacingAfter = 5;
                cell11.VerticalAlignment = Element.ALIGN_LEFT;
                cell11.AddElement(p);
                table1.AddCell(cell11);

                var cell12 = new PdfPCell();
                cell12.Colspan = 1;
                cell12.AddElement(new Paragraph("DOCK/GATE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                cell12.VerticalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cell12);

                var cell21 = new PdfPCell();
                cell21.AddElement(new Paragraph("DOCUMENT NUMBER NO",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                cell21.VerticalAlignment = Element.ALIGN_LEFT;
                cell21.Rowspan = 2;
                table1.AddCell(cell21);

                var innerTable = new PdfPTable(3);
                innerTable.DefaultCell.Border = 0;
                innerTable.WidthPercentage = 100;
                innerTable.DefaultCell.FixedHeight = 100f;
                var cell22_11 = new PdfPCell();
                cell22_11.BorderWidthTop = 0;
                cell22_11.BorderWidthRight = 0;
                cell22_11.BorderWidthLeft = 0;
                cell22_11.BorderWidthBottom = 0;
                cell22_11.Colspan = 3;
                cell22_11.AddElement(new Paragraph("SUPPLIER ADDRESS",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Product.SupplierAddress,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 5;
                cell22_11.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_11.AddElement(p);
                innerTable.AddCell(cell22_11);
                var cell22_21 = new PdfPCell();
                cell22_21.Colspan = 1;
                cell22_21.AddElement(new Paragraph("NET WT (kg)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Product.NetWeight,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 5;
                cell22_21.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_21.AddElement(p);
                innerTable.AddCell(cell22_21);
                var cell22_22 = new PdfPCell();
                cell22_22.Colspan = 1;
                cell22_22.AddElement(new Paragraph("GROSS WT (kg)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Product.GrossWeight,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 5;
                cell22_22.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_22.AddElement(p);
                innerTable.AddCell(cell22_22);
                var cell22_23 = new PdfPCell();
                cell22_23.Colspan = 1;
                cell22_23.AddElement(new Paragraph("NO BOXES",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Product.Boxes,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 5;
                cell22_23.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_23.AddElement(p);
                innerTable.AddCell(cell22_23);
                var cell22 = new PdfPCell(innerTable);
                table1.AddCell(cell22);

                doc.Add(table1);

                var table2 = new PdfPTable(11);
                table2.DefaultCell.Border = 0;
                table2.WidthPercentage = 100.2f;
                table2.DefaultCell.FixedHeight = HEIGHTFORTABLE2;
                var cell31 = new PdfPCell();
                cell31.BorderWidthTop = 0;
                cell31.BorderWidthBottom = 0;
                cell31.Colspan = 4;
                cell31.Rowspan = 1;
                cell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                p = new Paragraph("PART NUMBER (P)", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.IndentationLeft = -7f;
                p.SpacingAfter = 0;
                cell31.AddElement(p);
                cell31.PaddingLeft = 10;
                cell31.BorderWidthRight = 0;
                p = new Paragraph(label.Product.PartNumber,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE + 11, BaseColor.BLACK));
                p.IndentationLeft = 5;
                p.SpacingAfter = 10;
                cell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell31.AddElement(p);
                var cell32 = new PdfPCell();
                cell32.BorderWidthTop = 0;
                cell32.BorderWidthLeft = 0;
                cell32.BorderWidthRight = 0;
                cell32.BorderWidthBottom = 0;
                cell32.Colspan = 4;
                cell32.Rowspan = 1;
                cell32.PaddingTop = 15f;
                cell32.VerticalAlignment = Element.ALIGN_CENTER;
                cell32.AddElement(imagePartNumberPDF417Code);

                var cell33 = new PdfPCell();
                cell33.BorderWidthTop = 0;
                cell33.BorderWidthLeft = 0;
                cell33.BorderWidthBottom = 0;
                cell33.Colspan = 4;
                cell33.Rowspan = 1;
                cell33.PaddingTop = 2;
                Image logo = GenerateLogo();
                logo.IndentationLeft = 5;
                logo.Alignment = Image.ALIGN_CENTER;
                cell33.AddElement(logo);
                table2.AddCell(cell31);
                table2.AddCell(cell32);
                table2.AddCell(cell33);

                doc.Add(table2);

                var table3 = new PdfPTable(2);
                table3.DefaultCell.Border = 0;
                table3.WidthPercentage = 100;
                table3.DefaultCell.FixedHeight = HEIGHTFORTABLE3;
                var innerTable41 = new PdfPTable(2);
                var cell41_1 = new PdfPCell();
                cell41_1.PaddingLeft = 10f;
                cell41_1.Colspan = 1;
                cell41_1.Rowspan = 1;
                cell41_1.BorderWidth = 0;
                p = new Paragraph("QUANTITY (Q)", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.IndentationLeft = -7f;
                cell41_1.AddElement(p);
                p = new Paragraph(label.FixedQuantity,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE + 12, BaseColor.BLACK));
                cell41_1.AddElement(p);
                innerTable41.AddCell(cell41_1);
                var cell41_2 = new PdfPCell();
                cell41_2.Colspan = 1;
                cell41_2.Rowspan = 1;
                cell41_2.BorderWidth = 0;
                innerTable41.AddCell(cell41_2);
                var cell41 = new PdfPCell(innerTable41);
                cell41.Colspan = 1;
                cell41.Rowspan = 1;
                table3.AddCell(cell41);

                var interTable42 = new PdfPTable(2);
                interTable42.DefaultCell.Border = 0;
                interTable42.WidthPercentage = 100;
                interTable42.DefaultCell.FixedHeight = 100f;
                var cell42_1 = new PdfPCell();
                cell42_1.Colspan = 2;
                cell42_1.Rowspan = 1;
                p = new Paragraph("DESCRIPTION", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                cell42_1.AddElement(p);
                p = new Paragraph(label.Product.Description,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = -3;
                cell42_1.VerticalAlignment = Element.ALIGN_LEFT;
                cell42_1.AddElement(p);
                interTable42.AddCell(cell42_1);
                var cell42_2 = new PdfPCell();
                cell42_2.BorderWidthBottom = 0;
                cell42_2.BorderWidthRight = 0;
                cell42_2.BorderWidthLeft = 0;
                cell42_2.BorderWidthTop = 0;
                cell42_2.Colspan = 2;
                cell42_2.Rowspan = 2;
                cell42_2.AddElement(new Paragraph("LOGISTIC REFERNCE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph("     ", FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 1;
                p.SpacingAfter = 8;
                cell42_2.VerticalAlignment = Element.ALIGN_LEFT;
                cell42_2.AddElement(p);
                interTable42.AddCell(cell42_2);
                var cell42_3 = new PdfPCell();
                cell42_3.Colspan = 1;
                cell42_3.Rowspan = 1;
                cell42_3.AddElement(new Paragraph("DATE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Date, FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 1;
                cell42_3.VerticalAlignment = Element.ALIGN_LEFT;
                cell42_3.AddElement(p);
                interTable42.AddCell(cell42_3);
                var cell42_32 = new PdfPCell();
                cell42_32.Colspan = 1;
                cell42_32.Rowspan = 1;
                cell42_32.AddElement(new Paragraph("ENGINERING CHANGE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK)));
                p = new Paragraph(label.Product.EngineeringChange,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 1;
                cell42_32.VerticalAlignment = Element.ALIGN_LEFT;
                cell42_32.AddElement(p);
                interTable42.AddCell(cell42_32);
                var cell42_4 = new PdfPCell();
                cell42_4.BorderWidthBottom = 0;
                cell42_4.BorderWidthRight = 0;
                cell42_4.BorderWidthLeft = 0;
                cell42_4.BorderWidthTop = 0;
                cell42_4.Colspan = 2;
                cell42_4.Rowspan = 2;
                p = new Paragraph("BATCH NUMBER (H)", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.IndentationLeft = 0f;
                cell42_4.AddElement(p);
                cell42_4.VerticalAlignment = Element.ALIGN_LEFT;
                var batchSize = CONTENT_FONT_SIZE;
                if (label.BatchNumber.Length > 9)
                {
                    batchSize = batchSize - 1;
                }
                p = new Paragraph(label.BatchNumber, FontFactory.GetFont("Helvetica", batchSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.IndentationLeft = 150f;
                cell42_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell42_4.AddElement(p);
                interTable42.AddCell(cell42_4);

                var cell42 = new PdfPCell(interTable42);
                cell42.Colspan = 1;
                cell42.Rowspan = 2;
                table3.AddCell(cell42);

                var innerTableA = new PdfPTable(2);
                var innerTableA_Left = new PdfPTable(1);
                var A_Left_1 = new PdfPCell();
                A_Left_1.Colspan = 1;
                A_Left_1.Rowspan = 1;
                p = new Paragraph("SUPPLIER CODE (V)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                A_Left_1.AddElement(p);
                p = new Paragraph(label.Product.SupplierCode,
                    FontFactory.GetFont("Helvetica", CONTENT_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 10;
                A_Left_1.AddElement(p);
                innerTableA_Left.AddCell(A_Left_1);
                var A_Left_2 = new PdfPCell();
                A_Left_2.Colspan = 1;
                A_Left_2.Rowspan = 1;
                p = new Paragraph("SERIAL NUMBER (M)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                A_Left_2.AddElement(p);
                var serialSize = CONTENT_FONT_SIZE;
                if (label.SerialNumber.Length > 9)
                {
                    serialSize = serialSize - 1;
                }
                p = new Paragraph(label.SerialNumber, FontFactory.GetFont("Helvetica", serialSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                A_Left_2.AddElement(p);
                innerTableA_Left.AddCell(A_Left_2);
                var cellA_Left = new PdfPCell(innerTableA_Left);
                cellA_Left.Colspan = 1;
                cellA_Left.Rowspan = 1;
                var innerTableA_Right = new PdfPTable(1);
                var A_Right = new PdfPCell();
                A_Right.Colspan = 1;
                A_Right.Rowspan = 1;
                Image im = GenerateQRCodeByLabel(label);
                im.Alignment = Image.ALIGN_CENTER;
                A_Right.HorizontalAlignment = Element.ALIGN_CENTER;
                A_Right.VerticalAlignment = Element.ALIGN_MIDDLE;
                A_Right.AddElement(im);
                innerTableA_Right.AddCell(A_Right);
                var cellA_Right = new PdfPCell(innerTableA_Right);
                cellA_Right.Colspan = 1;
                cellA_Right.Rowspan = 1;
                innerTableA.AddCell(cellA_Left);
                innerTableA.AddCell(cellA_Right);
                var cell51 = new PdfPCell(innerTableA);
                table3.AddCell(cell51);

                table3.CompleteRow();
                doc.Add(table3);
            }
            doc.Close();
        }

        public Image GenerateQRCodeByLabel(Label label)
        {
            string fixedQuantity = label.FixedQuantity;
            bool signal = true;
            while (signal)
            {
                if (fixedQuantity.Length < 9)
                {
                    fixedQuantity = "0" + fixedQuantity;
                }
                else
                {
                    signal = false;
                }
            }
            string totalAmount = label.TotalAmount;
            bool signal2 = true;
            while (signal2)
            {
                if (totalAmount.Length < 4)
                {
                    totalAmount = "0" + totalAmount;
                }
                else
                {
                    signal2 = false;
                }
            }
            string partNumber = label.Product.PartNumber;
            bool signal3 = true;
            while (signal3)
            {
                if (partNumber.Length < 11)
                {
                    partNumber = "0" + partNumber;
                }
                else
                {
                    signal3 = false;
                }
            }
            string s = "M" + label.SerialNumber + ";" + label.Product.PartNumber + ";" + label.Product.SupplierCode +
                       ";" + fixedQuantity + ";" + totalAmount + ";" + label.BatchNumber + ";" + label.Date + ";";
            Image image = GenerateQRCode(s);
            return image;
        }

        public Image GenerateBarCode(PdfWriter writer, string data)
        {
            var height = 20f;
            return GenerateBarCode(writer, data, height);
        }

        public Image GenerateBarCode(PdfWriter writer, string data, float height)
        {
            var code39ext = new Barcode39();
            code39ext.Code = data;
            code39ext.StartStopText = false;
            code39ext.Extended = false;
            code39ext.BarHeight = height;
            code39ext.Size = 5f;
            code39ext.Baseline = 0f;
            code39ext.X = 1.09f;
            var imageCode39 = code39ext.CreateImageWithBarcode(writer.DirectContent, null, BaseColor.WHITE);
            return imageCode39;
        }

        public Image GenerateQRCode(string data)
        {
            MyBarcodeQRCode qrcode = new MyBarcodeQRCode(data, 100, 100, null);
            System.Drawing.Image qrOriginalImage = qrcode.GetImage();
            System.Drawing.Image img2 = ImageUtil.CropUnwantedBackground(new Bitmap(qrOriginalImage));
            Image newQrCodeImage = Image.GetInstance(imageToByteArray(img2));
            newQrCodeImage.ScaleAbsoluteWidth(UNIT * 2.88854286f);
            newQrCodeImage.ScaleAbsoluteHeight(UNIT * 2.88854286f);
            newQrCodeImage.IndentationLeft = 80f;
            return newQrCodeImage;
        }

        public static byte[] imageToByteArray(System.Drawing.Image image)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imgArray = (byte[])converter.ConvertTo(image, typeof(byte[]));
            return imgArray;
        }


        public Image GeneratePDF417BarCode(string data)
        {
            BarcodePDF417 barcodePdf417 = new BarcodePDF417();
            barcodePdf417.SetText(data);
            barcodePdf417.YHeight = 2f;
            Image image = barcodePdf417.GetImage();
            return image;
        }

        public Image GenerateLogo()
        {
            Image image = Image.GetInstance(LOGO.GetLogoPath());
            //原长度为1.5f
            image.ScaleAbsoluteHeight(UNIT * 1.3f);
            image.ScaleAbsoluteWidth(UNIT * 1.3f);
            return image;
        }
    }
}