using System.Collections.Generic;

namespace BLL.BLL
{
    public class Discount
    {
        public Discount(decimal val)
        {
            _value = val;
        }
        private decimal _value = 0;
        public decimal Value { get { return _value; } }
        public decimal GetDiscount(decimal price)
        {
            if (price > 200000)
                return price - price * _value;
            return price;
        }
    }

    //public PartialViewResult CreateAppointment()
    //{
    //    List<SelectListItem> doctorNamesList = new List<SelectListItem>();
    //    List<SelectListItem> patientNamesList = new List<SelectListItem>();
    //    List<DoctorVM> doctorVMs = MapperUtilVM.MapToDoctorVMList(doctorService.GetDoctors());

    //    foreach (DoctorVM doctor in doctorVMs)
    //    {
    //        doctorNamesList.Add(new SelectListItem
    //        {
    //            Text = doctor.FirstName + " " + doctor.LastName + " " + doctor.Patronymic,
    //            Value = doctor.DoctorId.ToString()
    //        });
    //    }
    //    ViewBag.doctorNamesList = doctorNamesList;

    //    List<PatientVM> patientVMs = MapperUtilVM.MapToPatientVMList(patientService.GetPatients());
    //    foreach (PatientVM patient in patientVMs)
    //    {
    //        patientNamesList.Add(new SelectListItem
    //        {
    //            Text = patient.FirstName + " " + patient.LastName + " " + patient.Patronymic,
    //            Value = patient.PatientId.ToString()
    //        });
    //    }
    //    ViewBag.patientNamesList = doctorNamesList;

    //    return PartialView("_CreateAppointment", new Models.AppointmentVM());
    //}
}
