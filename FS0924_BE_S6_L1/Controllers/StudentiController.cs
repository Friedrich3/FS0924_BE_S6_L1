using FS0924_BE_S6_L1.Services;
using FS0924_BE_S6_L1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S6_L1.Controllers
{
    public class StudentiController : Controller
    {
        private readonly StudentiServices _studentiServices;
        public StudentiController(StudentiServices studentiServices)
        {
            _studentiServices = studentiServices;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Studenti/Studenti-All")]
        public async Task<IActionResult> GetTable(){
            var StudentsList = await _studentiServices.GetStudents();

            return PartialView("_TabellaStudenti", StudentsList);
        }


        [HttpGet("Studenti/GetStudent/{studentId:guid}")]
        public async Task<IActionResult> GetStudent(Guid studentId){

            var studente = await _studentiServices.GetStudenteById(studentId);
            if (studente == null)
            {
                return RedirectToAction("Index");
            }
            var editStudent = new StudenteEditViewModel()
            {
                StudenteId = studente.StudenteId,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataDiNascita = studente.DataDiNascita,
            };
            return PartialView("_EditForm",editStudent);
        }

        [HttpPost("Studenti/Edit/Save")]
        public async Task<IActionResult> EditSave(StudenteEditViewModel editViewModel)
        {
            var result = await _studentiServices.SaveEditStudent(editViewModel);
            if (!result)
            {
                return Json(new
                {
                    success = false,
                    message = "Errore nell'aggiunta"
                });
            }
            return Json(new
            {
                success = true,
                message = "Aggiunta eseguita correttamente"
            });
        }

        [HttpPost("Studenti/Delete/{studentId:guid}")]
        public async Task<IActionResult>Delete(Guid studentId)
        {


            var result = await _studentiServices.DeleteStudent(studentId);
            if (!result)
            {
                return Json(new
                {
                    success = false,
                    message = "Errore nella rimozione"
                });
            }
            return Json(new
            {
                success = true,
                message = "Studente rimosso correttamente"
            });
        }
    }
}
