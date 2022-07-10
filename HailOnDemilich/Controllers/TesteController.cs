using HailOnDemilich.Context;
using HailOnDemilich.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HailOnDemilich.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class TesteController : ControllerBase
{
    private readonly DbPlntoEpsContext _contextA;
    private readonly DbFormContext _contextB;
    private readonly MyDbContext _contextC;

    public TesteController(DbPlntoEpsContext contextA, DbFormContext contextB, MyDbContext contextC)
    {
        _contextA = contextA;
        _contextB = contextB; 
        _contextC = contextC;
    }
    
    [HttpGet("Errados")]
    public async Task<ActionResult> GetErrados()
    {
        var previsão = await _contextA.TbPrvsos.Where(prev => prev.IdExrco == 10 && prev.IdUf == 0).ToListAsync();
        var informaçãoDaRegraGeral = new List<object?>();
        var informaçãoFalha = new List<object?>();
        try
        {
            foreach (var caso in previsão)
            {
                var peixe = await _contextC.TbBbEps.FirstOrDefaultAsync(peixe => peixe.Cpf == caso.NrCpf);
                if (peixe == null)
                {
                    informaçãoFalha.Add(caso.NrCpf);
                    continue;
                }
                var tubarão = new { CPF = peixe.Cpf, Cd_Ltcao = peixe.Prefixo };
                informaçãoDaRegraGeral.Add(tubarão);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        foreach (var item in informaçãoFalha)
        {
            Console.WriteLine(item);
        }

        return Ok(informaçãoDaRegraGeral);
    }

    // GET
    [HttpGet("Corrigir_Pessoa_EPS_BB_Via_CPF")]
    public async Task<ActionResult> GetTestes([FromQuery] string cpf)
    {
        try
        {
            var informaçõesDaRegraGeral = await _contextC.TbBbEps.FindAsync(cpf);
            var previsão = _contextA.TbPrvsos.FirstOrDefault(prev => prev.NrCpf == cpf && prev.IdExrco == 10);
            var uf = _contextA.TbUfs.FirstOrDefault(uft => uft.TxSgla == informaçõesDaRegraGeral.Uf);
            var lotação = _contextA.TbLtcaos.FirstOrDefault(lot => lot.CdLtcao == informaçõesDaRegraGeral.Prefixo && lot.IdUf == uf.IdUf);
            var município = _contextA.TbMncpos.FirstOrDefault(mncp => mncp.NmMncpo == informaçõesDaRegraGeral.Municipio && mncp.IdUf == uf.IdUf);
            var clínicaTipoAtendimentoLotação = _contextA.TbClncaTpoAtdtoLtcaos.Where(ctal => ctal.IdLtcao == lotação.IdLtcao && ctal.IdExrco == 10).Where(caso => _contextA.TbClncaTpoAtdtos.FirstOrDefault(tcta => tcta.IdClncaTpoAtdto == caso.IdClncaTpoAtdto).IdTpoAtdto != 6);
            var clínicaTipoAtendimento = _contextA.TbClncaTpoAtdtos.Where(cta => cta.IdClncaTpoAtdto == clínicaTipoAtendimentoLotação.FirstOrDefault(ctal => ctal.IdClncaTpoAtdto == cta.IdClncaTpoAtdto).IdClncaTpoAtdto);
            var clínica = _contextA.TbClncas.Where(c => c.IdClnca == clínicaTipoAtendimento.FirstOrDefault(cta => c.IdClnca == cta.IdClnca).IdClnca);
            var tipoAtendimento = _contextA.TbTpoAtdtos.Where(ta => ta.IdTpoAtdto == clínicaTipoAtendimento.FirstOrDefault(cta => cta.IdTpoAtdto == ta.IdTpoAtdto).IdTpoAtdto);
            previsão.IdUf = uf.IdUf;
            previsão.IdUfPrvso = uf.IdUf;
            previsão.IdLtcao = lotação.IdLtcao;
            previsão.IdLtcaoPrvso = lotação.IdLtcao;
            previsão.CdLtcao = lotação.CdLtcao;
            previsão.IdMncpo = município.IdMncpo;
            if (!clínicaTipoAtendimentoLotação.Any())
            {
                // _contextA.Entry(previsão);
                // await _contextA.SaveChangesAsync();
                return Ok(new
                {
                    Regra = informaçõesDaRegraGeral,
                    Previsao = previsão,
                    UF = uf,
                    Municipio = município,
                    Lotação = lotação
                });
            }
            // if (tipoAtendimento.IdTpoAtdto == 1)
            // {
            //     previsão.IdClncaTpoAtdto = clínicaTipoAtendimento.IdClncaTpoAtdto;
            //     _contextA.Entry(previsão);
            //     await _contextA.SaveChangesAsync();
            // }
            if (clínicaTipoAtendimento.Count() > -1)
            {
                var semelhantes = _contextA.TbPrvsos.Where(a => a.NrCpf != informaçõesDaRegraGeral.Cpf && a.IdExrco == 10 && a.IdLtcao == lotação.IdLtcao && a.IdClncaTpoAtdto == clínicaTipoAtendimento.FirstOrDefault(b => b.IdClncaTpoAtdto == a.IdClncaTpoAtdto).IdClncaTpoAtdto);
                var previsãoAtendimento = _contextA.TbPrvsoAtends.Where(p =>
                    p.DtPrvso.Value.Year == 2022 && p.IdClncaTpoAtdto == clínicaTipoAtendimento
                        .FirstOrDefault(q => q.IdClncaTpoAtdto == p.IdClncaTpoAtdto).IdClncaTpoAtdto).GroupBy(x => x.IdClncaTpoAtdto, (key, g) => g.OrderBy(e => e.IdClncaTpoAtdto).First());
                return Ok(new
                {
                    Regra = informaçõesDaRegraGeral, 
                    Previsão = previsão,
                    Previsão_atdto = previsãoAtendimento,
                    UF = uf, 
                    Municipio = município, 
                    Lotação = lotação, 
                    Clnca_tpo_atdto_ltcao = clínicaTipoAtendimentoLotação, 
                    Clnca_tpo_atdto = clínicaTipoAtendimento,
                    Clínica = clínica,
                    Tpo_atdto = tipoAtendimento,
                    Pessoas_da_lotação_previstas = semelhantes
                });
            }
            return Ok(new
            {
                Regra = informaçõesDaRegraGeral, 
                Previsão = previsão, 
                UF = uf, 
                Municipio = município, 
                Lotação = lotação, 
                Clnca_tpo_atdto_ltcao = clínicaTipoAtendimentoLotação, 
                Clnca_tpo_atdto = clínicaTipoAtendimento,
                Clínica = clínica,
                Tpo_atdto = tipoAtendimento
            });
        }
        catch (SystemException e)
        {
            return Problem();
        }
        catch (Exception e)
        {
            return Problem();
        }

    }
}