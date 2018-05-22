using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ZXing;
using ZXing.Common;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace ProductLableGeneration
{
    public class PDFGenerator
    {
        private const float TITLE_FONT_SIZE = 7;
        // 1cm = 37.7777878f
        private const float UNIT = 38.2f;

        //private const float Heightfortable1 = 49 * UNIT;
        //private const float Heightfortable2 = 49 * UNIT;
        //private const float Heightfortable3 = 49 * UNIT;

        private const float ReceiverFontSize = 0.5f * UNIT;
        private const float DockGateFontSize = 0.7f * UNIT;
        private const float SupplierCompanyFontSize = 0.6f * UNIT;
        private const float GrossWeightAndBoxFontSize = 0.6f * UNIT;
        private const float PartNumberFontSize = 1.3f * UNIT;
        private const float QuantityFontSize = 1.3f * UNIT;
        private const float DescriptionFontSize = 0.5f * UNIT;
        private const float SupplierCodeFontSize = 0.5f * UNIT;
        private const float LogisticsReferenceFontSize = 0.7f * UNIT;
        //Date of manufacture, shipment or expire date
        private const float ShipmentFontSize = 0.5f * UNIT;
        private const float ChangeNumberFontSize = 0.5f * UNIT;
        private const float SerialNumberFontSize = 0.5f * UNIT;
        private const float BatchNumberFontSize = 0.5f * UNIT;


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
                    Description = "Aolly Wheel",
                    Dock = "Dock1",
                },
                FixedQuantity = 30.ToString(),
                Date = "D140203",
                SerialNumber = "20140131001",
                BatchNumber = "201401311",
                TotalAmount = "1056",
                LogisticRefer = "1026"
            });
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
                    Description = "Aolly Wheel",
                    Dock = "Dock1"
                },
                FixedQuantity = 30.ToString(),
                Date = "D140203",
                SerialNumber = "20140131001",
                BatchNumber = "201401311",
                TotalAmount = "1056",
                LogisticRefer = "1026"
            });
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
            var doc = new Document(PageSize.A4, 0.5f, 0.5f, 0, 0);

            var output = new FileStream(path, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            Font labelBraceFont = FontFactory.GetFont("Verdana", 7f, Font.BOLD);
            doc.Open();

            for (var i = 0; i < list.Count; i++)
            {
                if (i != 0 && i % 2 == 0)
                {
                    doc.NewPage();
                }
                var label = list[i];
                PdfContentByte cb = writer.DirectContent;
                var imagePartNumberPDF417Code = GeneratePDF417BarCode(cb, label.Product.PartNumber + "P");

                var table1 = new PdfPTable(2);
                table1.SpacingBefore = 0;
                if (i % 2 != 0)
                {
                    table1.SpacingBefore = 5;
                }
                table1.DefaultCell.Border = 0;
                table1.WidthPercentage = 100;
                //table1.DefaultCell.FixedHeight = Heightfortable1;


                var cell11 = new PdfPCell();
                cell11.Colspan = 1;
                var p = new Paragraph("(STABILIMENTO DI DESTINAZIONE)\r\nRECEIVER:",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SetLeading(0, 1.0f);
                cell11.AddElement(p);
                p = new Paragraph(label.Product.Receiver,
                    FontFactory.GetFont("Helvetica", ReceiverFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 0.8f);
                cell11.VerticalAlignment = Element.ALIGN_LEFT;
                cell11.AddElement(p);
                table1.AddCell(cell11);

                var cell12 = new PdfPCell();
                cell12.Colspan = 1;
                p = new Paragraph("(PUNTO DI RIFORNIMENTO)\r\nDOCK/GATE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell12.AddElement(p);
                p = new Paragraph(label.Product.Dock,
                    FontFactory.GetFont("Helvetica", DockGateFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 0.8f);
                cell12.AddElement(p);
                cell12.VerticalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cell12);

                var cell21 = new PdfPCell();
                p = new Paragraph("(NUMERO INTERNO B.A.M.)\r\nDOCUMENT NUMBER NO",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                Phrase r = new Phrase("      (N)", labelBraceFont);
                p.Add(r);
                p.SetLeading(0, 1.0f);
                cell21.AddElement(p);
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
                p = new Paragraph("(RAGIONE SOCIALE DEL FORNITORE)\r\nSUPPLIER ADDRESS",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell22_11.AddElement(p);
                p = new Paragraph(label.Product.SupplierAddress,
                    FontFactory.GetFont("Helvetica", SupplierCompanyFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SetLeading(0, 0.8f);
                cell22_11.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_11.AddElement(p);
                innerTable.AddCell(cell22_11);
                var cell22_21 = new PdfPCell();
                cell22_21.Colspan = 1;
                p = new Paragraph("(MASSA NETTA)\r\nNET WT (kg)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell22_21.AddElement(p);
                p = new Paragraph(label.Product.NetWeight,
                    FontFactory.GetFont("Helvetica", GrossWeightAndBoxFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 0.8f);
                cell22_21.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_21.AddElement(p);
                innerTable.AddCell(cell22_21);
                var cell22_22 = new PdfPCell();
                cell22_22.Colspan = 1;
                p = new Paragraph("(MASSA LORDA)\r\nGROSS WT (kg)",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell22_22.AddElement(p);
                p = new Paragraph(label.Product.GrossWeight,
                    FontFactory.GetFont("Helvetica", GrossWeightAndBoxFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 0.8f);
                cell22_22.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_22.AddElement(p);
                innerTable.AddCell(cell22_22);
                var cell22_23 = new PdfPCell();
                cell22_23.Colspan = 1;
                p = new Paragraph("(Q.TA CONTENITORI)\r\nNO BOXES",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell22_23.AddElement(p);
                p = new Paragraph(label.Product.Boxes,
                    FontFactory.GetFont("Helvetica", GrossWeightAndBoxFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 0.8f);
                cell22_23.VerticalAlignment = Element.ALIGN_LEFT;
                cell22_23.AddElement(p);
                innerTable.AddCell(cell22_23);
                var cell22 = new PdfPCell(innerTable);
                table1.AddCell(cell22);

                doc.Add(table1);

                var table2 = new PdfPTable(12);
                table2.DefaultCell.Border = 0;
                table2.WidthPercentage = 100.2f;
                //table2.DefaultCell.FixedHeight = Heightfortable2;
                var cell31 = new PdfPCell();
                cell31.BorderWidthTop = 0;
                cell31.BorderWidthBottom = 0;
                cell31.Colspan = 7;
                cell31.Rowspan = 1;
                cell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                p = new Paragraph("(NUMERO DISEGNO/SIMBOLO)\r\nPART NUMBER", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                r = new Phrase("      (P)", labelBraceFont);
                p.Add(r);
                p.IndentationLeft = -7f;
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell31.AddElement(p);
                cell31.PaddingLeft = 10;
                cell31.BorderWidthRight = 0;
                p = new Paragraph(label.Product.PartNumber,
                    FontFactory.GetFont("Helvetica", PartNumberFontSize, BaseColor.BLACK));
                p.IndentationLeft = -7;
                p.SpacingAfter = 10;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.1f);
                cell31.VerticalAlignment = Element.ALIGN_LEFT;
                cell31.AddElement(p);
                table2.AddCell(cell31);

                var cell32 = new PdfPCell();
                cell32.BorderWidthTop = 0;
                cell32.BorderWidthLeft = 0;
                cell32.BorderWidthRight = 0;
                cell32.BorderWidthBottom = 0;
                cell32.Colspan = 3;
                cell32.Rowspan = 1;
                cell32.PaddingTop = 10f;
                cell32.PaddingLeft = -25f;
                cell32.HorizontalAlignment = Element.ALIGN_LEFT;
                cell32.AddElement(imagePartNumberPDF417Code);

                var cell33 = new PdfPCell();
                cell33.BorderWidthTop = 0;
                cell33.BorderWidthLeft = 0;
                cell33.BorderWidthBottom = 0;
                cell33.Colspan = 2;
                cell33.Rowspan = 1;
                cell33.PaddingTop = 2;
                Image logo = GenerateLogo();
                logo.IndentationLeft = 5;
                logo.Alignment = Image.ALIGN_CENTER;
                cell33.AddElement(logo); 
                table2.AddCell(cell32);
                table2.AddCell(cell33);

                doc.Add(table2);

                var table3 = new PdfPTable(2);
                table3.DefaultCell.Border = 0;
                table3.WidthPercentage = 100;
                //table3.DefaultCell.FixedHeight = Heightfortable3;
                var innerTable41 = new PdfPTable(2);
                var cell41_1 = new PdfPCell();
                cell41_1.PaddingLeft = 10f;
                cell41_1.Colspan = 1;
                cell41_1.Rowspan = 1;
                cell41_1.BorderWidth = 0;
                p = new Paragraph("(QUANTITANEL CONTENITORE)\r\nQUANTITY", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                r = new Phrase("      (Q)", labelBraceFont);
                p.Add(r);
                p.IndentationLeft = -7f;
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell41_1.AddElement(p);
                p = new Paragraph(label.FixedQuantity,
                    FontFactory.GetFont("Helvetica", QuantityFontSize, BaseColor.BLACK));
                p.SpacingAfter = 10;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.1f);
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
                p = new Paragraph("(DENOMINAZIONE DEL PRODOTTO)\r\nDESCRIPTION", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SetLeading(0, 1.0f);
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                cell42_1.AddElement(p);
                p = new Paragraph(label.Product.Description,
                    FontFactory.GetFont("Helvetica", DescriptionFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SetLeading(0, 0.8f);
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
                p = new Paragraph("(DATI DI LOGISTICA)\r\nLOGISTIC REFERNCE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell42_2.AddElement(p);
                p = new Paragraph(label.LogisticRefer, FontFactory.GetFont("Helvetica", LogisticsReferenceFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SetLeading(0, 0.8f);
                p.SpacingAfter = 0;

                cell42_2.VerticalAlignment = Element.ALIGN_LEFT;
                cell42_2.AddElement(p);
                interTable42.AddCell(cell42_2);
                var cell42_3 = new PdfPCell();
                cell42_3.Colspan = 1;
                cell42_3.Rowspan = 1;
                p = new Paragraph("(DATA)\r\nDATE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell42_3.AddElement(p);
                p = new Paragraph(label.Date, FontFactory.GetFont("Helvetica", ShipmentFontSize, BaseColor.BLACK));
                p.SpacingAfter = 1;
                cell42_3.VerticalAlignment = Element.ALIGN_LEFT;
                p.SetLeading(0, 0.8f);
                cell42_3.AddElement(p);
                interTable42.AddCell(cell42_3);
                var cell42_32 = new PdfPCell();
                cell42_32.Colspan = 1;
                cell42_32.Rowspan = 1;
                p = new Paragraph("(NUMERO DIMODIFICA)\r\nENGINERING CHANGE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                cell42_32.AddElement(p);
                p = new Paragraph(label.Product.EngineeringChange,
                    FontFactory.GetFont("Helvetica", ChangeNumberFontSize, BaseColor.BLACK));
                p.SpacingAfter = 1;
                p.SetLeading(0, 0.8f);
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
                p = new Paragraph("(NUMERO LOTTO DI PRODUZIONE)\r\nBATCH NUMBER", FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                r = new Phrase("      (H)", labelBraceFont);
                p.Add(r);
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                p.IndentationLeft = 0f;
                cell42_4.AddElement(p);
                cell42_4.VerticalAlignment = Element.ALIGN_LEFT;
                p = new Paragraph(label.BatchNumber, FontFactory.GetFont("Helvetica", BatchNumberFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SetLeading(0, 0.8f);
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
                p = new Paragraph("(CODICE FORNITORE)\r\nSUPPLIER CODE",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                r = new Phrase("      (V)", labelBraceFont);
                p.Add(r);
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                A_Left_1.AddElement(p);
                p = new Paragraph(label.Product.SupplierCode,
                    FontFactory.GetFont("Helvetica", SupplierCodeFontSize, BaseColor.BLACK));
                p.SpacingAfter = 10;
                p.SetLeading(0, 0.8f);
                A_Left_1.AddElement(p);
                innerTableA_Left.AddCell(A_Left_1);
                var A_Left_2 = new PdfPCell();
                A_Left_2.Colspan = 1;
                A_Left_2.Rowspan = 1;
                p = new Paragraph("(NUMERO DELLA SCHEDA)\r\nSERIAL NUMBER",
                    FontFactory.GetFont("Helvetica", TITLE_FONT_SIZE, BaseColor.BLACK));
                r = new Phrase("      (S)/(M)", labelBraceFont);
                p.Add(r);
                p.SpacingAfter = 0;
                p.SpacingBefore = 0;
                p.SetLeading(0, 1.0f);
                A_Left_2.AddElement(p);
                p = new Paragraph("S"+label.SerialNumber, FontFactory.GetFont("Helvetica", SerialNumberFontSize, BaseColor.BLACK));
                p.SpacingAfter = 0;
                p.SetLeading(0, 1f);
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
                       ";" + fixedQuantity + ";" + totalAmount + ";;" + label.BatchNumber + ";" + label.Date + ";";
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


        public Image GeneratePDF417BarCode(PdfContentByte cb, string data)
        {
            //BarcodePDF417 barcodePdf417 = new BarcodePDF417();
            //barcodePdf417.CodeColumns = 20;
            //barcodePdf417.CodeRows = 1;
            //barcodePdf417.SetText(data);
            //Image image = barcodePdf417.GetImage();
            //return image;
            //BarcodePDF417 barcodePdf417 = new BarcodePDF417();
            //barcodePdf417.AspectRatio = 4f / 3f;
            //barcodePdf417.SetText(data);
            //Rectangle size = barcodePdf417.GetBarcodeSize();
            //PdfTemplate template = cb.CreateTemplate(size.Height, size.Width);
            //barcodePdf417.PlaceBarcode(template, BaseColor.BLACK, 1, 1);
            //Image image = barcodePdf417.GetImage();

            //image.XYRatio = 4f / 3f;
            //image.ScaleAbsoluteHeight(UNIT * 1.8f);
            //image.ScaleAbsoluteWidth(5f * UNIT);
            //return image;

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.PDF_417,
                Options = new EncodingOptions { Width = 500, Height = 210, Margin = 0} //optional
            };
            var imgBitmap = writer.Write(data);
            imgBitmap.Save("xxx.png", ImageFormat.Png);
            Image image = iTextSharp.text.Image.GetInstance("xxx.png");
            //image.ScaleAbsolute(UNIT * 4f, UNIT * 3f);
            image.ScalePercent(25f);
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