using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppSuportadoAPI.Data;
using AppSuportadoAPI.Models;

namespace AppSuportadoAPI.Controller{
  [ApiController]
  [Route("[Controller]")]
  public class AppSuportadoController : ControllerBase
  {
      private readonly DataContext _context;

      public AppSuportadoController (DataContext context){
        _context = context;
      }

      [HttpGet("GetAll")]
      public async Task<IActionResult> Get()
        {
            try
            {
                List<AppSuportado> lista = await _context.TB_APPUPORTADO.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AppSuportado newModel)
        {
            try
            {
                int ultimoId = _context.TB_APPUPORTADO
                .OrderByDescending(app => app.Id)
                .Select(app => app.Id)
                .FirstOrDefault();


                newModel.Id = ultimoId+1;

                await _context.TB_APPUPORTADO.AddAsync(newModel);
                await _context.SaveChangesAsync();

                return Ok(newModel.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AppSuportado newModel)
        {
            try
            {
                _context.TB_APPUPORTADO.Update(newModel);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                AppSuportado? mRemover = await _context.TB_APPUPORTADO.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_APPUPORTADO.Remove(mRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
  }
}