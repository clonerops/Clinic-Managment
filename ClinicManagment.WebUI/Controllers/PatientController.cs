﻿using ClinicManagment.Application.contract.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentClinic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientApplication _patientApplication;

        public PatientController(IPatientApplication patientApplication)
        {
            _patientApplication = patientApplication;
        }

        [HttpPost]
        public JsonResult CreatePatient(CreatePatient command)
        {
            var patient = _patientApplication.Create(command);
            return new JsonResult(patient);
        }

        [HttpPut("{id:int}")]
        public JsonResult EditPatient([FromBody] EditPatient command)
        {
            var patient = _patientApplication.Edit(command);
            return new JsonResult(patient);
        }

        [HttpGet]
        public JsonResult GetAllPatients()
        {
            var patient = _patientApplication.Lists();
            return new JsonResult(patient);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetPatientById(int id)
        {
            var patient = _patientApplication.GetBy(id);
            return new JsonResult(patient);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DeleteAccount([FromRoute] int id)
        {
            var account = _patientApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:int}")]
        public JsonResult RestoreAccount([FromRoute] int id)
        {
            var account = _patientApplication.Restore(id);

            return new JsonResult(account);
        }

    }
}