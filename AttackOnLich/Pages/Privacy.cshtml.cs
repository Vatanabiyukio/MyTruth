using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace AttackOnLich.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public FileContentResult OnGet()
    {
        return File(GerarPdf(), "application/pdf", "GuiasExame-Periodico.pdf");
    }

    public FileResult ImprimirGuias()
    {
        return File(GerarPdf(), "application/pdf", "GuiasExame-Periodico.pdf");
    }

    public byte[] GerarPdf()
    {
        const string caminhoDoPdf = "/Users/viniciusvatanabi/Desktop/MyTruth/AttackOnLich/wwwroot/guia/GUIA.pdf";
        var reader = new PdfReader(new RandomAccessFileOrArray(caminhoDoPdf), null);
        var size = reader.GetPageSizeWithRotation(1);
        var memoryStream = new MemoryStream();
        var document = new Document(size, 0, 0, 0, 0);
        var writer = PdfWriter.GetInstance(document, memoryStream);
        document.Open();
        document.NewPage();
        var cb = writer.DirectContent;

        var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        var baseFontNegrito = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        cb.SetRGBColorFill(14, 62, 137);
        cb.BeginText();

        var page = writer.GetImportedPage(reader, 1);
        cb.AddTemplate(page, 0, 0);

        //Quadro - Responsável Técnico
        cb.SetFontAndSize(baseFontNegrito, 7);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Responsável Técnico", 362F, 574F, 0F);
        
        //Quadro - Responsável Técnico - Medico
        // cb.SetFontAndSize(baseFont, 7);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Arroz de Frango da Silva".ToUpper(), 440F, 551F, 0F);

        //Quadro - Cargo
        // cb.SetFontAndSize(baseFontNegrito, 7);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Mago Rank S+".ToUpper(), 440F, 545F, 0F);

        //Quadro - RQE
        // cb.SetFontAndSize(baseFontNegrito, 7);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "RQE Nº: 213697135", 362F, 526F, 0F);

        //Quadro - CRM
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CRM-DF: 51778", 519.2F, 526F, 0F);
        // cb.SetFontAndSize(baseFont, 7);

        //4 - Data da Autorização
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, new DateOnly(2022, 5, 5).ToShortDateString(), 89.3F, 502.4F, 0F);

        //5 - Senha
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "001", 247F, 502.4F, 0F);

        //6 - Validade Senha
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, new DateOnly(2023, 5, 5).ToShortDateString(), 404F, 502.4F, 0F);

        //8 - Número da Carteira
        cb.SetTextMatrix(45, 469);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "964.283.546.874", 140F, 470.5F, 0F);

        //10 - Nome Funcionário
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Natsu Dragneel".ToUpper(), 466F, 470.5F, 0F);
        
        //11 - Cartão Nacional de Saúde
        cb.SetCharacterSpacing(6.23F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "297254815721401", 669.3F, 470.5F, 0F);
        cb.SetCharacterSpacing(0);

        //13 - Código Operadora
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Convert.ToUInt64("12745123553599").ToString(@"00\.000\.000\/0000\-00"), 111.8F, 439.6F, 0F);
        
        //15 - Nome do Profissional Solicitante
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rodolfo Souto".ToUpper(), 199.25F, 417.45F, 0F);
        
        //16 - Conselho Profissional
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CRM".ToUpper(), 385.4F, 416.4F, 0F);
        
        //17 - Número no Conselho
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "9822", 492F, 417.45F, 0F);

        //18 - UF 
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "KW".ToUpper(), 592.34F, 417.45F, 0F);
        
        //22 - Data da Solicitação = Data da Aprovação
        var diaSolicitacao = new DateOnly(2022, 5, 5).Day.ToString().PadLeft(2, '0');
        var mesSolicitacao = new DateOnly(2022, 5, 5).Month.ToString().PadLeft(2, '0');
        var anoSolicitacao = new DateOnly(2022, 5, 5).Year.ToString().PadLeft(4, '0');
        
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, diaSolicitacao[0].ToString(), 94.75F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, diaSolicitacao[1].ToString(), 105.35F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, mesSolicitacao[0].ToString(), 121.97F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, mesSolicitacao[1].ToString(), 132.57F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, anoSolicitacao[0].ToString(), 149.17F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, anoSolicitacao[1].ToString(), 159.8F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, anoSolicitacao[2].ToString(), 170.4F, 386.5F, 0F);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, anoSolicitacao[3].ToString(), 181F, 386.5F, 0F);

        //23 Indicação Clinica
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CliniCASSI Magnolia".ToUpper(), 202F, 386.5F, 0F);

        //24 Tabela
        cb.SetCharacterSpacing(6);
        foreach (var i in Enumerable.Range(0, 5))
        {
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (i+10).ToString(), 57.38F, 362F - 9.9123F * i, 0F);
        }

        //25 Código De Procedimento
        cb.SetCharacterSpacing(6.7F);
        foreach (var i in Enumerable.Range(0, 5))
        {
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0000026534".PadLeft(10, '0'), 77.61F, 362F - 9.9123F * i, 0F);
        }

        //26 - Código do Procedimento ou Item Assistencial
        cb.SetCharacterSpacing(0);
        foreach (var i in Enumerable.Range(0, 5))
        {
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                "Riku uiva como se estivesse golpeando as próprias emoções.".ToUpper(), 192F, 362F - 9.9123F * i, 0F);
        }

        //27 - Quantidade Solicitada = Quantidade Autorizada
        cb.SetCharacterSpacing(6);
        foreach (var i in Enumerable.Range(0, 5))
        {
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "001".PadLeft(3, '0'), 784.8F, 362F - 9.9123F * i, 0F);
        }

        //28 - Quantidade Autorizada
        foreach (var i in Enumerable.Range(0, 5))
        {
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "001".PadLeft(3, '0'), 746.6F, 362F - 9.9123F * i, 0F);
        }

        //33 - Indicação de Acidente
        cb.SetCharacterSpacing(0);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "1", 199.05F, 263.5F, 0F);
        
        //58 - Observação || Justificativa
        var ct = new ColumnText(cb);
        ct.SetSimpleColumn(new Phrase(new Chunk("Guia para o uso exclusivo do programa de controle médico de saúde ocupacional. Esta guia deve ser processada somente com o número do Cartão pré-impresso nesta (Campo 8).\nPrestadores com faturamento eletrônico devem lançar no Fature a senha impressa (Campo 5).\nNa ausência de prestadores credenciados na região, gentileza entrar em contato com a Unidade Cassi.", FontFactory.GetFont(FontFactory.HELVETICA, 7, Font.NORMAL))), 40, 86, 800, 10, 8, Element.ALIGN_LEFT);
        ct.Go();

        cb.EndText();
        document.Close();
        writer.Close();
        reader.Close();
        return memoryStream.GetBuffer();
    }
}