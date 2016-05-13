using Newtonsoft.Json;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl.ServiceImpl
{
    public class TemplateServcie : ITemplateService
    {
        public Template GetTemplate(long id)
        {
           return JsonConvert.DeserializeObject<Template>(WebService.getInstance().GetTemplate(id));
        }

        public List<Template> GetAllPatientTemplates(long patient_id)
        {
            string response = WebService.getInstance().GetAllPatientTemplates(patient_id);

            if (response.Equals(ServicesUtils.EMPTY_JSON))
            {
                return new List<Template>();
            }

            List<Template> templates = JsonConvert.DeserializeObject<List<Template>>(response);
            return templates;
        }

        public bool AddTemplate(Template template)
        {
            bool isAdded = WebService.getInstance().AddTemplate(template.Patient.Id, template.Hospital.HospitalId, template.Doctor.DoctorId, template.Title, template.Reason, template.Description);
            if (isAdded)
            {
                return true;
            }
            return false;
        }
    }
}
