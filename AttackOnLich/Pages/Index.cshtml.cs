using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace AttackOnLich.Pages;

public abstract class Animal
{
    private string Nome { get; }
    private bool Dono { get; }
    private int Idade { get; }

    protected Animal(string nome, bool dono, int idade)
    {
        Nome = nome;
        Dono = dono;
        Idade = idade;
    }
}

public class Gato : Animal
{
    private string Raça { get; }

    public Gato(string nome, bool dono, int idade, string raça) : base(nome, dono, idade)
    {
        Raça = raça;
    }
}

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public DateTime DataAgendamento { get; set; } = DateTime.Today;

    public void OnGet()
    {
    }

    public FileResult ImprimirGuias()
    {
        return File(GerarPdf(), "application/pdf", "GuiasExame-Periodico.pdf");
    }

    public byte[] GerarPdf()
    {
        var caminhoDoPdf = "/wwwroot/guia/GUIA.pdf";
        PdfReader reader = new PdfReader(new RandomAccessFileOrArray(caminhoDoPdf), null);
        Rectangle size = reader.GetPageSizeWithRotation(1);
        MemoryStream memoryStream = new MemoryStream();
        Document document = new Document(size, 192, 0, 6, 0);
        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        document.Open();
        try
        {
            // document.NewPage();
            // PdfContentByte cb = writer.DirectContent;
            // var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            // cb.SetFontAndSize(baseFont, 7);
            // cb.SetRGBColorFill(14, 62, 137);
            // cb.BeginText();
            // PdfImportedPage page = writer.GetImportedPage(reader, 1);
            // cb.AddTemplate(page, 0, 0);
            // cb.PdfDocument.PageSize.
            // //Quadro - Responsável Técnico
            // cb.SetFontAndSize(BaseFont.CreateFont(), 8);
            // cb.SetTextMatrix(400, 572);
            // cb.ShowText("Responsável Técnico");
            //
            // //Quadro - Responsável Técnico - Medico
            // cb.SetFontAndSize(BaseFont.CreateFont(), 7);
            // cb.SetTextMatrix(375, 559);
            // cb.ShowText(dados.tec_nome);
            //
            // //Quadro - Cargo
            // cb.SetFontAndSize(BaseFont.CreateFont(), 7);
            // cb.SetTextMatrix(415, 545);
            // cb.ShowText("Cargo: " + dados.tec_cargo);
            //
            // //Quadro - RQE
            // cb.SetFontAndSize(BaseFont.CreateFont(), 7);
            // cb.SetTextMatrix(362, 526);
            // cb.ShowText("RQE:");
            //
            // //Quadro - CRM
            // cb.SetFontAndSize(BaseFont.CreateFont(), 7);
            // cb.SetTextMatrix(458, 526);
            // cb.ShowText("CRM - " + dados.tec_nrinscricao + " - " + dados.tec_ufconselho);
            //
            // //4 - Data da Autorização
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(50, 500);
            // cb.ShowText(dados.c04_dataautorizacao.ToShortDateString());
            //
            // //5 - Senha
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(180, 500);
            // cb.ShowText(dados.c05_senha.ToString());
            //
            // //6 - Validade Senha
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(370, 500);
            // cb.ShowText(dados.c06_datavalidade.ToShortDateString());
            //
            // //8 - Número da Carteira
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(45, 469);
            // cb.ShowText(dados.c08_numerocarteira);
            //
            // //10 - Nome Funcionario
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(357, 470);
            // cb.ShowText(dados.c10_nome);
            //
            // //13 - Codigo Operadora
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(44, 439);
            // cb.ShowText(
            //     Convert.ToUInt64(dados.c13_codigonaoperadora).ToString(@"00\.000\.000\/0000\-00").ToString());
            //
            // //UF 
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(583, 415);
            // cb.ShowText(dados.c18_uf);
            //
            // //23 Indicação Clinica
            // cb.SetFontAndSize(BaseFont.CreateFont(), 10);
            // cb.SetTextMatrix(202, 386);
            // cb.ShowText(dados.c23_indicacaoclinica);
            //
            // //24 Tabela
            // cb.SetFontAndSize(BaseFont.CreateFont(), 9);
            // cb.SetTextMatrix(49, 361);
            // cb.ShowText(dados.c24_tabela);
            //
            // //25 Código De Procedimento
            // cb.SetFontAndSize(BaseFont.CreateFont(), 9);
            // cb.SetTextMatrix(95, 360);
            // cb.ShowText(dados.c25_cod_procedimento);
            //
            // //26 - Código do Procedimento ou Item Assistencial
            // cb.SetFontAndSize(BaseFont.CreateFont(), 9);
            // cb.SetTextMatrix(192, 361);
            // cb.ShowText(dados.c26_descricao);
            //
            // //28 - Quantidade
            // cb.SetFontAndSize(BaseFont.CreateFont(), 9);
            // cb.SetTextMatrix(795, 361);
            // cb.ShowText(dados.c28_qtd_autorizada);
            //
            // //33 - Indicação de Acidente
            // cb.SetFontAndSize(BaseFont.CreateFont(), 9);
            // cb.SetTextMatrix(196, 263);
            // cb.ShowText("1");
            //
            // //58 - Observação/Justificativa
            // ColumnText ct = new ColumnText(cb);
            // ct.SetSimpleColumn(
            //     new Phrase(new Chunk(dados.c58_observavao,
            //         FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL))),
            //     40, 86, 800, 10, 8, Element.ALIGN_LEFT);
            // ct.Go();
            //
            // cb.EndText();
        }
        finally
        {
            document.Close();
            writer.Close();
            reader.Close();
        }

        return memoryStream.GetBuffer();
    }
}