using FS0924_BE_S6_L1.Data;
using FS0924_BE_S6_L1.Models;
using FS0924_BE_S6_L1.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S6_L1.Services
{
    public class StudentiServices
    {
        private readonly PraticaS6L1 _context;
        private readonly LoggerServices _logger;
        public StudentiServices(PraticaS6L1 context , LoggerServices logger)
        {
            _context = context;
            _logger = logger;
        }
        private async Task<bool> SaveAsync()
        {
            try
            {
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }



        public async Task<List<Studente>> GetStudents()
        {
            var Lista = new List<Studente>();
            Lista = await _context.Studenti.ToListAsync();

            return Lista;

        }

        public async Task<Studente?> GetStudenteById(Guid id)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(id);
                if(studente == null)
                {
                    return null;
                }
                return studente;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> SaveEditStudent(StudenteEditViewModel model)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(model.StudenteId);
                if (studente == null)
                {
                    return false;
                }
                studente.Nome = model.Nome;
                studente.Cognome = model.Cognome;
                studente.Email = model.Email;
                studente.DataDiNascita = model.DataDiNascita;
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool>DeleteStudent( Guid id)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(id);
                if (studente == null)
                {
                    return false;
                }
                _context.Studenti.Remove(studente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

    }
}
